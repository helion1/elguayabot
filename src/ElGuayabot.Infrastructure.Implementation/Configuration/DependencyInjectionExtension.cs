using System;
using ElGuayabot.Infrastructure.Contract.Service;
using ElGuayabot.Infrastructure.Implementation.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace ElGuayabot.Infrastructure.Implementation.Configuration
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddServices(configuration);
            
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IGifSearchService, GifSearchService>()
                .AddTransientHttpErrorPolicy(builder =>
                    builder.WaitAndRetryAsync(3, retryCount =>
                        TimeSpan.FromSeconds(Math.Pow(2, retryCount))));
            
            return services;
        }
    }
}