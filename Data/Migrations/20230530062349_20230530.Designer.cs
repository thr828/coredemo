﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20230530062349_20230530")]
    partial class _20230530
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("T_ArticleS", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("40827078-33a6-4e20-9f7c-060316edf252"),
                            Author = "jack",
                            CreateTime = new DateTime(2023, 5, 30, 14, 23, 49, 9, DateTimeKind.Local).AddTicks(6154),
                            CreateUser = "admin",
                            Description = "crm",
                            Title = "迅达crm",
                            UpdateTime = new DateTime(2023, 5, 30, 14, 23, 49, 9, DateTimeKind.Local).AddTicks(6164),
                            UpdateUser = "admin",
                            Version = 0
                        },
                        new
                        {
                            Id = new Guid("da6a58aa-bfdf-47c4-9c5f-a6401783a1f5"),
                            Author = "jimmiy",
                            CreateTime = new DateTime(2023, 5, 30, 14, 23, 49, 9, DateTimeKind.Local).AddTicks(6223),
                            CreateUser = "admin",
                            Description = "efrqc",
                            Title = "efrqc",
                            UpdateTime = new DateTime(2023, 5, 30, 14, 23, 49, 9, DateTimeKind.Local).AddTicks(6223),
                            UpdateUser = "admin",
                            Version = 0
                        },
                        new
                        {
                            Id = new Guid("cb3b23de-5e86-4558-9578-c74e1691e15e"),
                            Author = "rock",
                            CreateTime = new DateTime(2023, 5, 30, 14, 23, 49, 9, DateTimeKind.Local).AddTicks(6225),
                            CreateUser = "admin",
                            Description = "tuoxin",
                            Title = "tuoxin",
                            UpdateTime = new DateTime(2023, 5, 30, 14, 23, 49, 9, DateTimeKind.Local).AddTicks(6226),
                            UpdateUser = "admin",
                            Version = 0
                        },
                        new
                        {
                            Id = new Guid("89516b88-5c52-4795-8968-a8d918382828"),
                            Author = "john",
                            CreateTime = new DateTime(2023, 5, 30, 14, 23, 49, 9, DateTimeKind.Local).AddTicks(6227),
                            CreateUser = "admin",
                            Description = "good",
                            Title = "good",
                            UpdateTime = new DateTime(2023, 5, 30, 14, 23, 49, 9, DateTimeKind.Local).AddTicks(6228),
                            UpdateUser = "admin",
                            Version = 0
                        });
                });

            modelBuilder.Entity("Domain.Entities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Comment", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
