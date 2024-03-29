using System.Reflection;
using ElGuayabot.Application.Contract.Common.Client;
using ElGuayabot.Application.Contract.Common.Context;
using ElGuayabot.Application.Contract.Common.Strategy;
using ElGuayabot.Application.Implementation.Common.Client;
using ElGuayabot.Application.Implementation.Common.Context;
using ElGuayabot.Application.Implementation.Common.Strategy;
using ElGuayabot.Application.Implementation.Service;
using ElGuayabot.Application.Implementation.Service.Background;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Scrutor;

namespace ElGuayabot.Application.Implementation.Configuration
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddServices(configuration);
            services.AddBackgroundServices(configuration);
            services.AddRequests(configuration);
            services.AddMediatRHandlers(configuration);
            services.AddBotContext(configuration);
            
            return services;
        }
        
        private static IServiceCollection AddBackgroundServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IBotClient, BotClient>();
            services.AddSingleton<IHostedService, TelegramBackgroundService>();

            return services;
        }
                
        private static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBotActionSelector, BotActionSelector>();
            
            services.Scan(scan => scan
                .FromAssemblyOf<TelegramService>()
                .AddClasses(classes =>
                    classes.Where(c => c.Name.EndsWith("Service") && c.Name != "TelegramBackgroundService"))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.Scan(scan => scan
                .FromAssemblyOf<TelegramService>()
                .AddClasses(classes =>
                    classes.Where(c => c.Name.EndsWith("Factory")))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            
            return services;
        }

        private static IServiceCollection AddRequests(this IServiceCollection services, IConfiguration configuration)
        {
            services.Scan(scan => scan
                .FromAssemblyOf<TelegramService>()
                .AddClasses(classes => 
                    classes.Where(c => c.Name.EndsWith("Action")))
                .UsingRegistrationStrategy(RegistrationStrategy.Append)
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }

        private static IServiceCollection AddMediatRHandlers(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(DependencyInjectionExtension).GetTypeInfo().Assembly);

            return services;
        }
        
        private static IServiceCollection AddBotContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBotContext, BotContext>();
            services.AddScoped<IStrategyContext, StrategyContext>();
            
            return services;
        }
    }
}