using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_GenderNicknameDOB_To_Table_Artist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Musics",
                keyColumn: "Id",
                keyValue: new Guid("6183f8a8-e514-41d7-84b0-ad70ae2991b9"));

            migrationBuilder.DeleteData(
                table: "Musics",
                keyColumn: "Id",
                keyValue: new Guid("a6d98c5d-8c5d-4370-b66f-17d2e492e563"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Artists",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Gender",
                table: "Artists",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "MusicCount",
                table: "Artists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "Artists",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("2a275182-877d-4368-a135-156bea1b685b"),
                columns: new[] { "DateOfBirth", "Gender", "MusicCount", "Nickname" },
                values: new object[] { null, (byte)0, 0, "" });

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("7e51cdda-b651-4081-b0df-b3ab3e4da734"),
                columns: new[] { "DateOfBirth", "Gender", "MusicCount", "Nickname" },
                values: new object[] { null, (byte)0, 0, "" });

            migrationBuilder.InsertData(
                table: "Musics",
                columns: new[] { "Id", "ArtistId", "FileName", "Lyrics", "MediumId", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("04f7e0b5-d248-4f06-9953-ad835f011a97"), new Guid("7e51cdda-b651-4081-b0df-b3ab3e4da734"), null, "", null, " Hay Trao Cho Toi ", 0 },
                    { new Guid("71a147fe-e14b-4c06-9018-2f5c5c2c5063"), new Guid("2a275182-877d-4368-a135-156bea1b685b"), null, "", null, " Take me to your heart ", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Musics",
                keyColumn: "Id",
                keyValue: new Guid("04f7e0b5-d248-4f06-9953-ad835f011a97"));

            migrationBuilder.DeleteData(
                table: "Musics",
                keyColumn: "Id",
                keyValue: new Guid("71a147fe-e14b-4c06-9018-2f5c5c2c5063"));

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "MusicCount",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "Artists");

            migrationBuilder.InsertData(
                table: "Musics",
                columns: new[] { "Id", "ArtistId", "FileName", "Lyrics", "MediumId", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("6183f8a8-e514-41d7-84b0-ad70ae2991b9"), new Guid("2a275182-877d-4368-a135-156bea1b685b"), null, "", null, " Take me to your heart ", 0 },
                    { new Guid("a6d98c5d-8c5d-4370-b66f-17d2e492e563"), new Guid("7e51cdda-b651-4081-b0df-b3ab3e4da734"), null, "", null, " Hay Trao Cho Toi ", 0 }
                });
        }
    }
}
