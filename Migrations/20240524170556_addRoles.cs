using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace proiect.Migrations
{
    /// <inheritdoc />
    public partial class addRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "25ed71d6-c83c-4960-bbd4-c1cd041350d4", null, "client", "client" },
                    { "60e2f73d-09cc-4bc4-9b01-25bf0f1b5b9f", null, "vizitator", "vizitator" },
                    { "cbc5d9b3-d0f2-4fe5-8b5d-f3cbcb0d2cc5", null, "moderator", "moderator" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25ed71d6-c83c-4960-bbd4-c1cd041350d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60e2f73d-09cc-4bc4-9b01-25bf0f1b5b9f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbc5d9b3-d0f2-4fe5-8b5d-f3cbcb0d2cc5");
        }
    }
}
