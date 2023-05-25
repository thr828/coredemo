﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Article", b =>
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
                            Id = new Guid("c78f2172-a0c5-4db1-94cc-b92e71abf9fa"),
                            Author = "jack",
                            CreateTime = new DateTime(2023, 5, 24, 11, 21, 23, 6, DateTimeKind.Local).AddTicks(3485),
                            CreateUser = "admin",
                            Description = "crm",
                            Title = "迅达crm",
                            UpdateTime = new DateTime(2023, 5, 24, 11, 21, 23, 6, DateTimeKind.Local).AddTicks(3495),
                            UpdateUser = "admin",
                            Version = 0
                        },
                        new
                        {
                            Id = new Guid("60431df2-0048-4545-848a-49f226e116ce"),
                            Author = "jimmiy",
                            CreateTime = new DateTime(2023, 5, 24, 11, 21, 23, 6, DateTimeKind.Local).AddTicks(3522),
                            CreateUser = "admin",
                            Description = "efrqc",
                            Title = "efrqc",
                            UpdateTime = new DateTime(2023, 5, 24, 11, 21, 23, 6, DateTimeKind.Local).AddTicks(3522),
                            UpdateUser = "admin",
                            Version = 0
                        },
                        new
                        {
                            Id = new Guid("6a120b42-95ae-49a3-ac38-bf0018099fc7"),
                            Author = "rock",
                            CreateTime = new DateTime(2023, 5, 24, 11, 21, 23, 6, DateTimeKind.Local).AddTicks(3534),
                            CreateUser = "admin",
                            Description = "tuoxin",
                            Title = "tuoxin",
                            UpdateTime = new DateTime(2023, 5, 24, 11, 21, 23, 6, DateTimeKind.Local).AddTicks(3535),
                            UpdateUser = "admin",
                            Version = 0
                        },
                        new
                        {
                            Id = new Guid("14d6c176-bb69-41dd-addf-188b8e2ff605"),
                            Author = "john",
                            CreateTime = new DateTime(2023, 5, 24, 11, 21, 23, 6, DateTimeKind.Local).AddTicks(3536),
                            CreateUser = "admin",
                            Description = "good",
                            Title = "good",
                            UpdateTime = new DateTime(2023, 5, 24, 11, 21, 23, 6, DateTimeKind.Local).AddTicks(3537),
                            UpdateUser = "admin",
                            Version = 0
                        });
                });

            modelBuilder.Entity("Domain.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BeArticleId")
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

                    b.HasIndex("BeArticleId");

                    b.ToTable("Comment", (string)null);
                });

            modelBuilder.Entity("Domain.Comment", b =>
                {
                    b.HasOne("Domain.Article", "BeArticle")
                        .WithMany()
                        .HasForeignKey("BeArticleId");

                    b.Navigation("BeArticle");
                });
#pragma warning restore 612, 618
        }
    }
}
