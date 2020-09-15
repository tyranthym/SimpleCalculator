using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using SimpleCalculator.API.ModelMappers;
using SimpleCalculator.API.Services.Calculation;
using SimpleCalculator.API.Services.Calculation.Strategies.Factory;

namespace SimpleCalculator.API
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
            services.AddCors(option =>
            {
                option.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"); //include all client apps
                });
            });

            // Register the Swagger generator
            services.AddSwaggerGen(c =>
            {
                c.CustomOperationIds(e => $"{e.ActionDescriptor.RouteValues["controller"]}_{e.ActionDescriptor.RouteValues["action"]}");
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Simple Calculator - API",
                    Version = "v1",
                    Description = "Simple Calculator swagger ui"
                });


                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var baseDirectory = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(baseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                // Enable Annotations
                c.EnableAnnotations();
            });
            //add newton support for swagger
            services.AddSwaggerGenNewtonsoftSupport();
  
            //fluent validation
            var assembly = Assembly.GetAssembly(typeof(Startup));
            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(assembly));
                //.AddNewtonsoftJson(options =>
                //{
                //    options.SerializerSettings.Converters.Add(new StringEnumConverter(new CamelCaseNamingStrategy()));
                //});

            //app services
            services.AddSingleton<ICalculationService, CalculationService>();
            services.AddSingleton<ICalculationStrategyFactory, CalculationStrategyFactory>();
            services.AddSingleton<ICalculationMapper, CalculationMapper>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(o =>
            {
                o.RouteTemplate = "docs/{documentName}/docs.json";
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(o =>
            {
                o.DocumentTitle = "Swagger UI - Simple Calculator";
                o.SwaggerEndpoint("/docs/v1/docs.json", "Simple Calculator - API");
                o.RoutePrefix = "docs";
                o.DisplayOperationId();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
