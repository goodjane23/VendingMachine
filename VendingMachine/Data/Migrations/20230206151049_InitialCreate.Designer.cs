﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VendingMachine.Data;

#nullable disable

namespace VendingMachine.Data.Migrations
{
    [DbContext(typeof(VendingDbContext))]
    [Migration("20230206151049_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("VendingMachine.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 6,
                            Amount = (byte)10,
                            Name = "Potion Health",
                            Price = 150,
                            ProductType = 0
                        },
                        new
                        {
                            Id = 1,
                            Amount = (byte)10,
                            Name = "Potion Strength",
                            Price = 200,
                            ProductType = 1
                        },
                        new
                        {
                            Id = 2,
                            Amount = (byte)10,
                            Name = "Potion Agility",
                            Price = 100,
                            ProductType = 2
                        },
                        new
                        {
                            Id = 3,
                            Amount = (byte)10,
                            Name = "Potion Intelligence",
                            Price = 150,
                            ProductType = 3
                        },
                        new
                        {
                            Id = 4,
                            Amount = (byte)10,
                            Name = "Potion Invisibility",
                            Price = 300,
                            ProductType = 4
                        },
                        new
                        {
                            Id = 5,
                            Amount = (byte)10,
                            Name = "Potion Invulnerability",
                            Price = 200,
                            ProductType = 5
                        },
                        new
                        {
                            Id = 10,
                            Amount = (byte)10,
                            Name = "Potion Random",
                            Price = 500,
                            ProductType = 6
                        },
                        new
                        {
                            Id = 7,
                            Amount = (byte)10,
                            Name = "Potion PotionType1",
                            Price = 150,
                            ProductType = 7
                        },
                        new
                        {
                            Id = 8,
                            Amount = (byte)10,
                            Name = "Potion PotionType2",
                            Price = 200,
                            ProductType = 8
                        },
                        new
                        {
                            Id = 9,
                            Amount = (byte)10,
                            Name = "Potion PotionType3",
                            Price = 300,
                            ProductType = 9
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
