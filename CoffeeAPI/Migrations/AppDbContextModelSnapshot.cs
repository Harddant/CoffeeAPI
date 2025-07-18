﻿// <auto-generated />
using System;
using CoffeeAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoffeeAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.4");

            modelBuilder.Entity("CoffeeAPI.Models.Coffee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Coffees");
                });

            modelBuilder.Entity("CoffeeAPI.Models.CoffeeIngredient", b =>
                {
                    b.Property<int>("CoffeeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IngredientId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CoffeeId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("CoffeeIngredients");
                });

            modelBuilder.Entity("CoffeeAPI.Models.CoffeeOfTheDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CoffeeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CoffeeId");

                    b.ToTable("CoffeeOfTheDay");
                });

            modelBuilder.Entity("CoffeeAPI.Models.CoffeeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CoffeeTypes");
                });

            modelBuilder.Entity("CoffeeAPI.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CoffeeAPI.Models.Coffee", b =>
                {
                    b.HasOne("CoffeeAPI.Models.CoffeeType", "Type")
                        .WithMany("Coffees")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("CoffeeAPI.Models.CoffeeIngredient", b =>
                {
                    b.HasOne("CoffeeAPI.Models.Coffee", "Coffee")
                        .WithMany("CoffeeIngredients")
                        .HasForeignKey("CoffeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoffeeAPI.Models.Ingredient", "Ingredient")
                        .WithMany("CoffeeIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coffee");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("CoffeeAPI.Models.CoffeeOfTheDay", b =>
                {
                    b.HasOne("CoffeeAPI.Models.Coffee", "Coffee")
                        .WithMany()
                        .HasForeignKey("CoffeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coffee");
                });

            modelBuilder.Entity("CoffeeAPI.Models.Coffee", b =>
                {
                    b.Navigation("CoffeeIngredients");
                });

            modelBuilder.Entity("CoffeeAPI.Models.CoffeeType", b =>
                {
                    b.Navigation("Coffees");
                });

            modelBuilder.Entity("CoffeeAPI.Models.Ingredient", b =>
                {
                    b.Navigation("CoffeeIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}
