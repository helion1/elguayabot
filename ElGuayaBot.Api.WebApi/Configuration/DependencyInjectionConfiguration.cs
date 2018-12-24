using ElGuayaBot.Application.Contracts;
using ElGuayaBot.Application.Contracts.Flow;
using ElGuayaBot.Application.Implementation;
using ElGuayaBot.Application.Implementation.Background;
using ElGuayaBot.Application.Implementation.Flow;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

            return services;
        }
    }
}