using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MyCar.Context;
using MyCar.ConvertData;
using MyCar.ConvertData.Interface;
using MyCar.DTOs;
using MyCar.Services;
using MyCar.Services.Interfaces;
using System;

namespace MyCar
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyCar", Version = "v1" });
            });
            services.AddCors(option =>
            {
                option.AddPolicy("MyPolicy", builder =>
                {
                    builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
                });
            });

            //FOR SSMS
            /*services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ServerConnection"));
            });*/


            //FOR MySQL
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySql(Configuration["MySQLConnection:MySQLServerConnection"], new MySqlServerVersion(new Version(11, 2, 2)),
                    mysqlOptions =>
                    {
                        mysqlOptions.EnableRetryOnFailure();
                    });
            });
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAdvertisingService, AdvertisingService>();
            services.AddScoped<ICarAcessoriesService, CarAcessoriesService>();
            services.AddScoped<ICarLocationService, CarLocationService>();
            services.AddScoped<ICarPhotosService, CarPhotosService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ISerialization<EmailDTO>, Serialization<EmailDTO>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyCar v1"));

            }

            app.UseHttpsRedirection();
            app.UseCors("MyPolicy");

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
