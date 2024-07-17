using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_Order_And_OrderDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Musics",
                keyColumn: "Id",
                keyValue: new Guid("4af09eed-f903-4ca7-8d44-67353ec685c0"));

            migrationBuilder.DeleteData(
                table: "Musics",
                keyColumn: "Id",
                keyValue: new Guid("562b70a9-cad9-4c61-84d4-6c1aa33e9f8c"));

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MusicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PriceDiscounted = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.OrderId, x.MusicId });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Musics_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Musics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Musics",
                columns: new[] { "Id", "ArtistId", "FileName", "Lyrics", "MediumId", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("e9c75676-0524-4cb0-ae53-622cae1b27d6"), new Guid("7e51cdda-b651-4081-b0df-b3ab3e4da734"), null, "", null, " Hay Trao Cho Toi ", 0 },
                    { new Guid("f450ba0b-4afd-4251-ac20-556faf906d71"), new Guid("2a275182-877d-4368-a135-156bea1b685b"), null, "", null, " Take me to your heart ", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_MusicId",
                table: "OrderDetails",
                column: "MusicId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DeleteData(
                table: "Musics",
                keyColumn: "Id",
                keyValue: new Guid("e9c75676-0524-4cb0-ae53-622cae1b27d6"));

            migrationBuilder.DeleteData(
                table: "Musics",
                keyColumn: "Id",
                keyValue: new Guid("f450ba0b-4afd-4251-ac20-556faf906d71"));

            migrationBuilder.InsertData(
                table: "Musics",
                columns: new[] { "Id", "ArtistId", "FileName", "Lyrics", "MediumId", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("4af09eed-f903-4ca7-8d44-67353ec685c0"), new Guid("7e51cdda-b651-4081-b0df-b3ab3e4da734"), null, "", null, " Hay Trao Cho Toi ", 0 },
                    { new Guid("562b70a9-cad9-4c61-84d4-6c1aa33e9f8c"), new Guid("2a275182-877d-4368-a135-156bea1b685b"), null, "", null, " Take me to your heart ", 0 }
                });
        }
    }
}
