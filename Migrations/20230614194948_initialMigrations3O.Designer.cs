﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using footballClubMass.Data;

#nullable disable

namespace footballClubMass.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230614194948_initialMigrations3O")]
    partial class initialMigrations3O
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("footballClubMass.Models.Coach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BirthdayYear")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CountOfTitles")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PESEL")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("baseSalary")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Coach");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Coach");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("footballClubMass.Models.Contract", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Contract");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Contract");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("footballClubMass.Models.Page", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("contractId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("pageNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("contractId");

                    b.ToTable("pages");
                });

            modelBuilder.Entity("footballClubMass.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BirthdayYear")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CountOfTitles")
                        .HasColumnType("INTEGER");

                    b.Property<string>("InjuryDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PESEL")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.Property<int>("PlayerInfoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Role")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("TshirtNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("playerType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PlayerInfoId")
                        .IsUnique();

                    b.ToTable("Players");
                });

            modelBuilder.Entity("footballClubMass.Models.PlayerInfo", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("betterFoot")
                        .HasColumnType("INTEGER");

                    b.Property<string>("nickname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PlayerId");

                    b.ToTable("PlayerInfo");
                });

            modelBuilder.Entity("footballClubMass.Models.PreviousClub", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerInfoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("clubName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("PlayerInfoId");

                    b.ToTable("PreviousClub");
                });

            modelBuilder.Entity("footballClubMass.Models.SetPieceCoachTypeDb", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("setPieceCoachId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("type")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("setPieceCoachId");

                    b.ToTable("SetPieceCoachTypeDb");
                });

            modelBuilder.Entity("footballClubMass.Models.MotorCoach", b =>
                {
                    b.HasBaseType("footballClubMass.Models.Coach");

                    b.Property<int>("degreeEducationType")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("MotorCoach");
                });

            modelBuilder.Entity("footballClubMass.Models.SetPieceCoach", b =>
                {
                    b.HasBaseType("footballClubMass.Models.Coach");

                    b.Property<bool?>("CanTeachPanemka")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("CanTeachPositioning")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("SetPieceCoach");
                });

            modelBuilder.Entity("footballClubMass.Models.CoachContract", b =>
                {
                    b.HasBaseType("footballClubMass.Models.Contract");

                    b.Property<int>("Clause")
                        .HasColumnType("INTEGER");

                    b.Property<int>("coachId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("coachId");

                    b.HasDiscriminator().HasValue("CoachContract");
                });

            modelBuilder.Entity("footballClubMass.Models.PlayerContract", b =>
                {
                    b.HasBaseType("footballClubMass.Models.Contract");

                    b.Property<float>("Salary")
                        .HasColumnType("REAL");

                    b.Property<int>("playerId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("playerId");

                    b.HasDiscriminator().HasValue("PlayerContract");
                });

            modelBuilder.Entity("footballClubMass.Models.Page", b =>
                {
                    b.HasOne("footballClubMass.Models.Contract", "Contract")
                        .WithMany("Pages")
                        .HasForeignKey("contractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("footballClubMass.Models.Player", b =>
                {
                    b.HasOne("footballClubMass.Models.PlayerInfo", "PlayerInfo")
                        .WithOne("player")
                        .HasForeignKey("footballClubMass.Models.Player", "PlayerInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlayerInfo");
                });

            modelBuilder.Entity("footballClubMass.Models.PreviousClub", b =>
                {
                    b.HasOne("footballClubMass.Models.PlayerInfo", "PlayerInfo")
                        .WithMany("prevClubs")
                        .HasForeignKey("PlayerInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlayerInfo");
                });

            modelBuilder.Entity("footballClubMass.Models.SetPieceCoachTypeDb", b =>
                {
                    b.HasOne("footballClubMass.Models.SetPieceCoach", "SetPieceCoach")
                        .WithMany("Types")
                        .HasForeignKey("setPieceCoachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SetPieceCoach");
                });

            modelBuilder.Entity("footballClubMass.Models.CoachContract", b =>
                {
                    b.HasOne("footballClubMass.Models.Coach", "coach")
                        .WithMany("CoachContractList")
                        .HasForeignKey("coachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("coach");
                });

            modelBuilder.Entity("footballClubMass.Models.PlayerContract", b =>
                {
                    b.HasOne("footballClubMass.Models.Player", "player")
                        .WithMany("PlayerContractList")
                        .HasForeignKey("playerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("player");
                });

            modelBuilder.Entity("footballClubMass.Models.Coach", b =>
                {
                    b.Navigation("CoachContractList");
                });

            modelBuilder.Entity("footballClubMass.Models.Contract", b =>
                {
                    b.Navigation("Pages");
                });

            modelBuilder.Entity("footballClubMass.Models.Player", b =>
                {
                    b.Navigation("PlayerContractList");
                });

            modelBuilder.Entity("footballClubMass.Models.PlayerInfo", b =>
                {
                    b.Navigation("player")
                        .IsRequired();

                    b.Navigation("prevClubs");
                });

            modelBuilder.Entity("footballClubMass.Models.SetPieceCoach", b =>
                {
                    b.Navigation("Types");
                });
#pragma warning restore 612, 618
        }
    }
}
