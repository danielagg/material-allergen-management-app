﻿// <auto-generated />
using System;
using MaterialAllergenManagementApp.Allergens.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MaterialAllergenManagementApp.Allergens.Infrastructure.DatabaseMigrations
{
    [DbContext(typeof(AllergensDbContext))]
    [Migration("20230902204459_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("allergens")
                .HasAnnotation("ProductVersion", "8.0.0-preview.2.23128.3");

            modelBuilder.Entity("MaterialAllergenManagementApp.Allergens.MaterialAllergenAggregate", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<bool>("AllergenByCrossContamination")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AllergenByNature")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MaterialAllergens", "allergens");
                });
#pragma warning restore 612, 618
        }
    }
}