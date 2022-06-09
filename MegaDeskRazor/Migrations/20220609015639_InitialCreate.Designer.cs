﻿// <auto-generated />
using System;
using MegaDeskRazor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MegaDeskRazor.Migrations
{
    [DbContext(typeof(MegaDeskRazorContext))]
    [Migration("20220609015639_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MegaDeskRazor.DeliveryType", b =>
                {
                    b.Property<int>("DeliveryTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DeliveryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PriceBetween1000And2000")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PriceOver2000")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PriceUnder1000")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("DeliveryTypeId");

                    b.ToTable("DeliveryType");
                });

            modelBuilder.Entity("MegaDeskRazor.Desk", b =>
                {
                    b.Property<int>("DeskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Depth")
                        .HasColumnType("int");

                    b.Property<int>("DesktopMaterialId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfDrawers")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("DeskId");

                    b.ToTable("Desk");
                });

            modelBuilder.Entity("MegaDeskRazor.DeskQuote", b =>
                {
                    b.Property<int>("DeskQuoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeliveryTypeId")
                        .HasColumnType("int");

                    b.Property<int>("DeskId")
                        .HasColumnType("int");

                    b.Property<DateTime>("QuoteDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("QuotePrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("DeskQuoteId");

                    b.HasIndex("DeliveryTypeId");

                    b.HasIndex("DeskId");

                    b.ToTable("DeskQuote");
                });

            modelBuilder.Entity("MegaDeskRazor.DeskQuote", b =>
                {
                    b.HasOne("MegaDeskRazor.DeliveryType", "DeliveryType")
                        .WithMany()
                        .HasForeignKey("DeliveryTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MegaDeskRazor.Desk", "Desk")
                        .WithMany()
                        .HasForeignKey("DeskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
