﻿// <auto-generated />
using System;
using DotnetAngularWebProject.WeatherForecast.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DotnetAngularWebProject.WeatherForecast.Data.Migrations
{
    [DbContext(typeof(ModuleDbContext))]
    partial class ModuleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("DotnetAngularWebProject.WeatherForecast.Domain.Model", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TemperatureC")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("WeatherForecasts");
                });
#pragma warning restore 612, 618
        }
    }
}
