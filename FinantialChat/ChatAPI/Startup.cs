using ChatAPI.Authentication;
using ChatAPI.RabbitMQ;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace ChatAPI {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();

            MongoDbContext.Configuration = Configuration.GetSection("MongoConnection").Get<MongoDbConfiguration>();

            services.AddDbContext<ChatUsersDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddIdentity<ChatUser, IdentityRole>()
                .AddEntityFrameworkStores<ChatUsersDbContext>()
                .AddDefaultTokenProviders();

            services.AddSwaggerGen(o =>
                o.SwaggerDoc("v1", new OpenApiInfo { Title = "Chat Api", Version = "v1" }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if(env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(o => o
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(o => o.SwaggerEndpoint("/swagger/v1/swagger.json", "Chat Api V1"));

            app.UseWebSockets();
            app.UseMiddleware<ChatWebSocketMiddleware>();

        }
    }
}
