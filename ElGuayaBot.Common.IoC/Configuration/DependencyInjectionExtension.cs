using ElGuayaBot.Domain.Configuration;
using ElGuayaBot.Persistence.Implementation.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ElGuayaBot.Common.IoC.Configuration
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDomainDependencies(configuration);
            services.AddPersistenceDependencies(configuration);

            return services;
        }
    }
}