﻿// <auto-generated />
using System;
using DripChip.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DripChip.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DripChip.Core.Entities.Animal", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("ChipperId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ChippingDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("ChippingLocationId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeathDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<float>("Length")
                        .HasColumnType("real");

                    b.Property<string>("LifeStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ChipperId");

                    b.HasIndex("ChippingLocationId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("DripChip.Core.Entities.AnimalLocationPoint", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("LocationPoints");
                });

            modelBuilder.Entity("DripChip.Core.Entities.AnimalType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("AnimalId")
                        .HasColumnType("bigint");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.ToTable("AnimalTypes");
                });

            modelBuilder.Entity("DripChip.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DripChip.Core.Entities.VisitedLocation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("AnimalId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateTimeOfVisitLocationPoint")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("LocationPointId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("LocationPointId");

                    b.ToTable("VisitedLocations");
                });

            modelBuilder.Entity("DripChip.Core.Entities.Animal", b =>
                {
                    b.HasOne("DripChip.Core.Entities.User", "Chipper")
                        .WithMany()
                        .HasForeignKey("ChipperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DripChip.Core.Entities.AnimalLocationPoint", "ChippingLocation")
                        .WithMany()
                        .HasForeignKey("ChippingLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chipper");

                    b.Navigation("ChippingLocation");
                });

            modelBuilder.Entity("DripChip.Core.Entities.AnimalType", b =>
                {
                    b.HasOne("DripChip.Core.Entities.Animal", null)
                        .WithMany("AnimalTypes")
                        .HasForeignKey("AnimalId");
                });

            modelBuilder.Entity("DripChip.Core.Entities.VisitedLocation", b =>
                {
                    b.HasOne("DripChip.Core.Entities.Animal", null)
                        .WithMany("VisitedLocations")
                        .HasForeignKey("AnimalId");

                    b.HasOne("DripChip.Core.Entities.AnimalLocationPoint", "LocationPoint")
                        .WithMany()
                        .HasForeignKey("LocationPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LocationPoint");
                });

            modelBuilder.Entity("DripChip.Core.Entities.Animal", b =>
                {
                    b.Navigation("AnimalTypes");

                    b.Navigation("VisitedLocations");
                });
#pragma warning restore 612, 618
        }
    }
}
