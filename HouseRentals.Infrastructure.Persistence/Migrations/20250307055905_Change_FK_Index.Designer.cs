﻿// <auto-generated />
using System;
using HouseRentals.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HouseRentals.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250307055905_Change_FK_Index")]
    partial class Change_FK_Index
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HouseRentals.Core.Domain.Entities.House", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("DailyPrice")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValueSql("0");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ImageFileName")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("NumberOfRooms")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.HasKey("Id");

                    b.ToTable("House", (string)null);
                });

            modelBuilder.Entity("HouseRentals.Core.Domain.Entities.Rental", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<decimal>("Discount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(8,2)")
                        .HasDefaultValueSql("0");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<long>("HouseId")
                        .HasColumnType("bigint");

                    b.Property<string>("Observation")
                        .HasColumnType("varchar(500)");

                    b.Property<bool>("RentPaid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<DateTime?>("RentPaymentDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<long>("TenantId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("TotalPrice")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(8,2)")
                        .HasDefaultValueSql("0");

                    b.Property<decimal>("TotalToPay")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(8,2)")
                        .HasDefaultValueSql("0");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.HasIndex("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("Rental", (string)null);
                });

            modelBuilder.Entity("HouseRentals.Core.Domain.Entities.Tenant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("char(11)");

                    b.HasKey("Id");

                    b.ToTable("Tenant", (string)null);
                });

            modelBuilder.Entity("HouseRentals.Core.Domain.Entities.Rental", b =>
                {
                    b.HasOne("HouseRentals.Core.Domain.Entities.House", "House")
                        .WithMany("Rentals")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Rental_House_HouseId");

                    b.HasOne("HouseRentals.Core.Domain.Entities.Tenant", "Tenant")
                        .WithMany("Rentals")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Rental_Tenant_TenantId");

                    b.Navigation("House");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("HouseRentals.Core.Domain.Entities.House", b =>
                {
                    b.Navigation("Rentals");
                });

            modelBuilder.Entity("HouseRentals.Core.Domain.Entities.Tenant", b =>
                {
                    b.Navigation("Rentals");
                });
#pragma warning restore 612, 618
        }
    }
}
