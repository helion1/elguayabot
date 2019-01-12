using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElGuayaBot.Api.WebApi.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ElGuayaBot.Api.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        
        public IHostingEnvironment Environment { get; }
        
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            services.AddBotBackgroundServices(Configuration, Environment);

            services.AddCustomDependencyInjection(Configuration, Environment);
            
            services.AddCustomPipelines(Configuration, Environment);

            services.AddMediatRHandlers(Configuration, Environment);
            
            services.AddCustomValidation(Configuration, Environment);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
//                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//                app.UseHsts();
            }

//            app.UseHttpsRedirection();
//            app.UseMvc();
        }
    }
}