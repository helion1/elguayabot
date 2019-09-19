using ElGuayabot.Application.Implementation.Configuration;
using ElGuayabot.Domain.Configuration;
using ElGuayabot.Infrastructure.Implementation.Configuration;
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
            services.AddApplicationDependencies(configuration);
            services.AddDomainDependencies(configuration);
            services.AddPersistenceDependencies(configuration);
            services.AddInfrastructureServices(configuration);
            
            return services;
        }
        
        public static void InitializeDatabases(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.InitializePersistenceDatabases(configuration);
        }
    }
}