using ElGuayaBot.Application.Contracts;
using ElGuayaBot.Application.Implementation;
using ElGuayaBot.Application.Implementation.Background;
using ElGuayaBot.Persistence.Contracts;
using ElGuayaBot.Persistence.Implementation;
using ElGuayaBot.Persistence.Implementation.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Scrutor;

namespace ElGuayaBot.Api.WebApi.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddBotBackgroundServices(this IServiceCollection services)
        {
            services.AddSingleton<IBotClient, BotClient>();
            services.AddScoped<IBotService, BotService>();
            
            services.AddSingleton<IHostedService, TelegramBotBackgroundService>();

            return services;
        }
        
        public static IServiceCollection AddCustomDependencyInjection(this IServiceCollection services, IConfiguration configuration, IHostingEnvironment env)
        {
            services.AddDbContext<ElGuayaBotDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("PostgreSQL"));
            });

            // Register every repository
            services.Scan(scan => scan
                .FromAssemblyOf<UnitOfWork>()
                .AddClasses(classes => classes.Where(c => c.Name.EndsWith("Repository")))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            
            // Register UoW
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            
            return services;
        }
    }
}