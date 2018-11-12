using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;

namespace ElGuayaBot.Api.WebApi.Configuration
{
    public static class AuthorizationConfiguration
    {
        public static IServiceCollection AddCustomAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrator", policy => policy.RequireClaim(ClaimTypes.Role, "administrator"));
            });

            return services;
        }
    }
}