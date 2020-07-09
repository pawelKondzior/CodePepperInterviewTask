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
    [Migration("20200709104133_second")]
    partial class second
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

            modelBuilder.Entity("CodePepperInterview.DAL.Models.CharacterFriend", b =>
                {
                    b.Property<int>("RelatingCharacterId")
                        .HasColumnType("int");

                    b.Property<int>("RelatedCharacterId")
                        .HasColumnType("int");

                    b.HasKey("RelatingCharacterId", "RelatedCharacterId");

                    b.HasIndex("RelatedCharacterId");

                    b.ToTable("CharacterFriends");

                    b.HasData(
                        new
                        {
                            RelatingCharacterId = 1,
                            RelatedCharacterId = 2
                        },
                        new
                        {
                            RelatingCharacterId = 2,
                            RelatedCharacterId = 1
                        },
                        new
                        {
                            RelatingCharacterId = 1,
                            RelatedCharacterId = 3
                        },
                        new
                        {
                            RelatingCharacterId = 3,
                            RelatedCharacterId = 1
                        });
                });

            modelBuilder.Entity("CodePepperInterview.DAL.Models.CharacterFriend", b =>
                {
                    b.HasOne("CodePepperInterview.DAL.Models.Character", "RelatedCharacter")
                        .WithMany("CharacterFriendRelatedCharacter")
                        .HasForeignKey("RelatedCharacterId")
                        .HasConstraintName("FK_CharacterFriend_Characters")
                        .IsRequired();

                    b.HasOne("CodePepperInterview.DAL.Models.Character", "RelatingCharacter")
                        .WithMany("CharacterFriendRelatingCharacter")
                        .HasForeignKey("RelatingCharacterId")
                        .HasConstraintName("FK_CharacterFriend_CharacterFriend")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
