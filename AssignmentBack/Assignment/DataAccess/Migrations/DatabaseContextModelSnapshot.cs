﻿// <auto-generated />
using System;
using Assignment.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment.DataAccess.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("Assignment.Domain.CalculationInput", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Mass")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Velocity")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CalculationInput", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
