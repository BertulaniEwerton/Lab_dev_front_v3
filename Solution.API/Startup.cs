using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using Solution.IOC;

using System;
using System.IO;
using System.Reflection;

namespace Solution.API
{
    public class Startup
    {
        private readonly IHostEnvironment env;
        private static string GetPathOfXmlFromAssembly() => Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");

        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            Configuration = configuration;
            this.env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Laboratorio de desenvolvimento",
                    Contact = new OpenApiContact
                    {
                        Name = "Arlan Mendes",
                        Url = new Uri("https://www.linkedin.com/in/arlan-mendes-b190a717b/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Repositorio",
                        Url = new Uri("https://dev.azure.com/juliariguete/Back-end%20Team/_git/api"),
                    }
                });
                c.IncludeXmlComments(GetPathOfXmlFromAssembly());
            });
            NativeInjectorBootStrapper.InjectServices(services, Configuration, env);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Solution.API v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
