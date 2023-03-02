﻿// <auto-generated />
using System;
using McTours.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace McTours.DataAccess.Migrations
{
    [DbContext(typeof(McToursContext))]
    [Migration("20230202163910_VehicleMigration")]
    partial class VehicleMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("McTours.Domain.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PlateNumber")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("VehicleDefinitionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleDefinitionId");

                    b.ToTable("Vehicle", (string)null);
                });

            modelBuilder.Entity("McTours.Domain.VehicleDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FuelType")
                        .HasColumnType("int");

                    b.Property<int>("LineCount")
                        .HasColumnType("int");

                    b.Property<int>("SeatingType")
                        .HasColumnType("int");

                    b.Property<int>("Utilities")
                        .HasColumnType("int");

                    b.Property<int>("VehicleModelId")
                        .HasColumnType("int");

                    b.Property<short>("Year")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("VehicleModelId");

                    b.ToTable("VehicleDefinition", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FuelType = 1,
                            LineCount = 20,
                            SeatingType = 1,
                            Utilities = 1,
                            VehicleModelId = 2,
                            Year = (short)2016
                        },
                        new
                        {
                            Id = 2,
                            FuelType = 1,
                            LineCount = 16,
                            SeatingType = 2,
                            Utilities = 31,
                            VehicleModelId = 2,
                            Year = (short)2018
                        },
                        new
                        {
                            Id = 3,
                            FuelType = 1,
                            LineCount = 20,
                            SeatingType = 1,
                            Utilities = 25,
                            VehicleModelId = 3,
                            Year = (short)2017
                        },
                        new
                        {
                            Id = 4,
                            FuelType = 1,
                            LineCount = 16,
                            SeatingType = 2,
                            Utilities = 29,
                            VehicleModelId = 4,
                            Year = (short)2018
                        });
                });

            modelBuilder.Entity("McTours.Domain.VehicleMake", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("VehicleMake", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Neoplan"
                        },
                        new
                        {
                            Id = 2,
                            Name = "MAN"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Mercedes"
                        });
                });

            modelBuilder.Entity("McTours.Domain.VehicleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("VehicleMakeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleMakeId");

                    b.ToTable("VehicleModel", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fortuna",
                            VehicleMakeId = 2
                        },
                        new
                        {
                            Id = 2,
                            Name = "Lions",
                            VehicleMakeId = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "Cityliner",
                            VehicleMakeId = 1
                        },
                        new
                        {
                            Id = 4,
                            Name = "Tourismo",
                            VehicleMakeId = 3
                        },
                        new
                        {
                            Id = 5,
                            Name = "Travego",
                            VehicleMakeId = 3
                        });
                });

            modelBuilder.Entity("McTours.Domain.Vehicle", b =>
                {
                    b.HasOne("McTours.Domain.VehicleDefinition", "VehicleDefinition")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleDefinitionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("VehicleDefinition");
                });

            modelBuilder.Entity("McTours.Domain.VehicleDefinition", b =>
                {
                    b.HasOne("McTours.Domain.VehicleModel", "VehicleModel")
                        .WithMany("VehicleDefinitions")
                        .HasForeignKey("VehicleModelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("VehicleModel");
                });

            modelBuilder.Entity("McTours.Domain.VehicleModel", b =>
                {
                    b.HasOne("McTours.Domain.VehicleMake", "VehicleMake")
                        .WithMany("VehicleModels")
                        .HasForeignKey("VehicleMakeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("VehicleMake");
                });

            modelBuilder.Entity("McTours.Domain.VehicleDefinition", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("McTours.Domain.VehicleMake", b =>
                {
                    b.Navigation("VehicleModels");
                });

            modelBuilder.Entity("McTours.Domain.VehicleModel", b =>
                {
                    b.Navigation("VehicleDefinitions");
                });
#pragma warning restore 612, 618
        }
    }
}