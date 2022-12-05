﻿// <auto-generated />
using System;
using Hotel.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hotel.DataLayer.Migrations
{
    [DbContext(typeof(HotelContext))]
    partial class HotelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Hotel.DataLayer.Entities.Booking", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("CustomerContactNo")
                        .HasColumnType("bigint");

                    b.Property<string>("CustomerEmailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("NoOfAdults")
                        .HasColumnType("int");

                    b.Property<int>("NoOfChildren")
                        .HasColumnType("int");

                    b.Property<int>("NoOfRooms")
                        .HasColumnType("int");

                    b.Property<long>("RoomTypeId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("Hotel.DataLayer.Entities.ContactUs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("CustomerContactNo")
                        .HasColumnType("bigint");

                    b.Property<string>("CustomerEmailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ContactUs");
                });

            modelBuilder.Entity("Hotel.DataLayer.Entities.RoomType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("AdultCapacity")
                        .HasColumnType("int");

                    b.Property<int>("ChildrenCapacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("NoOfRooms")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ServiceCharges")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("RoomType");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AdultCapacity = 2,
                            ChildrenCapacity = 2,
                            Description = "Breakfast Included",
                            ImagePath = "image/room1.jpg",
                            Name = "Double Delux Room",
                            NoOfRooms = 10L,
                            Price = 250m,
                            ServiceCharges = 15m
                        },
                        new
                        {
                            Id = 2L,
                            AdultCapacity = 2,
                            ChildrenCapacity = 1,
                            Description = "Breakfast Included",
                            ImagePath = "image/room2.jpg",
                            Name = "Single Delux Room",
                            NoOfRooms = 15L,
                            Price = 200m,
                            ServiceCharges = 15m
                        },
                        new
                        {
                            Id = 3L,
                            AdultCapacity = 2,
                            ChildrenCapacity = 0,
                            Description = "Breakfast Included",
                            ImagePath = "image/room3.jpg",
                            Name = "Honeymoon Suit",
                            NoOfRooms = 10L,
                            Price = 750m,
                            ServiceCharges = 15m
                        },
                        new
                        {
                            Id = 4L,
                            AdultCapacity = 2,
                            ChildrenCapacity = 1,
                            Description = "Breakfast Included",
                            ImagePath = "image/room4.jpg",
                            Name = "Economy Double",
                            NoOfRooms = 15L,
                            Price = 200m,
                            ServiceCharges = 15m
                        });
                });

            modelBuilder.Entity("Hotel.DataLayer.Entities.Booking", b =>
                {
                    b.HasOne("Hotel.DataLayer.Entities.RoomType", "RoomType")
                        .WithMany()
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoomType");
                });
#pragma warning restore 612, 618
        }
    }
}
