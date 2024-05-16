using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MyCar.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyCar.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<CarModel> Cars { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<AdvertisingModel> Advertisings { get; set; }
        public DbSet<CarAcessoryModel> CarAcessories { get; set; }
        public DbSet<CarLocationModel> CarLocations { get; set; }
        public DbSet<CarPhotoModel> CarPhotos { get; set; }
        public DbSet<UserRegisterModel> UserRegisters { get; set; }
        public DbSet<EmailModel> Emails { get; set; }

        //FOR MYSQL
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = WebApplication.CreateBuilder();
            string connectionString = configuration.Configuration["MySQLConnection:MySQLServerConnection"];
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(11, 2, 2)),
                mysqlOptions =>
                {
                    
                    mysqlOptions.EnableRetryOnFailure();
                });
        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MySQLServerConnection"));
        }*/

        //FOR SSMS
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServerConnection"));
        }*/
    }
}
