﻿// <auto-generated />
using System;
using CiberSystem.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CiberSystem.Migrations
{
    [DbContext(typeof(CiBerDbContext))]
    [Migration("20230214101000_AddItem")]
    partial class AddItem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("CiberSystem.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Điện Thoại"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Máy Tính"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Laptop"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Phụ Kiện"
                        });
                });

            modelBuilder.Entity("CiberSystem.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Pass")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Phú thọ",
                            Name = "Tuấn",
                            Pass = "abcd1234",
                            Phone = "0353590123"
                        },
                        new
                        {
                            Id = 2,
                            Address = "China",
                            Name = "Trang",
                            Pass = "abcd1234@",
                            Phone = "0888888880"
                        });
                });

            modelBuilder.Entity("CiberSystem.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OverDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CiberSystem.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryID = 1,
                            Description = "the description of Galaxy S23 Series",
                            Name = "Galaxy S23 Series",
                            Price = 100000m,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 2,
                            CategoryID = 1,
                            Description = "the description of Xiaomi Redmi 10A 3GB-64GB",
                            Name = "Xiaomi Redmi 10A 3GB-64GB",
                            Price = 100000m,
                            Quantity = 20
                        },
                        new
                        {
                            Id = 3,
                            CategoryID = 3,
                            Description = "the description of Laptop Asus TUF Gaming FX506LHB",
                            Name = "Laptop Asus TUF Gaming FX506LHB",
                            Price = 100000m,
                            Quantity = 20
                        },
                        new
                        {
                            Id = 4,
                            CategoryID = 3,
                            Description = "the description of Laptop MSI Gaming GF63",
                            Name = "Laptop MSI Gaming GF63",
                            Price = 100000m,
                            Quantity = 20
                        },
                        new
                        {
                            Id = 5,
                            CategoryID = 2,
                            Description = "the description of iPad Gen 9 2021",
                            Name = "iPad Gen 9 2021",
                            Price = 100000m,
                            Quantity = 20
                        },
                        new
                        {
                            Id = 6,
                            CategoryID = 1,
                            Description = "the description of Samsung Galaxy Z Fold3",
                            Name = "Samsung Galaxy Z Fold3",
                            Price = 1000000m,
                            Quantity = 20
                        },
                        new
                        {
                            Id = 7,
                            CategoryID = 2,
                            Description = "the description of iPad mini 6",
                            Name = "iPad mini 6",
                            Price = 100000m,
                            Quantity = 20
                        },
                        new
                        {
                            Id = 8,
                            CategoryID = 3,
                            Description = "the description of Laptop MSI Modern 14",
                            Name = "Laptop MSI Modern 14",
                            Price = 100000m,
                            Quantity = 20
                        },
                        new
                        {
                            Id = 9,
                            CategoryID = 4,
                            Description = "the description of Laptop MSI Gaming GF63",
                            Name = "Laptop MSI Gaming GF63",
                            Price = 100000m,
                            Quantity = 20
                        });
                });

            modelBuilder.Entity("CiberSystem.Entities.Order", b =>
                {
                    b.HasOne("CiberSystem.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CiberSystem.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CiberSystem.Entities.Product", b =>
                {
                    b.HasOne("CiberSystem.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
