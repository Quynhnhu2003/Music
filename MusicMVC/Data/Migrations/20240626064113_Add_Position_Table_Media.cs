using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_Position_Table_Media : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Musics",
                keyColumn: "Id",
                keyValue: new Guid("04f7e0b5-d248-4f06-9953-ad835f011a97"));

            migrationBuilder.DeleteData(
                table: "Musics",
                keyColumn: "Id",
                keyValue: new Guid("71a147fe-e14b-4c06-9018-2f5c5c2c5063"));

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Media",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Musics",
                columns: new[] { "Id", "ArtistId", "FileName", "Lyrics", "MediumId", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("4af09eed-f903-4ca7-8d44-67353ec685c0"), new Guid("7e51cdda-b651-4081-b0df-b3ab3e4da734"), null, "", null, " Hay Trao Cho Toi ", 0 },
                    { new Guid("562b70a9-cad9-4c61-84d4-6c1aa33e9f8c"), new Guid("2a275182-877d-4368-a135-156bea1b685b"), null, "", null, " Take me to your heart ", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Musics",
                keyColumn: "Id",
                keyValue: new Guid("4af09eed-f903-4ca7-8d44-67353ec685c0"));

            migrationBuilder.DeleteData(
                table: "Musics",
                keyColumn: "Id",
                keyValue: new Guid("562b70a9-cad9-4c61-84d4-6c1aa33e9f8c"));

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Media");

            migrationBuilder.InsertData(
                table: "Musics",
                columns: new[] { "Id", "ArtistId", "FileName", "Lyrics", "MediumId", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("04f7e0b5-d248-4f06-9953-ad835f011a97"), new Guid("7e51cdda-b651-4081-b0df-b3ab3e4da734"), null, "", null, " Hay Trao Cho Toi ", 0 },
                    { new Guid("71a147fe-e14b-4c06-9018-2f5c5c2c5063"), new Guid("2a275182-877d-4368-a135-156bea1b685b"), null, "", null, " Take me to your heart ", 0 }
                });
        }
    }
}
