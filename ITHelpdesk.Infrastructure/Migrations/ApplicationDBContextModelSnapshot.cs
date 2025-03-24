﻿// <auto-generated />
using System;
using ITHelpdesk.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ITHelpdesk.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ITHelpdesk.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("GithubUsername")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2025, 3, 22, 16, 54, 40, 471, DateTimeKind.Utc).AddTicks(5839),
                            DateOfBirth = new DateTime(2025, 3, 22, 16, 54, 40, 471, DateTimeKind.Utc).AddTicks(5834),
                            Email = "",
                            GithubUsername = "johndoe",
                            IsActive = true,
                            ModifiedDate = new DateTime(2025, 3, 22, 16, 54, 40, 471, DateTimeKind.Utc).AddTicks(5839),
                            Name = "Nguyen Tuan Ninh",
                            Password = "password",
                            PhoneNumber = "1234567890",
                            Role = 0,
                            Username = "ninh"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2025, 3, 22, 16, 54, 40, 471, DateTimeKind.Utc).AddTicks(5845),
                            DateOfBirth = new DateTime(2025, 3, 22, 16, 54, 40, 471, DateTimeKind.Utc).AddTicks(5844),
                            Email = "",
                            GithubUsername = "johndoe",
                            IsActive = true,
                            ModifiedDate = new DateTime(2025, 3, 22, 16, 54, 40, 471, DateTimeKind.Utc).AddTicks(5846),
                            Name = "Nguyen Duy Phuc",
                            Password = "password",
                            PhoneNumber = "1234567890",
                            Role = 1,
                            Username = "phuc"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2025, 3, 22, 16, 54, 40, 471, DateTimeKind.Utc).AddTicks(5851),
                            DateOfBirth = new DateTime(2025, 3, 22, 16, 54, 40, 471, DateTimeKind.Utc).AddTicks(5850),
                            Email = "",
                            GithubUsername = "johndoe",
                            IsActive = true,
                            ModifiedDate = new DateTime(2025, 3, 22, 16, 54, 40, 471, DateTimeKind.Utc).AddTicks(5852),
                            Name = "Nguyen Dinh Manh",
                            Password = "password",
                            PhoneNumber = "1234567890",
                            Role = 2,
                            Username = "manh"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
