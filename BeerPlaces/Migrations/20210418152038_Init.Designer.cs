﻿// <auto-generated />
using BeerPlaces.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BeerPlaces.Migrations
{
    [DbContext(typeof(DrinkContext))]
    [Migration("20210418152038_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BeerPlaces.Models.Bar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Calhoun Street, Cincinati",
                            Name = "Uncle Woodys",
                            State = "OH",
                            Zip = "45219"
                        },
                        new
                        {
                            Id = 2,
                            Address = "West Mcmillian, Cincinnati",
                            Name = "Macs",
                            State = "OH",
                            Zip = "45219"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Vine St, Cincinnati",
                            Name = "Top Cats",
                            State = "OH",
                            Zip = "45219"
                        });
                });

            modelBuilder.Entity("BeerPlaces.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Beer"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Wine"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Whiskey"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Seltzer"
                        });
                });

            modelBuilder.Entity("BeerPlaces.Models.Drink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BarId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BarId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Drinks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BarId = 1,
                            CategoryId = 1,
                            Name = "Keystone",
                            Price = 0m
                        },
                        new
                        {
                            Id = 2,
                            BarId = 2,
                            CategoryId = 2,
                            Name = "Cinci Red Wine",
                            Price = 0m
                        },
                        new
                        {
                            Id = 3,
                            BarId = 3,
                            CategoryId = 3,
                            Name = "Cinci Whiskey",
                            Price = 0m
                        });
                });

            modelBuilder.Entity("BeerPlaces.Models.Drink", b =>
                {
                    b.HasOne("BeerPlaces.Models.Bar", "Bar")
                        .WithMany()
                        .HasForeignKey("BarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeerPlaces.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
