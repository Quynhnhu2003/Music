using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_Media_To_Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Position",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "ReleaseYear",
                table: "Musics");

            migrationBuilder.AddColumn<Guid>(
                name: "MediumId",
                table: "Musics",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Type = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Musics",
                columns: new[] { "Id", "ArtistId", "FileName", "Lyrics", "MediumId", "Name" },
                values: new object[,]
                {
                    { new Guid("051d9ce4-868f-475f-ad0a-3c93c63f713a"), new Guid("7e51cdda-b651-4081-b0df-b3ab3e4da734"), null, null, null, " Hay Trao Cho Toi " },
                    { new Guid("7dc28796-4686-487b-afa7-756fc9cbf425"), new Guid("2a275182-877d-4368-a135-156bea1b685b"), null, null, null, " Take me to your heart " }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Musics_MediumId",
                table: "Musics",
                column: "MediumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Media_MediumId",
                table: "Musics",
                column: "MediumId",
                principalTable: "Media",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Media_MediumId",
                table: "Musics");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Musics_MediumId",
                table: "Musics");

            migrationBuilder.DeleteData(
                table: "Musics",
                keyColumn: "Id",
                keyValue: new Guid("051d9ce4-868f-475f-ad0a-3c93c63f713a"));

            migrationBuilder.DeleteData(
                table: "Musics",
                keyColumn: "Id",
                keyValue: new Guid("7dc28796-4686-487b-afa7-756fc9cbf425"));

            migrationBuilder.DropColumn(
                name: "MediumId",
                table: "Musics");

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
    }
}
