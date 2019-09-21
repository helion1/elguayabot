using System;
using ElGuayabot.Infrastructure.Contract.Client;
using ElGuayabot.Infrastructure.Contract.Service;
using ElGuayabot.Infrastructure.Implementation.Client;
using ElGuayabot.Infrastructure.Implementation.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Scrutor;

namespace ElGuayabot.Infrastructure.Implementation.Configuration
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddClients(configuration);
            services.AddServices(configuration);
            
            return services;
        }

        private static IServiceCollection AddClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IGiphyClient, GiphyClient>()
                .AddTransientHttpErrorPolicy(builder =>
                    builder.WaitAndRetryAsync(3, retryCount =>
                        TimeSpan.FromSeconds(Math.Pow(2, retryCount))));
            
            services.AddHttpClient<IGoogleSearchClient, GoogleSearchClient>()
                .AddTransientHttpErrorPolicy(builder =>
                    builder.WaitAndRetryAsync(3, retryCount =>
                        TimeSpan.FromSeconds(Math.Pow(2, retryCount))));
            
            return services;
        }
        
        private static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Scan(scan => scan
                .FromAssemblyOf<GifSearchService>()
                .AddClasses(classes =>
                    classes.Where(c => c.Name.EndsWith("Service")))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            
            return services;
        }
    }
}