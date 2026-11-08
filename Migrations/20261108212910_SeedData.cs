using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FTELMarket.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "PlayStation 5" },
                    { 2, "Nintendo Switch" },
                    { 3, "Xbox Series X" },
                    { 4, "PC" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 9, 2, 9, 15, 0, 0, DateTimeKind.Utc), "Boîte et notice, disque sans rayure.", "The Last of Us Part II", 19.9m, 3 },
                    { 2, 1, new DateTime(2026, 9, 5, 14, 30, 0, 0, DateTimeKind.Utc), null, "Gran Turismo 7", 29.9m, 1 },
                    { 3, 2, new DateTime(2026, 9, 8, 10, 0, 0, 0, DateTimeKind.Utc), "Cartouche seule.", "The Legend of Zelda: Tears of the Kingdom", 39.9m, 2 },
                    { 4, 2, new DateTime(2026, 9, 10, 16, 45, 0, 0, DateTimeKind.Utc), "Complet, très bon état.", "Mario Kart 8 Deluxe", 34.9m, 5 },
                    { 5, 3, new DateTime(2026, 9, 12, 11, 20, 0, 0, DateTimeKind.Utc), null, "Halo Infinite", 14.9m, 4 },
                    { 6, 3, new DateTime(2026, 9, 15, 8, 5, 0, 0, DateTimeKind.Utc), "Édition standard.", "Forza Horizon 5", 24.9m, 0 },
                    { 7, 4, new DateTime(2026, 9, 18, 17, 40, 0, 0, DateTimeKind.Utc), "Clé physique, coffret collector.", "Baldur’s Gate 3", 44.9m, 1 },
                    { 8, 4, new DateTime(2026, 9, 21, 13, 10, 0, 0, DateTimeKind.Utc), null, "Hades", 9.9m, 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
