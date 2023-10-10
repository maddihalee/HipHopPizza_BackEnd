﻿// <auto-generated />
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
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HipHopPizzaAndWangs.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OrderType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PaymentTypeId")
                        .HasColumnType("integer");

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Tip")
                        .HasColumnType("numeric");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PaymentTypeId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "email@email.com",
                            Name = "Madds",
                            OrderType = "Open",
                            PaymentTypeId = 1,
                            Phone = 9094444444L,
                            StatusId = 1,
                            Tip = 2.99m,
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

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

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

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.Property<int>("OrdersId")
                        .HasColumnType("integer");

                    b.Property<int>("productsId")
                        .HasColumnType("integer");

                    b.HasKey("OrdersId", "productsId");

                    b.HasIndex("productsId");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("HipHopPizzaAndWangs.Models.Order", b =>
                {
                    b.HasOne("HipHopPizzaAndWangs.Models.PaymentType", "PaymentType")
                        .WithMany()
                        .HasForeignKey("PaymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HipHopPizzaAndWangs.Models.Status", "Status")
                        .WithMany("Order")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HipHopPizzaAndWangs.Models.User", null)
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentType");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.HasOne("HipHopPizzaAndWangs.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HipHopPizzaAndWangs.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("productsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HipHopPizzaAndWangs.Models.Status", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("HipHopPizzaAndWangs.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
