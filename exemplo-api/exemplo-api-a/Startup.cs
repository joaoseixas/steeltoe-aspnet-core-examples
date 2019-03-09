using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using exemplo_api_a.HealthContributors;
using exemplo_api_a.HystrixCommands;
using exemplo_api_a.InfoContributors;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Steeltoe.CircuitBreaker.Hystrix;
using Steeltoe.Common.HealthChecks;
using Steeltoe.Common.Http.Discovery;
using Steeltoe.Discovery.Client;
using Steeltoe.Management.Endpoint.Env;
using Steeltoe.Management.Endpoint.Health;
using Steeltoe.Management.Endpoint.Info;
using Steeltoe.Management.Endpoint.Info.Contributor;
using Steeltoe.Management.Endpoint.Loggers;
using Steeltoe.Management.Endpoint.Mappings;
using Steeltoe.Management.Endpoint.Metrics;
using Steeltoe.Management.Endpoint.Refresh;
using Steeltoe.Management.Endpoint.Trace;
using Swashbuckle.AspNetCore.Swagger;

namespace exemplo_api_a
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add your own IHealthContributor, registered with the interface
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddTransient<DiscoveryHttpMessageHandler>();
            // Configure a HttpClient
            services.AddHttpClient("api-b", c =>
            {
                c.BaseAddress = new Uri("http://api-b");
            })
            .AddHttpMessageHandler<DiscoveryHttpMessageHandler>();

            services.AddDiscoveryClient(Configuration);

            services.AddHystrixCommand<ApiBCallCommand>("ApiBCallGroup", Configuration);
            services.AddHystrixMetricsStream(Configuration);


            // Add your own IHealthContributor, registered with the interface
            services.AddSingleton<IHealthContributor, ApiBCheck>();
            services.AddSingleton<IInfoContributor, InfoSomeValue>();

            services.AddHealthActuator(Configuration);
            services.AddInfoActuator(Configuration);
            services.AddLoggersActuator(Configuration);
            services.AddTraceActuator(Configuration);
            services.AddRefreshActuator(Configuration);
            services.AddEnvActuator(Configuration);
            services.AddMappingsActuator(Configuration);
            services.AddMetricsActuator(Configuration);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                c.DescribeAllEnumsAsStrings(); // this will do the trick
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            var rewrite = new RewriteOptions()
                .AddRewrite("actuator/env", "env", true)
                .AddRewrite("actuator/health", "health", true)
                .AddRewrite("actuator/trace", "trace", true)
                .AddRewrite("actuator/info", "info", true);

            app.UseRewriter(rewrite);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            // Use Hystrix Request contexts
            app.UseHystrixRequestContext();

            app.UseMvc();

            // Use the Steeltoe Discovery Client service
            app.UseDiscoveryClient();

            app.UseHystrixMetricsStream();

            app.UseHealthActuator();
            app.UseInfoActuator();
            app.UseLoggersActuator();
            app.UseTraceActuator();
            app.UseRefreshActuator();
            app.UseEnvActuator();
            app.UseMappingsActuator();
            app.UseMetricsActuator();
        }
    }
}
