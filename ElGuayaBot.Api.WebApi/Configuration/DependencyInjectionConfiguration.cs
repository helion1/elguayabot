using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Contracts.Service;
using ElGuayaBot.Application.Implementation.Background;
using ElGuayaBot.Application.Implementation.Client;
using ElGuayaBot.Application.Implementation.Service;
using ElGuayaBot.Infrastructure.Implementation.Client;
using ElGuayaBot.Infrastructure.Implementation.Service;
using ElGuayaBot.Persistence.Contracts;
using ElGuayaBot.Persistence.Implementation;
using ElGuayaBot.Persistence.Implementation.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Scrutor;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ElGuayaBot.Api.WebApi.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddBotBackgroundServices(this IServiceCollection services, IConfiguration configuration, IHostingEnvironment env)
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

                        
            services.AddScoped<SpotifyClient>();
            
            // Register every service from Application
            services.Scan(scan => scan
                .FromAssemblyOf<BotService>()
                .AddClasses(classes => classes.Where(c => c.Name.EndsWith("Service") && c.Name != "BotService"))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            
            // Register every service from Infrastructure
            services.Scan(scan => scan
                .FromAssemblyOf<SpotifyService>()
                .AddClasses(classes => classes.Where(c => c.Name.EndsWith("Service")))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            
            // Register every repository of Persistence
            services.Scan(scan => scan
                .FromAssemblyOf<UnitOfWork>()
                .AddClasses(classes => classes.Where(c => c.Name.EndsWith("Repository")))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            
            // Register Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}