using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ServiceStack.Redis;

namespace pomo_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSingleton<IRedisClientsManager>(new RedisManagerPool("localhost:6379"));
            services.AddTransient<IRedisClient>((ctx) =>
            {
                return ctx.GetService<IRedisClientsManager>().GetClient();
            });
            services.AddTransient<Repositories.TasksRepository, Repositories.TaskRepositoryImplementation>();

            // // Sample di 
            // services.AddScoped<IMyDependency, MyDependency>();
            // services.AddTransient<IOperationTransient, Operation>();
            // services.AddScoped<IOperationScoped, Operation>();
            // services.AddSingleton<IOperationSingleton, Operation>();
            // services.AddSingleton<IOperationSingletonInstance>(new Operation(Guid.Empty));
 
            // // OperationService depends on each of the other Operation types.
            // services.AddTransient<OperationService, OperationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

        }
    }
}
