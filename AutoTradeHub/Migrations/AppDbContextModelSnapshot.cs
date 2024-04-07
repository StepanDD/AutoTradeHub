﻿// <auto-generated />
using AutoTradeHub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutoTradeHub.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AutoTradeHub.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ColorId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("EnginePower")
                        .HasColumnType("integer");

                    b.Property<double>("EngineVolume")
                        .HasColumnType("double precision");

                    b.Property<byte>("Gearbox")
                        .HasColumnType("smallint");

                    b.Property<int>("MarkaId")
                        .HasColumnType("integer");

                    b.Property<int>("ModelId")
                        .HasColumnType("integer");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<bool>("SteeringWheel")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.HasIndex("MarkaId");

                    b.HasIndex("ModelId");

                    b.ToTable("cars");
                });

            modelBuilder.Entity("AutoTradeHub.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("colors");
                });

            modelBuilder.Entity("AutoTradeHub.Models.Marka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("marks");
                });

            modelBuilder.Entity("AutoTradeHub.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("MarkaId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MarkaId");

                    b.ToTable("models");
                });

            modelBuilder.Entity("AutoTradeHub.Models.Car", b =>
                {
                    b.HasOne("AutoTradeHub.Models.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoTradeHub.Models.Marka", "Marka")
                        .WithMany()
                        .HasForeignKey("MarkaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoTradeHub.Models.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Marka");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("AutoTradeHub.Models.Model", b =>
                {
                    b.HasOne("AutoTradeHub.Models.Marka", "Marka")
                        .WithMany()
                        .HasForeignKey("MarkaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marka");
                });
#pragma warning restore 612, 618
        }
    }
}
