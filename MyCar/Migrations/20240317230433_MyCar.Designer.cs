﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyCar.Context;

namespace MyCar.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240317230433_MyCar")]
    partial class MyCar
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyCar.Models.AdvertisingModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarModelId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarModelId")
                        .IsUnique();

                    b.HasIndex("UserModelId")
                        .IsUnique();

                    b.ToTable("Advertisings");
                });

            modelBuilder.Entity("MyCar.Models.CarAcessoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Acessory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarModelId");

                    b.ToTable("CarAcessories");
                });

            modelBuilder.Entity("MyCar.Models.CarLocationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarModelId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarModelId");

                    b.ToTable("CarLocations");
                });

            modelBuilder.Entity("MyCar.Models.CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CRV")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarDoorAmount")
                        .HasColumnType("int");

                    b.Property<string>("CarSeatLiner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fuel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<decimal>("Mileage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Plate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Transmission")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Version")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId")
                        .IsUnique()
                        .HasFilter("[LocationId] IS NOT NULL");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("MyCar.Models.CarPhotoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarModelId")
                        .HasColumnType("int");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarModelId");

                    b.ToTable("CarPhotos");
                });

            modelBuilder.Entity("MyCar.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyCar.Models.UserRegisterModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacePhoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserModelId")
                        .IsUnique();

                    b.ToTable("UserRegisters");
                });

            modelBuilder.Entity("MyCar.Models.AdvertisingModel", b =>
                {
                    b.HasOne("MyCar.Models.CarModel", "CarModel")
                        .WithOne("Advertising")
                        .HasForeignKey("MyCar.Models.AdvertisingModel", "CarModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyCar.Models.UserModel", "UserModel")
                        .WithOne("AdvertisingModel")
                        .HasForeignKey("MyCar.Models.AdvertisingModel", "UserModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarModel");

                    b.Navigation("UserModel");
                });

            modelBuilder.Entity("MyCar.Models.CarAcessoryModel", b =>
                {
                    b.HasOne("MyCar.Models.CarModel", "CarModel")
                        .WithMany("CarAcessories")
                        .HasForeignKey("CarModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarModel");
                });

            modelBuilder.Entity("MyCar.Models.CarLocationModel", b =>
                {
                    b.HasOne("MyCar.Models.CarModel", "CarModel")
                        .WithMany()
                        .HasForeignKey("CarModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarModel");
                });

            modelBuilder.Entity("MyCar.Models.CarModel", b =>
                {
                    b.HasOne("MyCar.Models.CarLocationModel", "CarLocationModel")
                        .WithOne()
                        .HasForeignKey("MyCar.Models.CarModel", "LocationId");

                    b.Navigation("CarLocationModel");
                });

            modelBuilder.Entity("MyCar.Models.CarPhotoModel", b =>
                {
                    b.HasOne("MyCar.Models.CarModel", "CarModel")
                        .WithMany("CarPhotos")
                        .HasForeignKey("CarModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarModel");
                });

            modelBuilder.Entity("MyCar.Models.UserRegisterModel", b =>
                {
                    b.HasOne("MyCar.Models.UserModel", "UserModel")
                        .WithOne("UserRegisterModel")
                        .HasForeignKey("MyCar.Models.UserRegisterModel", "UserModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserModel");
                });

            modelBuilder.Entity("MyCar.Models.CarModel", b =>
                {
                    b.Navigation("Advertising");

                    b.Navigation("CarAcessories");

                    b.Navigation("CarPhotos");
                });

            modelBuilder.Entity("MyCar.Models.UserModel", b =>
                {
                    b.Navigation("AdvertisingModel");

                    b.Navigation("UserRegisterModel");
                });
#pragma warning restore 612, 618
        }
    }
}
