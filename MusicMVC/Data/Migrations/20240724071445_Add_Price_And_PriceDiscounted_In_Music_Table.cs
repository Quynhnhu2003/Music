using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_Price_And_PriceDiscounted_In_Music_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Musics",
                keyColumn: "Id",
                keyValue: new Guid("e9c75676-0524-4cb0-ae53-622cae1b27d6"));

            migrationBuilder.DeleteData(
                table: "Musics",
                keyColumn: "Id",
                keyValue: new Guid("f450ba0b-4afd-4251-ac20-556faf906d71"));

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Musics",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PriceDiscounted",
                table: "Musics",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "Musics",
                columns: new[] { "Id", "ArtistId", "FileName", "Lyrics", "MediumId", "Name", "Position", "Price", "PriceDiscounted" },
                values: new object[,]
                {
                    { new Guid("2c950e96-bc37-424c-a0f1-9175391bf6b2"), new Guid("2a275182-877d-4368-a135-156bea1b685b"), null, "", null, " Take me to your heart ", 0, 0.0, 0.0 },
                    { new Guid("3b372564-1d8d-4d83-811c-c27f5d4a12c2"), new Guid("7e51cdda-b651-4081-b0df-b3ab3e4da734"), null, "", null, " Hay Trao Cho Toi ", 0, 0.0, 0.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Musics",
                keyColumn: "Id",
                keyValue: new Guid("2c950e96-bc37-424c-a0f1-9175391bf6b2"));

            migrationBuilder.DeleteData(
                table: "Musics",
                keyColumn: "Id",
                keyValue: new Guid("3b372564-1d8d-4d83-811c-c27f5d4a12c2"));

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "PriceDiscounted",
                table: "Musics");

            migrationBuilder.InsertData(
                table: "Musics",
                columns: new[] { "Id", "ArtistId", "FileName", "Lyrics", "MediumId", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("e9c75676-0524-4cb0-ae53-622cae1b27d6"), new Guid("7e51cdda-b651-4081-b0df-b3ab3e4da734"), null, "", null, " Hay Trao Cho Toi ", 0 },
                    { new Guid("f450ba0b-4afd-4251-ac20-556faf906d71"), new Guid("2a275182-877d-4368-a135-156bea1b685b"), null, "", null, " Take me to your heart ", 0 }
                });
        }
    }
}
