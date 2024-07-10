using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPositionToTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Musics",
                keyColumn: "Id",
                keyValue: new Guid("051d9ce4-868f-475f-ad0a-3c93c63f713a"));

            migrationBuilder.DeleteData(
                table: "Musics",
                keyColumn: "Id",
                keyValue: new Guid("7dc28796-4686-487b-afa7-756fc9cbf425"));

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Musics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Artists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("2a275182-877d-4368-a135-156bea1b685b"),
                column: "Position",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("7e51cdda-b651-4081-b0df-b3ab3e4da734"),
                column: "Position",
                value: 0);

            migrationBuilder.InsertData(
                table: "Musics",
                columns: new[] { "Id", "ArtistId", "FileName", "Lyrics", "MediumId", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("6183f8a8-e514-41d7-84b0-ad70ae2991b9"), new Guid("2a275182-877d-4368-a135-156bea1b685b"), null, "", null, " Take me to your heart ", 0 },
                    { new Guid("a6d98c5d-8c5d-4370-b66f-17d2e492e563"), new Guid("7e51cdda-b651-4081-b0df-b3ab3e4da734"), null, "", null, " Hay Trao Cho Toi ", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Musics",
                keyColumn: "Id",
                keyValue: new Guid("6183f8a8-e514-41d7-84b0-ad70ae2991b9"));

            migrationBuilder.DeleteData(
                table: "Musics",
                keyColumn: "Id",
                keyValue: new Guid("a6d98c5d-8c5d-4370-b66f-17d2e492e563"));

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Artists");

            migrationBuilder.InsertData(
                table: "Musics",
                columns: new[] { "Id", "ArtistId", "FileName", "Lyrics", "MediumId", "Name" },
                values: new object[,]
                {
                    { new Guid("051d9ce4-868f-475f-ad0a-3c93c63f713a"), new Guid("7e51cdda-b651-4081-b0df-b3ab3e4da734"), null, null, null, " Hay Trao Cho Toi " },
                    { new Guid("7dc28796-4686-487b-afa7-756fc9cbf425"), new Guid("2a275182-877d-4368-a135-156bea1b685b"), null, null, null, " Take me to your heart " }
                });
        }
    }
}
