﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicMVC.Data;

#nullable disable

namespace MusicMVC.Data.Migrations
{
    [DbContext(typeof(MusicDbContext))]
    partial class MusicDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Gender")
                        .HasColumnType("tinyint");

                    b.Property<int>("MusicCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2a275182-877d-4368-a135-156bea1b685b"),
                            Gender = (byte)0,
                            MusicCount = 0,
                            Name = " Name Artist 1",
                            Nickname = "",
                            Position = 0
                        },
                        new
                        {
                            Id = new Guid("7e51cdda-b651-4081-b0df-b3ab3e4da734"),
                            Gender = (byte)0,
                            MusicCount = 0,
                            Name = " Name Artist 2",
                            Nickname = "",
                            Position = 0
                        });
                });

            modelBuilder.Entity("MusicMVC.Data.Entities.Medium", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Media");
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

                    b.Property<Guid?>("MediumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("MediumId");

                    b.ToTable("Musics");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f450ba0b-4afd-4251-ac20-556faf906d71"),
                            ArtistId = new Guid("2a275182-877d-4368-a135-156bea1b685b"),
                            Lyrics = "",
                            Name = " Take me to your heart ",
                            Position = 0
                        },
                        new
                        {
                            Id = new Guid("e9c75676-0524-4cb0-ae53-622cae1b27d6"),
                            ArtistId = new Guid("7e51cdda-b651-4081-b0df-b3ab3e4da734"),
                            Lyrics = "",
                            Name = " Hay Trao Cho Toi ",
                            Position = 0
                        });
                });

            modelBuilder.Entity("MusicMVC.Data.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 6)
                        .HasColumnType("decimal(18,6)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MusicMVC.Data.Entities.OrderDetail", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MusicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 6)
                        .HasColumnType("decimal(18,6)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("PriceDiscounted")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "MusicId");

                    b.HasIndex("MusicId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("MusicMVC.Data.Entities.Music", b =>
                {
                    b.HasOne("MusicMVC.Data.Entities.Artist", "Artist")
                        .WithMany("Musics")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicMVC.Data.Entities.Medium", "Medium")
                        .WithMany("Musics")
                        .HasForeignKey("MediumId");

                    b.Navigation("Artist");

                    b.Navigation("Medium");
                });

            modelBuilder.Entity("MusicMVC.Data.Entities.OrderDetail", b =>
                {
                    b.HasOne("MusicMVC.Data.Entities.Music", "Music")
                        .WithMany("OrderDetails")
                        .HasForeignKey("MusicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicMVC.Data.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Music");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("MusicMVC.Data.Entities.Artist", b =>
                {
                    b.Navigation("Musics");
                });

            modelBuilder.Entity("MusicMVC.Data.Entities.Medium", b =>
                {
                    b.Navigation("Musics");
                });

            modelBuilder.Entity("MusicMVC.Data.Entities.Music", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("MusicMVC.Data.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
