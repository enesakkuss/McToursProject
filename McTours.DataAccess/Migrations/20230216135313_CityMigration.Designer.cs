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
    [Migration("20230216135313_CityMigration")]
    partial class CityMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("McTours.Domain.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("City", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Adana"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Adıyaman"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Afyonkarahisar"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Ağrı	"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Amasya	"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Ankara	"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Antalya	"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Artvin	"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Aydın	"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Balıkesir	"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Bilecik	"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Bingöl	"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Bitlis	"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Bolu	"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Burdur	"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Bursa	"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Çanakkale	"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Çankırı	"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Çorum	"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Denizli	"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Diyarbakır	"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Edirne	"
                        },
                        new
                        {
                            Id = 23,
                            Name = "Elazığ	"
                        },
                        new
                        {
                            Id = 24,
                            Name = "Erzincan	"
                        },
                        new
                        {
                            Id = 25,
                            Name = "Erzurum	"
                        },
                        new
                        {
                            Id = 26,
                            Name = "Eskişehir	"
                        },
                        new
                        {
                            Id = 27,
                            Name = "Gaziantep	"
                        },
                        new
                        {
                            Id = 28,
                            Name = "Giresun	"
                        },
                        new
                        {
                            Id = 29,
                            Name = "Gümüşhane	"
                        },
                        new
                        {
                            Id = 30,
                            Name = "Hakkari	"
                        },
                        new
                        {
                            Id = 31,
                            Name = "Hatay	"
                        },
                        new
                        {
                            Id = 32,
                            Name = "Isparta	"
                        },
                        new
                        {
                            Id = 33,
                            Name = "Mersin	"
                        },
                        new
                        {
                            Id = 34,
                            Name = "İstanbul	"
                        },
                        new
                        {
                            Id = 35,
                            Name = "İzmir	"
                        },
                        new
                        {
                            Id = 36,
                            Name = "Kars	"
                        },
                        new
                        {
                            Id = 37,
                            Name = "Kastamonu	"
                        },
                        new
                        {
                            Id = 38,
                            Name = "Kayseri	"
                        },
                        new
                        {
                            Id = 39,
                            Name = "Kırklareli	"
                        },
                        new
                        {
                            Id = 40,
                            Name = "Kırşehir	"
                        },
                        new
                        {
                            Id = 41,
                            Name = "Kocaeli	"
                        },
                        new
                        {
                            Id = 42,
                            Name = "Konya	"
                        },
                        new
                        {
                            Id = 43,
                            Name = "Kütahya	"
                        },
                        new
                        {
                            Id = 44,
                            Name = "Malatya	"
                        },
                        new
                        {
                            Id = 45,
                            Name = "Manisa	"
                        },
                        new
                        {
                            Id = 46,
                            Name = "Kahramanmaraş	"
                        },
                        new
                        {
                            Id = 47,
                            Name = "Mardin	"
                        },
                        new
                        {
                            Id = 48,
                            Name = "Muğla	"
                        },
                        new
                        {
                            Id = 49,
                            Name = "Muş	"
                        },
                        new
                        {
                            Id = 50,
                            Name = "Nevşehir	"
                        },
                        new
                        {
                            Id = 51,
                            Name = "Niğde	"
                        },
                        new
                        {
                            Id = 52,
                            Name = "Ordu	"
                        },
                        new
                        {
                            Id = 53,
                            Name = "Rize	"
                        },
                        new
                        {
                            Id = 54,
                            Name = "Sakarya	"
                        },
                        new
                        {
                            Id = 55,
                            Name = "Samsun	"
                        },
                        new
                        {
                            Id = 56,
                            Name = "Siirt	"
                        },
                        new
                        {
                            Id = 57,
                            Name = "Sinop	"
                        },
                        new
                        {
                            Id = 58,
                            Name = "Sivas	"
                        },
                        new
                        {
                            Id = 59,
                            Name = "Tekirdağ	"
                        },
                        new
                        {
                            Id = 60,
                            Name = "Tokat	"
                        },
                        new
                        {
                            Id = 61,
                            Name = "Trabzon	"
                        },
                        new
                        {
                            Id = 62,
                            Name = "Tunceli	"
                        },
                        new
                        {
                            Id = 63,
                            Name = "Şanlıurfa	"
                        },
                        new
                        {
                            Id = 64,
                            Name = "Uşak	"
                        },
                        new
                        {
                            Id = 65,
                            Name = "Van	"
                        },
                        new
                        {
                            Id = 66,
                            Name = "Yozgat	"
                        },
                        new
                        {
                            Id = 67,
                            Name = "Zonguldak	"
                        },
                        new
                        {
                            Id = 68,
                            Name = "Aksaray	"
                        },
                        new
                        {
                            Id = 69,
                            Name = "Bayburt	"
                        },
                        new
                        {
                            Id = 70,
                            Name = "Karaman	"
                        },
                        new
                        {
                            Id = 71,
                            Name = "Kırıkkale	"
                        },
                        new
                        {
                            Id = 72,
                            Name = "Batman	"
                        },
                        new
                        {
                            Id = 73,
                            Name = "Şırnak	"
                        },
                        new
                        {
                            Id = 74,
                            Name = "Bartın	"
                        },
                        new
                        {
                            Id = 75,
                            Name = "Ardahan	"
                        },
                        new
                        {
                            Id = 76,
                            Name = "Iğdır	"
                        },
                        new
                        {
                            Id = 77,
                            Name = "Yalova	"
                        },
                        new
                        {
                            Id = 78,
                            Name = "Karabük	"
                        },
                        new
                        {
                            Id = 79,
                            Name = "Kilis	"
                        },
                        new
                        {
                            Id = 80,
                            Name = "Osmaniye	"
                        },
                        new
                        {
                            Id = 81,
                            Name = "Düzce	"
                        });
                });

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
