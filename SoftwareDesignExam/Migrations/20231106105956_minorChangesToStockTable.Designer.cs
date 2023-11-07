﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoftwareDesignExam.DataAccess.SqLite;

#nullable disable

namespace SoftwareDesignExam.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20231106105956_minorChangesToStockTable")]
    partial class minorChangesToStockTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("SoftwareDesignExam.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cart_Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cart_Item_Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("UserId");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("SoftwareDesignExam.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Item_Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Item_Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Item_Price")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("SoftwareDesignExam.Entities.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Item_Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Item_Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Item_Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("SoftwareDesignExam.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("User_Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("User_FName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("User_LName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("User_Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("SoftwareDesignExam.Entities.Cart", b =>
                {
                    b.HasOne("SoftwareDesignExam.Entities.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftwareDesignExam.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
