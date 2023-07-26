using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class course : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "LanguageTo",
                table: "Course",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LanguageFrom",
                table: "Course",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Course",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailURL",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a7e93ec0-8579-46a5-8bc5-4728cecdb351", null, "ADMIN", null },
                    { "af7c643b-5925-4314-8287-38da3ce67482", null, "USER", null },
                    { "d29abb07-9164-4d0d-9e0b-50ce4569534c", null, "PREMIUM_USER", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7e93ec0-8579-46a5-8bc5-4728cecdb351");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af7c643b-5925-4314-8287-38da3ce67482");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d29abb07-9164-4d0d-9e0b-50ce4569534c");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "ThumbnailURL",
                table: "Course");

            migrationBuilder.AlterColumn<string>(
                name: "LanguageTo",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LanguageFrom",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
