﻿// <auto-generated />
using System;
using HipHopPizzaAndWangs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HipHopPizzaAndWangs.Migrations
{
    [DbContext(typeof(HipHopPizzaDbContext))]
    partial class HipHopPizzaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HipHopPizzaAndWangs.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PaymentTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PaymentTypeId = 1,
                            StatusId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("HipHopPizzaAndWangs.Models.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Cash"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Debit Card"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Credit Card"
                        },
                        new
                        {
                            Id = 4,
                            Type = "Apple Pay"
                        });
                });

            modelBuilder.Entity("HipHopPizzaAndWangs.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImgUrl = "https://sipbitego.com/wp-content/uploads/2021/08/Pepperoni-Pizza-Recipe-Sip-Bite-Go.jpg",
                            Name = "Pepperoni Pizza",
                            Price = 24.99m
                        },
                        new
                        {
                            Id = 2,
                            ImgUrl = "https://www.jessicagavin.com/wp-content/uploads/2020/07/hawaiian-pizza-16-1200.jpg",
                            Name = "Pineapple Pizza",
                            Price = 24.99m
                        },
                        new
                        {
                            Id = 3,
                            ImgUrl = "https://californiaranchmarket.com/cdn/shop/products/000355_568234ca-45de-49f0-9e9c-65127b46be21.jpg?v=1680240542",
                            Name = "Dr. Pepper",
                            Price = 3.99m
                        },
                        new
                        {
                            Id = 4,
                            ImgUrl = "https://mccormick.widen.net/content/n0phdkxdlp/jpeg/Franks_RedHot_Buffalo_Chicken_Wings.jpg?crop=true&anchor=0,0&q=80&color=ffffffff&u=qtpeo3&w=800&h=800",
                            Name = "Hot Buffalo Wings",
                            Price = 15.99m
                        });
                });

            modelBuilder.Entity("HipHopPizzaAndWangs.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("StatusType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            StatusType = "Open"
                        },
                        new
                        {
                            Id = 2,
                            StatusType = "Closed"
                        });
                });

            modelBuilder.Entity("HipHopPizzaAndWangs.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "maddi@email.com",
                            Password = "password",
                            Uid = "123"
                        });
                });

            modelBuilder.Entity("HipHopPizzaAndWangs.Models.Product", b =>
                {
                    b.HasOne("HipHopPizzaAndWangs.Models.Order", null)
                        .WithMany("products")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("HipHopPizzaAndWangs.Models.Order", b =>
                {
                    b.Navigation("products");
                });
#pragma warning restore 612, 618
        }
    }
}