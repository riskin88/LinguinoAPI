using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13a21b37-d84b-4ab9-83ec-b9ab16a29e7c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa4da2a9-05d1-412b-bbe9-b8f1542f5b89");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c627e4b4-3290-4d24-a6df-2d3f1c350979");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3cf4378a-3fca-45d5-8782-db69e9bd5259", null, "USER", "USER" },
                    { "7521910b-749d-4fbd-bf8e-dfddb9aa4fd6", null, "ADMIN", "ADMIN" },
                    { "d05744d9-00ed-4cb8-8224-eb1e4abf31ba", null, "PREMIUM_USER", "PREMIUM_USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3cf4378a-3fca-45d5-8782-db69e9bd5259");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7521910b-749d-4fbd-bf8e-dfddb9aa4fd6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d05744d9-00ed-4cb8-8224-eb1e4abf31ba");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "13a21b37-d84b-4ab9-83ec-b9ab16a29e7c", null, "USER", null },
                    { "aa4da2a9-05d1-412b-bbe9-b8f1542f5b89", null, "ADMIN", null },
                    { "c627e4b4-3290-4d24-a6df-2d3f1c350979", null, "PREMIUM_USER", null }
                });
        }
    }
}
