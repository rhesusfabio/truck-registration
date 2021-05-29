﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using TruckRegistration.Infrastructure;

namespace TruckRegistration.Infrastructure.Migrations
{
    [DbContext(typeof(TruckContext))]
    partial class TruckContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TruckRegistration.Domain.Model.Truck", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("Chassi")
                        .HasMaxLength(100);

                    b.Property<string>("Description")
                        .HasMaxLength(100);

                    b.Property<int>("ManufactureModel");

                    b.Property<int>("ManufactureYear");

                    b.Property<string>("ModelString")
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.ToTable("Trucks");
                });
#pragma warning restore 612, 618
        }
    }
}
