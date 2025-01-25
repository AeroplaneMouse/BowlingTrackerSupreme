﻿// <auto-generated />
using System;
using BowlingTrackerSupreme.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BowlingTrackerSupreme.Migrations.Migrations
{
    [DbContext(typeof(BowlingTrackerSupremeDbContext))]
    [Migration("20250125122446_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BowlingTrackerSupreme.Domain.Models.Frame", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)");

                    b.Property<Guid>("FirstRollId")
                        .HasColumnType("uuid");

                    b.Property<int>("FrameNumber")
                        .HasColumnType("integer");

                    b.Property<Guid>("PlayerGameId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SecondRollId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PlayerGameId");

                    b.ToTable("Frames");

                    b.HasDiscriminator().HasValue("Frame");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("BowlingTrackerSupreme.Domain.Models.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("WinningPlayerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("WinningPlayerId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("BowlingTrackerSupreme.Domain.Models.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("BowlingTrackerSupreme.Domain.Models.PlayerGame", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerGames");
                });

            modelBuilder.Entity("GamePlayer", b =>
                {
                    b.Property<Guid>("GameParticipationId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ParticipantsId")
                        .HasColumnType("uuid");

                    b.HasKey("GameParticipationId", "ParticipantsId");

                    b.HasIndex("ParticipantsId");

                    b.ToTable("GamePlayer");
                });

            modelBuilder.Entity("BowlingTrackerSupreme.Domain.Models.FinalFrame", b =>
                {
                    b.HasBaseType("BowlingTrackerSupreme.Domain.Models.Frame");

                    b.HasDiscriminator().HasValue("FinalFrame");
                });

            modelBuilder.Entity("BowlingTrackerSupreme.Domain.Models.Frame", b =>
                {
                    b.HasOne("BowlingTrackerSupreme.Domain.Models.PlayerGame", "PlayerGame")
                        .WithMany("Frames")
                        .HasForeignKey("PlayerGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("BowlingTrackerSupreme.Domain.Models.Roll", "FirstRoll", b1 =>
                        {
                            b1.Property<Guid>("FrameId")
                                .HasColumnType("uuid");

                            b1.Property<int>("PinsHit")
                                .HasColumnType("integer");

                            b1.HasKey("FrameId");

                            b1.ToTable("Frames");

                            b1.WithOwner()
                                .HasForeignKey("FrameId");
                        });

                    b.OwnsOne("BowlingTrackerSupreme.Domain.Models.Roll", "SecondRoll", b1 =>
                        {
                            b1.Property<Guid>("FrameId")
                                .HasColumnType("uuid");

                            b1.Property<int>("PinsHit")
                                .HasColumnType("integer");

                            b1.HasKey("FrameId");

                            b1.ToTable("Frames");

                            b1.WithOwner()
                                .HasForeignKey("FrameId");
                        });

                    b.Navigation("FirstRoll")
                        .IsRequired();

                    b.Navigation("PlayerGame");

                    b.Navigation("SecondRoll");
                });

            modelBuilder.Entity("BowlingTrackerSupreme.Domain.Models.Game", b =>
                {
                    b.HasOne("BowlingTrackerSupreme.Domain.Models.Player", "WinningPlayer")
                        .WithMany()
                        .HasForeignKey("WinningPlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WinningPlayer");
                });

            modelBuilder.Entity("BowlingTrackerSupreme.Domain.Models.PlayerGame", b =>
                {
                    b.HasOne("BowlingTrackerSupreme.Domain.Models.Game", "Game")
                        .WithMany("PlayerGames")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BowlingTrackerSupreme.Domain.Models.Player", "Player")
                        .WithMany("PlayedGames")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("GamePlayer", b =>
                {
                    b.HasOne("BowlingTrackerSupreme.Domain.Models.Game", null)
                        .WithMany()
                        .HasForeignKey("GameParticipationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BowlingTrackerSupreme.Domain.Models.Player", null)
                        .WithMany()
                        .HasForeignKey("ParticipantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BowlingTrackerSupreme.Domain.Models.FinalFrame", b =>
                {
                    b.OwnsOne("BowlingTrackerSupreme.Domain.Models.Roll", "ThirdRoll", b1 =>
                        {
                            b1.Property<Guid>("FinalFrameId")
                                .HasColumnType("uuid");

                            b1.Property<int>("PinsHit")
                                .HasColumnType("integer");

                            b1.HasKey("FinalFrameId");

                            b1.ToTable("Frames");

                            b1.WithOwner()
                                .HasForeignKey("FinalFrameId");
                        });

                    b.Navigation("ThirdRoll");
                });

            modelBuilder.Entity("BowlingTrackerSupreme.Domain.Models.Game", b =>
                {
                    b.Navigation("PlayerGames");
                });

            modelBuilder.Entity("BowlingTrackerSupreme.Domain.Models.Player", b =>
                {
                    b.Navigation("PlayedGames");
                });

            modelBuilder.Entity("BowlingTrackerSupreme.Domain.Models.PlayerGame", b =>
                {
                    b.Navigation("Frames");
                });
#pragma warning restore 612, 618
        }
    }
}
