﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicMVC.Data;

#nullable disable

namespace MusicMVC.Data.Migrations
{
    [DbContext(typeof(MusicDbContext))]
    [Migration("20240605072310_Add_FileName_Lyrics_Table_Music")]
    partial class Add_FileName_Lyrics_Table_Music
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MusicMVC.Data.Entities.Artist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.HasKey("Id");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2a275182-877d-4368-a135-156bea1b685b"),
                            Name = " Name Artist 1"
                        },
                        new
                        {
                            Id = new Guid("7e51cdda-b651-4081-b0df-b3ab3e4da734"),
                            Name = " Name Artist 2"
                        });
                });

            modelBuilder.Entity("MusicMVC.Data.Entities.Music", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ArtistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FileName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Lyrics")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int?>("ReleaseYear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Musics");

                    b.HasData(
                        new
                        {
                            Id = new Guid("098efd02-7a00-4686-a4d7-b8b55734ecf2"),
                            ArtistId = new Guid("2a275182-877d-4368-a135-156bea1b685b"),
                            Name = " Take me to your heart ",
                            Position = 1
                        },
                        new
                        {
                            Id = new Guid("98c8280b-6c20-470a-914d-44127dfdb2ef"),
                            ArtistId = new Guid("7e51cdda-b651-4081-b0df-b3ab3e4da734"),
                            Name = " Hay Trao Cho Toi ",
                            Position = 2
                        });
                });

            modelBuilder.Entity("MusicMVC.Data.Entities.Music", b =>
                {
                    b.HasOne("MusicMVC.Data.Entities.Artist", "Artist")
                        .WithMany("Musics")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("MusicMVC.Data.Entities.Artist", b =>
                {
                    b.Navigation("Musics");
                });
#pragma warning restore 612, 618
        }
    }
}
