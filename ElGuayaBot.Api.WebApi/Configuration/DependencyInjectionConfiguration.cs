using ElGuayaBot.Application.Contracts;
using ElGuayaBot.Application.Contracts.Flow;
using ElGuayaBot.Application.Implementation;
using ElGuayaBot.Application.Implementation.Background;
using ElGuayaBot.Application.Implementation.Flow;
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
        public static IServiceCollection AddBotDI(this IServiceCollection services)
        {
            services.AddSingleton<IBotClient, BotClient>();
            services.AddScoped<IBotService, BotService>();

            return services;
        }
        
        public static IServiceCollection AddBackgroundServices(this IServiceCollection services)
        {
            services.AddSingleton<IHostedService, TelegramBotBackgroundService>();

            return services;
        }
        
        public static IServiceCollection AddFlows(this IServiceCollection services)
        {
            services.AddScoped<IUnknownFlow, UnknownFlow>();
            services.AddScoped<IRandomTextFlow, RandomTextFlow>();
            services.AddScoped<IFlipCoinFlow, FlipCoinFlow>();
            services.AddScoped<IPingPongFlow, PingPongFlow>();
            services.AddScoped<IAboutFlow, AboutFlow>();
            services.AddScoped<IHelpFlow, HelpFlow>();
            services.AddScoped<IComandanteFlow, ComandanteFlow>();
            services.AddScoped<IFrutaFlow, FrutaFlow>();
            services.AddScoped<IWelcomeMessageFlow, WelcomeMessageFlow>();
            services.AddScoped<IDabFlow, DabFlow>();
            services.AddScoped<ILeftChatMessageFlow, LeftChatMessageFlow>();
            services.AddScoped<ITenorGifFlow, TenorGifFlow>();
            services.AddScoped<IComunicaTest, ComunicaTest>();
            services.AddScoped<IPutoGuayabaFlow, PutoGuayabaFlow>();

            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration, IHostingEnvironment env)
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