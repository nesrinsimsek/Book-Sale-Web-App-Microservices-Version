﻿// <auto-generated />
using System;
using BookSale.MVC.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookSale.MVC.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookSale.MVC.Models.ApiRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("BookSale.MVC.Models.ApiResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ResponseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Responses");
                });

            modelBuilder.Entity("BookSale.MVC.Models.ApiRequest", b =>
                {
                    b.OwnsOne("object", "Data", b1 =>
                        {
                            b1.Property<int>("ApiRequestId")
                                .HasColumnType("int");

                            b1.HasKey("ApiRequestId");

                            b1.ToTable("Requests");

                            b1.ToJson("Data");

                            b1.WithOwner()
                                .HasForeignKey("ApiRequestId");
                        });

                    b.Navigation("Data");
                });

            modelBuilder.Entity("BookSale.MVC.Models.ApiResponse", b =>
                {
                    b.OwnsOne("object", "Data", b1 =>
                        {
                            b1.Property<int>("ApiResponseId")
                                .HasColumnType("int");

                            b1.HasKey("ApiResponseId");

                            b1.ToTable("Responses");

                            b1.ToJson("Data");

                            b1.WithOwner()
                                .HasForeignKey("ApiResponseId");
                        });

                    b.Navigation("Data");
                });
#pragma warning restore 612, 618
        }
    }
}
