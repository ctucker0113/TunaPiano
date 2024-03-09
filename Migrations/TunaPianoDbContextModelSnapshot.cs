﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TunaPiano.Migrations
{
    [DbContext(typeof(TunaPianoDbContext))]
    partial class TunaPianoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TunaPiano.Models.Artist", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Bio")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Age = 34,
                            Bio = "She really likes to sing about her breakups.",
                            Name = "Taylor Swift"
                        },
                        new
                        {
                            ID = 2,
                            Age = 38,
                            Bio = "Likes to sing songs that get you up and moving!",
                            Name = "Bruno Mars"
                        });
                });

            modelBuilder.Entity("TunaPiano.Models.Genre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "Synth Pop"
                        },
                        new
                        {
                            ID = 2,
                            Description = "Funk Pop"
                        });
                });

            modelBuilder.Entity("TunaPiano.Models.Song", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Album")
                        .HasColumnType("text");

                    b.Property<int?>("ArtistID")
                        .HasColumnType("integer");

                    b.Property<int?>("GenreID")
                        .HasColumnType("integer");

                    b.Property<int?>("Length")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("ArtistID");

                    b.HasIndex("GenreID");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Album = "Midnights",
                            ArtistID = 1,
                            Length = 4,
                            Title = "Bigger Than the Whole Sky"
                        },
                        new
                        {
                            ID = 2,
                            Album = "Uptown Special",
                            ArtistID = 2,
                            Length = 4,
                            Title = "Uptown Funk"
                        });
                });

            modelBuilder.Entity("TunaPiano.Models.SongGenre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("GenreID")
                        .HasColumnType("integer");

                    b.Property<int>("SongID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("GenreID");

                    b.HasIndex("SongID");

                    b.ToTable("SongGenres");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            GenreID = 1,
                            SongID = 1
                        },
                        new
                        {
                            ID = 2,
                            GenreID = 2,
                            SongID = 2
                        });
                });

            modelBuilder.Entity("TunaPiano.Models.Song", b =>
                {
                    b.HasOne("TunaPiano.Models.Artist", "Artist")
                        .WithMany("Songs")
                        .HasForeignKey("ArtistID");

                    b.HasOne("TunaPiano.Models.Genre", null)
                        .WithMany("Songs")
                        .HasForeignKey("GenreID");

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("TunaPiano.Models.SongGenre", b =>
                {
                    b.HasOne("TunaPiano.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TunaPiano.Models.Song", null)
                        .WithMany("SongGenres")
                        .HasForeignKey("SongID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("TunaPiano.Models.Artist", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("TunaPiano.Models.Genre", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("TunaPiano.Models.Song", b =>
                {
                    b.Navigation("SongGenres");
                });
#pragma warning restore 612, 618
        }
    }
}
