﻿// <auto-generated />
using System;
using MAM.Allergens.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MAM.Allergens.Infrastructure.DatabaseMigrations
{
    [DbContext(typeof(AllergensDbContext))]
    [Migration("20230930125633_IntroduceValueObjectForMaterialName")]
    partial class IntroduceValueObjectForMaterialName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("allergens")
                .HasAnnotation("ProductVersion", "8.0.0-preview.2.23128.3");

            modelBuilder.Entity("MAM.Allergens.Domain.Material", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Materials", "allergens");
                });

            modelBuilder.Entity("MAM.Allergens.Domain.MaterialClassification.MaterialType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ApplicableFor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MaterialTypes", "allergens");

                    b.HasData(
                        new
                        {
                            Id = "748ca8d1-9eb3-430b-bea5-1e4ddf585815",
                            ApplicableFor = "RawMaterial;FinishedGood",
                            CreatedOn = new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Food"
                        },
                        new
                        {
                            Id = "6b8898cc-1ec3-4d7d-bd1c-e4d3890056ee",
                            ApplicableFor = "FinishedGood",
                            CreatedOn = new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Beverage"
                        },
                        new
                        {
                            Id = "c61e1dc8-c257-4796-8423-7815051e0ca6",
                            ApplicableFor = "PackagingMaterial",
                            CreatedOn = new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Manufacturer Part"
                        },
                        new
                        {
                            Id = "2cb9838e-8f77-4217-8558-55874ceef8ce",
                            ApplicableFor = "PackagingMaterial",
                            CreatedOn = new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Simple Packaging Material"
                        },
                        new
                        {
                            Id = "9be1b154-8916-4ee7-9878-c00494fb01f2",
                            ApplicableFor = "RawMaterial;FinishedGood;PackagingMaterial",
                            CreatedOn = new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Perishable"
                        });
                });

            modelBuilder.Entity("MAM.Allergens.Domain.Material", b =>
                {
                    b.HasOne("MAM.Allergens.Domain.MaterialClassification.MaterialType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("MAM.Allergens.Domain.AllergenClassification.AllergenByCrossContamination", "AllergensByCrossContamination", b1 =>
                        {
                            b1.Property<string>("MaterialId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Allergens")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("MaterialId");

                            b1.ToTable("Materials", "allergens");

                            b1.WithOwner()
                                .HasForeignKey("MaterialId");
                        });

                    b.OwnsOne("MAM.Allergens.Domain.AllergenClassification.AllergenByNature", "AllergensByNature", b1 =>
                        {
                            b1.Property<string>("MaterialId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Allergens")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("MaterialId");

                            b1.ToTable("Materials", "allergens");

                            b1.WithOwner()
                                .HasForeignKey("MaterialId");
                        });

                    b.OwnsOne("MAM.Allergens.Domain.Inventory.Stock", "Stock", b1 =>
                        {
                            b1.Property<string>("MaterialId")
                                .HasColumnType("TEXT");

                            b1.Property<decimal>("CurrentAvailableStock")
                                .HasColumnType("TEXT");

                            b1.HasKey("MaterialId");

                            b1.ToTable("Materials", "allergens");

                            b1.WithOwner()
                                .HasForeignKey("MaterialId");

                            b1.OwnsOne("MAM.Allergens.Domain.Inventory.UnitOfMeasure", "UnitOfMeasure", b2 =>
                                {
                                    b2.Property<string>("StockMaterialId")
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("Code")
                                        .IsRequired()
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("Name")
                                        .IsRequired()
                                        .HasColumnType("TEXT");

                                    b2.HasKey("StockMaterialId");

                                    b2.ToTable("Materials", "allergens");

                                    b2.WithOwner()
                                        .HasForeignKey("StockMaterialId");
                                });

                            b1.Navigation("UnitOfMeasure")
                                .IsRequired();
                        });

                    b.OwnsOne("MAM.Allergens.Domain.MaterialCode", "Code", b1 =>
                        {
                            b1.Property<string>("MaterialId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("MaterialId");

                            b1.ToTable("Materials", "allergens");

                            b1.WithOwner()
                                .HasForeignKey("MaterialId");
                        });

                    b.OwnsOne("MAM.Allergens.Domain.MaterialName", "Name", b1 =>
                        {
                            b1.Property<string>("MaterialId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("FullName")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("ShortName")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("MaterialId");

                            b1.ToTable("Materials", "allergens");

                            b1.WithOwner()
                                .HasForeignKey("MaterialId");
                        });

                    b.Navigation("AllergensByCrossContamination")
                        .IsRequired();

                    b.Navigation("AllergensByNature")
                        .IsRequired();

                    b.Navigation("Code")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Stock")
                        .IsRequired();

                    b.Navigation("Type");
                });
#pragma warning restore 612, 618
        }
    }
}
