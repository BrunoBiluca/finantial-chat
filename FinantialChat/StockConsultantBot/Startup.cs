using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.VisualStudio.Web.CodeGeneration;
using System;

namespace StockConsultantBot {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();

            services.AddSwaggerGen(o =>
                o.SwaggerDoc("v1", new OpenApiInfo { Title = "Stock Consultant Bot", Version = "v1" }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory) {
            if(env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });

            app.UseCors(o => o
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.UseSwagger();
            app.UseSwaggerUI(o => o.SwaggerEndpoint("/swagger/v1/swagger.json", "Chat Api V1"));

            var logger = loggerFactory.CreateLogger<ConsoleLogger>();
            logger.LogInformation("##################################################################################");
            logger.LogInformation($"####   Executing Configure().... {DateTime.Now.ToLongTimeString()}");
            logger.LogInformation("##################################################################################");
        }
    }
}
