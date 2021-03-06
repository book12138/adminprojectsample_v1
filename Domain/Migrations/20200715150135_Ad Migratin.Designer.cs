﻿// <auto-generated />
using System;
using Domain.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Domain.Migrations
{
    [DbContext(typeof(BAMDbContext))]
    [Migration("20200715150135_Ad Migratin")]
    partial class AdMigratin
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.BM_Menu", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("CreateTime")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Creator")
                        .HasColumnType("int");

                    b.Property<string>("Desc")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Enable")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("HtmlClass")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Icon")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsButton")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsHide")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsShow")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Mender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Parent")
                        .HasColumnType("int");

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.Property<string>("UpdateTime")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Url")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("BM_Menu");
                });

            modelBuilder.Entity("Domain.Entities.BM_Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("CreateTime")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Creator")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Mender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.Property<string>("UpdateTime")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("BM_Role");
                });

            modelBuilder.Entity("Domain.Entities.BM_RoleMenu", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("CreateTime")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Creator")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Mender")
                        .HasColumnType("int");

                    b.Property<long>("MenuId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<string>("UpdateTime")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("BM_RoleMenu");
                });

            modelBuilder.Entity("Domain.Entities.BM_User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("BM_User");
                });

            modelBuilder.Entity("Domain.Entities.BM_UserRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("CreateTime")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Creator")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Mender")
                        .HasColumnType("int");

                    b.Property<long>("MenuId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<string>("UpdateTime")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("BM_UserRole");
                });
#pragma warning restore 612, 618
        }
    }
}
