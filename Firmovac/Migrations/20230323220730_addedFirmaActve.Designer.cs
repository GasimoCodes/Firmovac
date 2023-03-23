﻿// <auto-generated />
using System;
using Firmovac;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Firmovac.Migrations
{
    [DbContext(typeof(FirmaDbContext))]
    [Migration("20230323220730_addedFirmaActve")]
    partial class addedFirmaActve
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Firmovac.DataDefinitions.ColumnDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DataType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("isHidden")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("ColumnDefinitions");
                });

            modelBuilder.Entity("Firmovac.DataDefinitions.Firma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("JsonColumns")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Note")
                        .HasColumnType("longtext");

                    b.Property<int>("OborId")
                        .HasColumnType("int");

                    b.Property<int?>("SourceId")
                        .HasColumnType("int");

                    b.Property<bool>("isAktivni")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.HasIndex("OborId");

                    b.HasIndex("SourceId");

                    b.ToTable("Firms");
                });

            modelBuilder.Entity("Firmovac.DataDefinitions.FirmaContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<int?>("FirmaId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("FirmaId");

                    b.ToTable("FirmaContacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "nemec@spsejecna.cz",
                            Name = "N. Němec"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Večirka",
                            Phone = "777022400"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Velký J."
                        });
                });

            modelBuilder.Entity("Firmovac.DataDefinitions.FirmaEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("FirmaId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("FirmaId");

                    b.HasIndex("Name");

                    b.ToTable("FirmaEvents");
                });

            modelBuilder.Entity("Firmovac.DataDefinitions.FirmaSource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("FirmaSources");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "IT"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Praxe žáků"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Prac. Nab. z portálu"
                        });
                });

            modelBuilder.Entity("Firmovac.DataDefinitions.OborDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Obors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "IT"
                        },
                        new
                        {
                            Id = 2,
                            Name = "ELE"
                        },
                        new
                        {
                            Id = 3,
                            Name = "AM"
                        },
                        new
                        {
                            Id = 4,
                            Name = "N/A"
                        });
                });

            modelBuilder.Entity("Firmovac.DataDefinitions.Firma", b =>
                {
                    b.HasOne("Firmovac.DataDefinitions.OborDefinition", "Obor")
                        .WithMany()
                        .HasForeignKey("OborId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Firmovac.DataDefinitions.FirmaSource", "Source")
                        .WithMany()
                        .HasForeignKey("SourceId");

                    b.Navigation("Obor");

                    b.Navigation("Source");
                });

            modelBuilder.Entity("Firmovac.DataDefinitions.FirmaContact", b =>
                {
                    b.HasOne("Firmovac.DataDefinitions.Firma", null)
                        .WithMany("Contact")
                        .HasForeignKey("FirmaId");
                });

            modelBuilder.Entity("Firmovac.DataDefinitions.FirmaEvent", b =>
                {
                    b.HasOne("Firmovac.DataDefinitions.Firma", null)
                        .WithMany("Events")
                        .HasForeignKey("FirmaId");
                });

            modelBuilder.Entity("Firmovac.DataDefinitions.Firma", b =>
                {
                    b.Navigation("Contact");

                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
