using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class new_exercises : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderInItem",
                table: "Exercise");

            migrationBuilder.RenameColumn(
                name: "FillInBlankOptionsExercise_ImageURL",
                table: "Exercise",
                newName: "ReadingExercise_ImageURL");

            migrationBuilder.RenameColumn(
                name: "TextExercise_Question",
                table: "Exercise",
                newName: "WordL2AudioURL");

            migrationBuilder.RenameColumn(
                name: "TextExercise_AnswerAudioURL",
                table: "Exercise",
                newName: "WordL2");

            migrationBuilder.RenameColumn(
                name: "TextExercise_Answer",
                table: "Exercise",
                newName: "WordL1");

            migrationBuilder.RenameColumn(
                name: "Question",
                table: "Exercise",
                newName: "TextL2AudioURL");

            migrationBuilder.RenameColumn(
                name: "FillInTableExercise_Question",
                table: "Exercise",
                newName: "TextL2");

            migrationBuilder.RenameColumn(
                name: "FillInBlankOptionsExercise_Question",
                table: "Exercise",
                newName: "TextL1");

            migrationBuilder.RenameColumn(
                name: "FillInBlankOptionsExercise_BlankIndexes",
                table: "Exercise",
                newName: "TextExercise_TextL2AudioURL");

            migrationBuilder.RenameColumn(
                name: "FillInBlankOptionsExercise_AnswerAudioURL",
                table: "Exercise",
                newName: "TextExercise_TextL2");

            migrationBuilder.RenameColumn(
                name: "FillInBlankOptionsExercise_Answer",
                table: "Exercise",
                newName: "TextExercise_TextL1");

            migrationBuilder.RenameColumn(
                name: "AnswerAudioURL",
                table: "Exercise",
                newName: "ShortListeningExercise_TextL2");

            migrationBuilder.RenameColumn(
                name: "Answer",
                table: "Exercise",
                newName: "RepeatAudioExercise_TextL2");

            migrationBuilder.AddColumn<string>(
                name: "AnswerL2",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Article",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssignmentTopicL2",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AudioURL",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FillInSentenceExercise_ImageURL",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Letters",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ListeningExercise_ImageURL",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ListeningExercise_QuestionL2",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionL2",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Questions",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReadAloudExercise_ImageURL",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReadAloudExercise_TextL2",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReadingExercise_AnswerL2",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReadingExercise_QuestionL2",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RepeatAudioExercise_AudioURL",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeMs",
                table: "Exercise",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerL2",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "Article",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "AssignmentTopicL2",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "AudioURL",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "FillInSentenceExercise_ImageURL",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "Letters",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "ListeningExercise_ImageURL",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "ListeningExercise_QuestionL2",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "QuestionL2",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "Questions",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "ReadAloudExercise_ImageURL",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "ReadAloudExercise_TextL2",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "ReadingExercise_AnswerL2",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "ReadingExercise_QuestionL2",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "RepeatAudioExercise_AudioURL",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "TimeMs",
                table: "Exercise");

            migrationBuilder.RenameColumn(
                name: "ReadingExercise_ImageURL",
                table: "Exercise",
                newName: "FillInBlankOptionsExercise_ImageURL");

            migrationBuilder.RenameColumn(
                name: "WordL2AudioURL",
                table: "Exercise",
                newName: "TextExercise_Question");

            migrationBuilder.RenameColumn(
                name: "WordL2",
                table: "Exercise",
                newName: "TextExercise_AnswerAudioURL");

            migrationBuilder.RenameColumn(
                name: "WordL1",
                table: "Exercise",
                newName: "TextExercise_Answer");

            migrationBuilder.RenameColumn(
                name: "TextL2AudioURL",
                table: "Exercise",
                newName: "Question");

            migrationBuilder.RenameColumn(
                name: "TextL2",
                table: "Exercise",
                newName: "FillInTableExercise_Question");

            migrationBuilder.RenameColumn(
                name: "TextL1",
                table: "Exercise",
                newName: "FillInBlankOptionsExercise_Question");

            migrationBuilder.RenameColumn(
                name: "TextExercise_TextL2AudioURL",
                table: "Exercise",
                newName: "FillInBlankOptionsExercise_BlankIndexes");

            migrationBuilder.RenameColumn(
                name: "TextExercise_TextL2",
                table: "Exercise",
                newName: "FillInBlankOptionsExercise_AnswerAudioURL");

            migrationBuilder.RenameColumn(
                name: "TextExercise_TextL1",
                table: "Exercise",
                newName: "FillInBlankOptionsExercise_Answer");

            migrationBuilder.RenameColumn(
                name: "ShortListeningExercise_TextL2",
                table: "Exercise",
                newName: "AnswerAudioURL");

            migrationBuilder.RenameColumn(
                name: "RepeatAudioExercise_TextL2",
                table: "Exercise",
                newName: "Answer");

            migrationBuilder.AddColumn<double>(
                name: "OrderInItem",
                table: "Exercise",
                type: "float",
                nullable: true);
        }
    }
}
