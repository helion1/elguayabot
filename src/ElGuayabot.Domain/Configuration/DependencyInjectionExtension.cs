using System.Reflection;
using ElGuayabot.Domain.Business.ChatsUsers.RegisterUserChat;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ElGuayabot.Domain.Configuration
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