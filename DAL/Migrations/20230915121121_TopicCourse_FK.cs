using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class TopicCourse_FK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topic_Course_CourseId",
                table: "Topic");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0fc259bb-8d7f-4d02-8cf0-676541d120db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e545565-2a2a-4601-b37d-48c8da081548");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c84f5df6-24c5-4991-adb6-158acc87b102");

            migrationBuilder.AlterColumn<long>(
                name: "CourseId",
                table: "Topic",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b4245d1-2ea3-4d9c-994e-2f7c06057ae4", null, "PREMIUM_USER", null },
                    { "724febe1-3fb9-4d3d-93c7-26cacadbf7ac", null, "USER", null },
                    { "f0f50611-1597-47c7-80a6-cac91c383953", null, "ADMIN", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_Course_CourseId",
                table: "Topic",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topic_Course_CourseId",
                table: "Topic");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b4245d1-2ea3-4d9c-994e-2f7c06057ae4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "724febe1-3fb9-4d3d-93c7-26cacadbf7ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0f50611-1597-47c7-80a6-cac91c383953");

            migrationBuilder.AlterColumn<long>(
                name: "CourseId",
                table: "Topic",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0fc259bb-8d7f-4d02-8cf0-676541d120db", null, "ADMIN", null },
                    { "2e545565-2a2a-4601-b37d-48c8da081548", null, "PREMIUM_USER", null },
                    { "c84f5df6-24c5-4991-adb6-158acc87b102", null, "USER", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_Course_CourseId",
                table: "Topic",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id");
        }
    }
}
