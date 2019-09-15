using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ElGuayaBot.Common.IoC.Configuration
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {

            return services;
        }
    }
}