using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LinkShortener.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSomeUrlsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Urls",
                columns: new[] { "Id", "CreatedAt", "LongUrl", "ShortUrl" },
                values: new object[,]
                {
                    { new Guid("08dd4867-6777-4aef-8bb3-1d1423e41d67"), new DateTime(2025, 2, 7, 21, 11, 59, 0, DateTimeKind.Unspecified), "https://www.w3schools.com", "iJyKHaMAR" },
                    { new Guid("08dd4867-6777-4aef-8bb3-1d7219e41d67"), new DateTime(2025, 2, 7, 17, 38, 30, 0, DateTimeKind.Unspecified), "https://vk.com", "1odc1dvGs" },
                    { new Guid("08dd4867-8342-4d03-8b46-c95f4eebaac3"), new DateTime(2025, 2, 8, 9, 5, 12, 0, DateTimeKind.Unspecified), "http://localhost:8080/swagger/index.html", "LDWQkfKhu" },
                    { new Guid("08dd4867-944f-4e16-8631-f7a15d60a0f6"), new DateTime(2025, 2, 8, 11, 12, 42, 0, DateTimeKind.Unspecified), "https://metanit.com", "XeWrGkd0S" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: new Guid("08dd4867-6777-4aef-8bb3-1d1423e41d67"));

            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: new Guid("08dd4867-6777-4aef-8bb3-1d7219e41d67"));

            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: new Guid("08dd4867-8342-4d03-8b46-c95f4eebaac3"));

            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: new Guid("08dd4867-944f-4e16-8631-f7a15d60a0f6"));
        }
    }
}
