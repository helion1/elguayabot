using ElGuayabot.Common.Pipeline;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ElGuayabot.Common.Configuration
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddPipelines(this IServiceCollection services, IConfiguration configuration)
        {
//            services.AddMediatR();
//            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            
            return services;
        }
    }
}