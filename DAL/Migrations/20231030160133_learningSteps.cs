using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class learningSteps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LearningStep",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromInterval = table.Column<int>(type: "int", nullable: false),
                    LessonItemId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearningStep_LessonItem_LessonItemId",
                        column: x => x.LessonItemId,
                        principalTable: "LessonItem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LearningStepExercise",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LearningStepId = table.Column<long>(type: "bigint", nullable: false),
                    ExerciseId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningStepExercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearningStepExercise_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LearningStepExercise_LearningStep_LearningStepId",
                        column: x => x.LearningStepId,
                        principalTable: "LearningStep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LearningStep_LessonItemId",
                table: "LearningStep",
                column: "LessonItemId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningStepExercise_ExerciseId",
                table: "LearningStepExercise",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningStepExercise_LearningStepId",
                table: "LearningStepExercise",
                column: "LearningStepId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LearningStepExercise");

            migrationBuilder.DropTable(
                name: "LearningStep");
        }
    }
}
