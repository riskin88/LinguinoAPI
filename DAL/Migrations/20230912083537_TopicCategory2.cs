using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class TopicCategory2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37548003-49e0-4b91-bc6d-4aabe7025173");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fca7bdd-02a9-49f6-808b-94117c18d9f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be9b5d43-5f10-4bac-8c9d-bb4dfd5b2e86");

            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "Topic",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "826d0888-9fb4-408b-aa05-0d069018bebe", null, "PREMIUM_USER", null },
                    { "8ea71490-223c-4ca4-8aa2-94faf9b0b76d", null, "ADMIN", null },
                    { "deb0af60-11e0-45e9-9a10-a7d8a9f95fe8", null, "USER", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "826d0888-9fb4-408b-aa05-0d069018bebe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ea71490-223c-4ca4-8aa2-94faf9b0b76d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "deb0af60-11e0-45e9-9a10-a7d8a9f95fe8");

            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "Topic",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "37548003-49e0-4b91-bc6d-4aabe7025173", null, "USER", null },
                    { "5fca7bdd-02a9-49f6-808b-94117c18d9f6", null, "ADMIN", null },
                    { "be9b5d43-5f10-4bac-8c9d-bb4dfd5b2e86", null, "PREMIUM_USER", null }
                });
        }
    }
}
