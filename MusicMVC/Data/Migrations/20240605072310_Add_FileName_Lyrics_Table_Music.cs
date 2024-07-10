using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_FileName_Lyrics_Table_Music : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Musics",
                keyColumn: "Id",
                keyValue: new Guid("2409e99b-189e-4df2-930c-667dfbc48ceb"));

            migrationBuilder.DeleteData(
                table: "Musics",
                keyColumn: "Id",
                keyValue: new Guid("4b84f184-5651-4f71-a39f-a1bdcf7bb65a"));

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Musics",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lyrics",
                table: "Musics",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Musics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReleaseYear",
                table: "Musics",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Musics",
                columns: new[] { "Id", "ArtistId", "FileName", "Lyrics", "Name", "Position", "ReleaseYear" },
                values: new object[,]
                {
                    { new Guid("098efd02-7a00-4686-a4d7-b8b55734ecf2"), new Guid("2a275182-877d-4368-a135-156bea1b685b"), null, null, " Take me to your heart ", 1, null },
                    { new Guid("98c8280b-6c20-470a-914d-44127dfdb2ef"), new Guid("7e51cdda-b651-4081-b0df-b3ab3e4da734"), null, null, " Hay Trao Cho Toi ", 2, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Musics",
                keyColumn: "Id",
                keyValue: new Guid("098efd02-7a00-4686-a4d7-b8b55734ecf2"));

            migrationBuilder.DeleteData(
                table: "Musics",
                keyColumn: "Id",
                keyValue: new Guid("98c8280b-6c20-470a-914d-44127dfdb2ef"));

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "Lyrics",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "ReleaseYear",
                table: "Musics");

            migrationBuilder.InsertData(
                table: "Musics",
                columns: new[] { "Id", "ArtistId", "Name" },
                values: new object[,]
                {
                    { new Guid("2409e99b-189e-4df2-930c-667dfbc48ceb"), new Guid("7e51cdda-b651-4081-b0df-b3ab3e4da734"), " Hay Trao Cho Toi " },
                    { new Guid("4b84f184-5651-4f71-a39f-a1bdcf7bb65a"), new Guid("2a275182-877d-4368-a135-156bea1b685b"), " Take me to your heart " }
                });
        }
    }
}
