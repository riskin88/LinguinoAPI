using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class SelectedLesson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PositionOnMap",
                table: "UserCourse");

            migrationBuilder.AddColumn<bool>(
                name: "IsLearned",
                table: "UserLesson",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "SelectedLessonId",
                table: "UserCourse",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCourse_SelectedLessonId",
                table: "UserCourse",
                column: "SelectedLessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourse_Lesson_SelectedLessonId",
                table: "UserCourse",
                column: "SelectedLessonId",
                principalTable: "Lesson",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCourse_Lesson_SelectedLessonId",
                table: "UserCourse");

            migrationBuilder.DropIndex(
                name: "IX_UserCourse_SelectedLessonId",
                table: "UserCourse");

            migrationBuilder.DropColumn(
                name: "IsLearned",
                table: "UserLesson");

            migrationBuilder.DropColumn(
                name: "SelectedLessonId",
                table: "UserCourse");

            migrationBuilder.AddColumn<long>(
                name: "PositionOnMap",
                table: "UserCourse",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
