using AspNet.Essentials.Workshop.Abstractions;
using AspNet.Essentials.Workshop.Configuration;
using AspNet.Essentials.Workshop.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace AspNet.Essentials.Workshop
{
    public class Startup
    {
        IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "IEvangelist.VideoChat", Version = "v1" });
            });

            services.Configure<BrewerySettings>(
                Configuration.GetSection(nameof(BrewerySettings)));

            services.AddHttpClient<IBreweryClient, BreweryClient>((svc, client) =>
            {
                var options = svc.GetService<IOptions<BrewerySettings>>();
                client.BaseAddress = options?.Value?.BaseUrl;
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            IApplicationLifetime lifetime,
            ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            lifetime.ApplicationStarted.Register(o => OnStarted(o as ILogger<Startup>), logger);
            lifetime.ApplicationStopping.Register(o => OnStopping(o as ILogger<Startup>), logger);
            lifetime.ApplicationStopped.Register(o => OnStopped(o as ILogger<Startup>), logger);

            app.UseHttpsRedirection()
               .UseSwagger()
               .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ASP.NET Core Essentials - API v1"));

            app.UseMvc();
        }

        void OnStarted(ILogger<Startup> logger)
        {
            // Perform post-startup activities here
        }

        void OnStopping(ILogger<Startup> logger)
        {
            // Perform on-stopping activities here
        }

        void OnStopped(ILogger<Startup> logger)
        {
            // Perform post-stopped activities here
        }
    }
}