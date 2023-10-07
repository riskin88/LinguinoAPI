using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class feedback : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FeedbackId",
                table: "UserLesson",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LessonFeedback",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonFeedback", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLesson_FeedbackId",
                table: "UserLesson",
                column: "FeedbackId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLesson_LessonFeedback_FeedbackId",
                table: "UserLesson",
                column: "FeedbackId",
                principalTable: "LessonFeedback",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLesson_LessonFeedback_FeedbackId",
                table: "UserLesson");

            migrationBuilder.DropTable(
                name: "LessonFeedback");

            migrationBuilder.DropIndex(
                name: "IX_UserLesson_FeedbackId",
                table: "UserLesson");

            migrationBuilder.DropColumn(
                name: "FeedbackId",
                table: "UserLesson");
        }
    }
}
