using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class isSelected : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "CourseProgress",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "547f8c87-2911-4a39-80fa-3ab51b64ff73", null, "PREMIUM_USER", null },
                    { "584c3ae1-264f-4dec-812c-710e134d5a96", null, "USER", null },
                    { "fdc95b32-d44f-469e-a7b1-ca0e2096cdd2", null, "ADMIN", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "547f8c87-2911-4a39-80fa-3ab51b64ff73");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "584c3ae1-264f-4dec-812c-710e134d5a96");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdc95b32-d44f-469e-a7b1-ca0e2096cdd2");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "CourseProgress");
        }
    }
}
