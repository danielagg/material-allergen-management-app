﻿// <auto-generated />
using System;
using MAM.Inventory.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MAM.Inventory.Infrastructure.DatabaseMigrations
{
    [DbContext(typeof(InventoryDbContext))]
    partial class InventoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0-preview.2.23128.3");

            modelBuilder.Entity("MAM.Inventory.Domain.Stock", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("CurrentAvailableStock")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaterialId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("MAM.Inventory.Domain.Stock", b =>
                {
                    b.OwnsOne("MAM.Inventory.Domain.UnitOfMeasure", "UnitOfMeasure", b1 =>
                        {
                            b1.Property<string>("StockId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Code")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("StockId");

                            b1.ToTable("Stocks");

                            b1.WithOwner()
                                .HasForeignKey("StockId");
                        });

                    b.Navigation("UnitOfMeasure")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
