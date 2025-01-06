﻿// <auto-generated />
using System;
using EventManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventManager.Migrations
{
    [DbContext(typeof(EventManagerContext))]
    [Migration("20250106222929_SecondMigration")]
    partial class SecondMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("EventHasAtendee", b =>
                {
                    b.Property<int>("AtendeesId")
                        .HasColumnType("int");

                    b.Property<int>("EventsId")
                        .HasColumnType("int");

                    b.HasKey("AtendeesId", "EventsId");

                    b.HasIndex("EventsId");

                    b.ToTable("EventHasAtendee");

                    b.HasData(
                        new
                        {
                            AtendeesId = 1,
                            EventsId = 1
                        },
                        new
                        {
                            AtendeesId = 2,
                            EventsId = 1
                        });
                });

            modelBuilder.Entity("EventManager.Models.Atendee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CurrentStatus")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProfilePicPath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Atendees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrentStatus = 0,
                            Description = "Comediante e ator do porta dos fundos",
                            Name = "Rafael Portugal",
                            ProfilePicPath = ""
                        },
                        new
                        {
                            Id = 2,
                            CurrentStatus = 0,
                            Description = "Palhaço profissional",
                            Name = "Palhaço Tubinho",
                            ProfilePicPath = ""
                        });
                });

            modelBuilder.Entity("EventManager.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<int>("OrganizerId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("VenueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrganizerId");

                    b.HasIndex("VenueId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2025, 3, 30, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Uma palestra apresentada por um comediante do porta dos fundos, explorando a ideia por trás das risadas.",
                            OrganizerId = 1,
                            Title = "Palestra sobre comédia",
                            VenueId = 1
                        });
                });

            modelBuilder.Entity("EventManager.Models.Organizer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Organizers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "ericmoura@gmail.com",
                            Name = "Eric Moura",
                            Password = "coxinha123"
                        });
                });

            modelBuilder.Entity("EventManager.Models.Venue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CurrentStatus")
                        .HasColumnType("int");

                    b.Property<int?>("HouseNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Venues");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Guaratinguetá",
                            Country = "Brasil",
                            CurrentStatus = 0,
                            HouseNumber = 82,
                            Name = "Estação",
                            Neighborhood = "Praça Condessa de Frontin",
                            State = "São paulo"
                        });
                });

            modelBuilder.Entity("EventHasAtendee", b =>
                {
                    b.HasOne("EventManager.Models.Atendee", null)
                        .WithMany()
                        .HasForeignKey("AtendeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventManager.Models.Event", null)
                        .WithMany()
                        .HasForeignKey("EventsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EventManager.Models.Event", b =>
                {
                    b.HasOne("EventManager.Models.Organizer", "Organizer")
                        .WithMany("Events")
                        .HasForeignKey("OrganizerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventManager.Models.Venue", "Venue")
                        .WithMany("Events")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organizer");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("EventManager.Models.Organizer", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("EventManager.Models.Venue", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
