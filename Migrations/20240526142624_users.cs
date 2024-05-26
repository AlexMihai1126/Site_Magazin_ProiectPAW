using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace proiect.Migrations
{
    /// <inheritdoc />
    public partial class users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c3d3daf-69df-4a90-a27f-bce2de55757e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87f0db7f-9595-4abf-910c-b892fa28dfa2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e30add9c-e10f-4c73-b897-443862c3ff80");

            migrationBuilder.AddColumn<string>(
                name: "Dimensiune",
                table: "Produs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "14387f6f-45ae-4dfe-976e-b8a3fbde7720", null, "vizitator", "VIZITATOR" },
                    { "45f5b42b-3c69-4a0b-b086-4bc10d410c09", null, "moderator", "MODERATOR" },
                    { "906461a3-61db-493d-b91f-8b49530a5d23", null, "client", "CLIENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14387f6f-45ae-4dfe-976e-b8a3fbde7720");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45f5b42b-3c69-4a0b-b086-4bc10d410c09");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "906461a3-61db-493d-b91f-8b49530a5d23");

            migrationBuilder.DropColumn(
                name: "Dimensiune",
                table: "Produs");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3c3d3daf-69df-4a90-a27f-bce2de55757e", null, "vizitator", "VIZITATOR" },
                    { "87f0db7f-9595-4abf-910c-b892fa28dfa2", null, "client", "CLIENT" },
                    { "e30add9c-e10f-4c73-b897-443862c3ff80", null, "moderator", "MODERATOR" }
                });
        }
    }
}
