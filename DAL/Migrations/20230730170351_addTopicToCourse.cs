using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class addTopicToCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Topic",
                newName: "ThumbnailURL");

            migrationBuilder.AddColumn<long>(
                name: "CourseId",
                table: "Topic",
                type: "bigint",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6c297200-e2fc-4513-822c-48a31d0c7fea", null, "PREMIUM_USER", null },
                    { "71530b4f-6c40-4fda-b02a-a5c3d3eb34fc", null, "ADMIN", null },
                    { "d112f767-57c2-4a74-9684-201face84077", null, "USER", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Topic_CourseId",
                table: "Topic",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_Course_CourseId",
                table: "Topic",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topic_Course_CourseId",
                table: "Topic");

            migrationBuilder.DropIndex(
                name: "IX_Topic_CourseId",
                table: "Topic");

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
                name: "CourseId",
                table: "Topic");

            migrationBuilder.RenameColumn(
                name: "ThumbnailURL",
                table: "Topic",
                newName: "Description");

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
    }
}
