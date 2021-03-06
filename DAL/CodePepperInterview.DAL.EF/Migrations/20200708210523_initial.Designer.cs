﻿// <auto-generated />
using CodePepperInterview.DAL.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CodePepperInterview.DAL.EF.Migrations
{
    [DbContext(typeof(UrfSampleContext))]
    [Migration("20200708210523_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CodePepperInterview.DAL.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Planet")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Luke Skywalker"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Darth Vader"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Han Solo"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Leia Organa",
                            Planet = "Alderaan"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Wilhuff Tarkin",
                            Planet = "Alderaan--"
                        },
                        new
                        {
                            Id = 6,
                            Name = "C-3PO"
                        },
                        new
                        {
                            Id = 7,
                            Name = "R2-D2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
