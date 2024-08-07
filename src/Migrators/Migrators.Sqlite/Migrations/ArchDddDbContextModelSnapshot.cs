﻿// <auto-generated />
using System;
using ArchDdd.Adapters.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Migrators.Sqlite.Migrations
{
    [DbContext(typeof(ArchDddDbContext))]
    partial class ArchDddDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("ArchDdd.Domain.AggregateRoots.Users.Enumerations.Permission", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("VarChar(128)");

                    b.Property<string>("Properties")
                        .HasColumnType("TEXT");

                    b.Property<string>("RelatedAggregateRoot")
                        .HasColumnType("VarChar(128)");

                    b.Property<string>("RelatedEntity")
                        .HasColumnType("VarChar(128)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("VarChar(6)");

                    b.HasKey("Name");

                    b.ToTable("Permission", "Master");
                });

            modelBuilder.Entity("ArchDdd.Domain.AggregateRoots.Users.Enumerations.Role", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("VarChar(128)");

                    b.HasKey("Name");

                    b.ToTable("Role", "Master");

                    b.HasData(
                        new
                        {
                            Name = "Customer"
                        },
                        new
                        {
                            Name = "Employee"
                        },
                        new
                        {
                            Name = "Manager"
                        },
                        new
                        {
                            Name = "Administrator"
                        });
                });

            modelBuilder.Entity("ArchDdd.Domain.AggregateRoots.Users.Enumerations.RoleUser", b =>
                {
                    b.Property<string>("RoleName")
                        .HasColumnType("VarChar(128)");

                    b.Property<string>("UserId")
                        .HasColumnType("Char(26)");

                    b.HasKey("RoleName", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("RoleUser", "Master");
                });

            modelBuilder.Entity("ArchDdd.Domain.AggregateRoots.Users.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("Char(26)");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("TEXT")
                        .HasColumnName("Email");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("NChar(514)")
                        .HasColumnName("PasswordHash");

                    b.Property<DateTimeOffset?>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT")
                        .HasColumnName("Username");

                    b.HasKey("Id");

                    b.ToTable("User", "Master");
                });

            modelBuilder.Entity("ArchDdd.Domain.AggregateRoots.Users.Enumerations.RoleUser", b =>
                {
                    b.HasOne("ArchDdd.Domain.AggregateRoots.Users.Enumerations.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ArchDdd.Domain.AggregateRoots.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
