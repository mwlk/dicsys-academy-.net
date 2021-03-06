using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Services;
using System;
using System.IO;
using System.Reflection;

namespace WebApi
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
            services.AddControllers();

            //add swagger
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1.1", new OpenApiInfo { Title = "Pizzeria API", Version = "v1.1" });

                var xmlFile = $"{ Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                doc.IncludeXmlComments(xmlPath);
            });

            //agregar servicios
            services.AddScoped<DetallePedidoService>();
            services.AddScoped<FacturaService>();
            services.AddScoped<IngredienteService>();
            services.AddScoped<PedidoService>();
            services.AddScoped<PizzaService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //configure swagger
            app.UseSwagger();

            app.UseSwaggerUI( s =>
            {
                s.SwaggerEndpoint("/swagger/v1.1/swagger.json", "WebApi Dicsys Academy");
                s.RoutePrefix = string.Empty;
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
