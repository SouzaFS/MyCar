using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using MyCar.Models;
using System;

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
    }
}
