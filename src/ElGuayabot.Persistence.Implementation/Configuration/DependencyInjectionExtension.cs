using ElGuayabot.Persistence.Contract;
using ElGuayabot.Persistence.Implementation.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace ElGuayabot.Persistence.Implementation.Configuration
{
    public static class DependencyInjectionExtension
    {
        public static void InitializePersistenceDatabases(this IApplicationBuilder app, IConfiguration configuration)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<ElGuayabotDbContext>().Database.Migrate();
            }
        }
        public static IServiceCollection AddPersistenceDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabaseContext(configuration);
            services.AddRepositories(configuration);
            
            return services;
        }

        private static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ElGuayabotDbContext>(options =>
            {
                var connectionString = configuration["ELGUAYABOT_CONNECTION_STRING"] ?? configuration.GetConnectionString("ElGuayabotDatabase");
                
                options.UseNpgsql(connectionString);    
            });

            return services;
        }
        
        private static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            // Register every repository
            services.Scan(scan => scan
                .FromAssemblyOf<UnitOfWork>()
                .AddClasses(classes => classes.Where(c => c.Name.EndsWith("Repository")))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            
            // Register UoW as scoped
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}