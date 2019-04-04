using System.Reflection;
using ElGuayaBot.Domain.Business.UserChat.RegisterUserChat;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ElGuayaBot.Domain.Configuration
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDomainDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatRHandlers(configuration);
            
            return services;
        }
        
        private static IServiceCollection AddMediatRHandlers(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(RegisterChatUserCommandHandler).GetTypeInfo().Assembly);

            return services;
        }
    }
}