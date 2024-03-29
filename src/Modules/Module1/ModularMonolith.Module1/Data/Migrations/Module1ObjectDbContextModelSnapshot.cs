﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModularMonolith.Module1;

#nullable disable

namespace ModularMonolith.Module1.Data.Migrations
{
    [DbContext(typeof(Module1ObjectDbContext))]
    partial class Module1ObjectDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Module1Objects")
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ModularMonolith.Module1.Module1Object", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Module1Objects", "Module1Objects");

                    b.HasData(
                        new
                        {
                            Id = new Guid("61b40c33-4640-407e-8b7e-ebb69217f04c"),
                            Name = "Object_1",
                            Value = 35
                        },
                        new
                        {
                            Id = new Guid("d595a08e-4675-434a-9c74-e6d9a76d6d91"),
                            Name = "Object_2",
                            Value = 32
                        },
                        new
                        {
                            Id = new Guid("04069dc5-c48e-4171-8828-32dd98b074b0"),
                            Name = "Object_3",
                            Value = 47
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
