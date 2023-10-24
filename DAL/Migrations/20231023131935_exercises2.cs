using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class exercises2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnswerAudioURL",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlankCellCoords",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlankIndexes",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Explanation",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FillInBlankOptionsExercise_Answer",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FillInBlankOptionsExercise_AnswerAudioURL",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FillInBlankOptionsExercise_BlankIndexes",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FillInBlankOptionsExercise_ImageURL",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FillInBlankOptionsExercise_Question",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FillInTableExercise_Question",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Options",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TableRows",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextExercise_Answer",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextExercise_AnswerAudioURL",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextExercise_ImageURL",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextExercise_Question",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "AnswerAudioURL",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "BlankCellCoords",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "BlankIndexes",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "Explanation",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "FillInBlankOptionsExercise_Answer",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "FillInBlankOptionsExercise_AnswerAudioURL",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "FillInBlankOptionsExercise_BlankIndexes",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "FillInBlankOptionsExercise_ImageURL",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "FillInBlankOptionsExercise_Question",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "FillInTableExercise_Question",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "Options",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "Question",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "TableRows",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "TextExercise_Answer",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "TextExercise_AnswerAudioURL",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "TextExercise_ImageURL",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "TextExercise_Question",
                table: "Exercise");
        }
    }
}
