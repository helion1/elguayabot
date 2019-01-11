namespace ElGuayaBot.Api.WebApi.Configuration
{
    internal static class PipelineConfiguration
    {
//        public static IServiceCollection AddCustomPipelines(this IServiceCollection services, IConfiguration configuration, IHostingEnvironment env)
//        {
//            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
//            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
//            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
//            
//            return services;
//        }
//
//        public static IServiceCollection AddMediatRHandlers(this IServiceCollection services, IConfiguration configuration, IHostingEnvironment env)
//        {
//            services.AddMediatR(typeof(CreateApplicationUserCommandHandler).GetTypeInfo().Assembly);
//
//            return services;
//        }
//        
//        public static IServiceCollection AddCustomValidation(this IServiceCollection services, IConfiguration configuration, IHostingEnvironment env)
//        {
//            services.AddMvc()
//                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
//                .AddFluentValidation(fv =>
//                {
//                    fv.RegisterValidatorsFromAssemblyContaining<CreateApplicationUserCommandHandler>();
//                    fv.RegisterValidatorsFromAssemblyContaining<Startup>();
//                });
//            
//            return services;
//        }
//    }
}