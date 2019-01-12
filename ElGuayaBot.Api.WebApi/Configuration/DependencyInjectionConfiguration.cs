using ElGuayaBot.Application.Contracts.Client;
using ElGuayaBot.Application.Contracts.Flow;
using ElGuayaBot.Application.Contracts.Service;
using ElGuayaBot.Application.Implementation.Background;
using ElGuayaBot.Application.Implementation.Client;
using ElGuayaBot.Application.Implementation.Flow;
using ElGuayaBot.Application.Implementation.Service;
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

            // Register every service
            services.Scan(scan => scan
                .FromAssemblyOf<BotService>()
                .AddClasses(classes => classes.Where(c => c.Name.EndsWith("Service") && c.Name != "BotService"))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            
            // Register every repository
            services.Scan(scan => scan
                .FromAssemblyOf<UnitOfWork>()
                .AddClasses(classes => classes.Where(c => c.Name.EndsWith("Repository")))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            
            // Register UoW
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            // Register flows (Erase this when possible)
            services.AddScoped<IUnknownFlow, UnknownFlow>();
            services.AddScoped<IRandomTextFlow, RandomTextFlow>();
            services.AddScoped<IFlipCoinFlow, FlipCoinFlow>();
            services.AddScoped<IHelpFlow, HelpFlow>();
            services.AddScoped<IFrutaFlow, FrutaFlow>();
            services.AddScoped<IWelcomeMessageFlow, WelcomeMessageFlow>();
            services.AddScoped<ILeftChatMessageFlow, LeftChatMessageFlow>();
            services.AddScoped<ITenorGifFlow, TenorGifFlow>();
            services.AddScoped<IPutoGuayabaFlow, PutoGuayabaFlow>();

            return services;
        }
    }
}