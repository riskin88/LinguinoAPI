using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UserTopic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseProgress");

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

            migrationBuilder.CreateTable(
                name: "UserCourse",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    PositionOnMap = table.Column<long>(type: "bigint", nullable: false),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCourse_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCourse_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTopic",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TopicId = table.Column<long>(type: "bigint", nullable: false),
                    LessonsActive = table.Column<long>(type: "bigint", nullable: false),
                    LessonsTotal = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTopic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTopic_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTopic_Topic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0fc259bb-8d7f-4d02-8cf0-676541d120db", null, "ADMIN", null },
                    { "2e545565-2a2a-4601-b37d-48c8da081548", null, "PREMIUM_USER", null },
                    { "c84f5df6-24c5-4991-adb6-158acc87b102", null, "USER", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCourse_CourseId",
                table: "UserCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourse_UserId",
                table: "UserCourse",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTopic_TopicId",
                table: "UserTopic",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTopic_UserId",
                table: "UserTopic",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCourse");

            migrationBuilder.DropTable(
                name: "UserTopic");

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

            migrationBuilder.CreateTable(
                name: "CourseProgress",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false),
                    PositionOnMap = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseProgress_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseProgress_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "826d0888-9fb4-408b-aa05-0d069018bebe", null, "PREMIUM_USER", null },
                    { "8ea71490-223c-4ca4-8aa2-94faf9b0b76d", null, "ADMIN", null },
                    { "deb0af60-11e0-45e9-9a10-a7d8a9f95fe8", null, "USER", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseProgress_CourseId",
                table: "CourseProgress",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProgress_UserId",
                table: "CourseProgress",
                column: "UserId");
        }
    }
}
