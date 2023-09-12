using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class TopicCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c297200-e2fc-4513-822c-48a31d0c7fea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71530b4f-6c40-4fda-b02a-a5c3d3eb34fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d112f767-57c2-4a74-9684-201face84077");

            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "Topic");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Topic",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Topic");

            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "Topic",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6c297200-e2fc-4513-822c-48a31d0c7fea", null, "PREMIUM_USER", null },
                    { "71530b4f-6c40-4fda-b02a-a5c3d3eb34fc", null, "ADMIN", null },
                    { "d112f767-57c2-4a74-9684-201face84077", null, "USER", null }
                });
        }
    }
}
