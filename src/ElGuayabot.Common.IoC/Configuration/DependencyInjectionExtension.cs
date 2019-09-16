using ElGuayabot.Persistence.Implementation.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ElGuayabot.Common.IoC.Configuration
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistenceDependencies(configuration);
            
            return services;
        }
        
        public static void InitializeDatabases(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.InitializePersistenceDatabases(configuration);
        }
    }
}