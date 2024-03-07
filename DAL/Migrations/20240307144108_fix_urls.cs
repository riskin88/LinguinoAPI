using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class fix_urls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AudioURL",
                table: "WordExample",
                newName: "AudioUrl");

            migrationBuilder.RenameColumn(
                name: "ThumbnailURL",
                table: "Topic",
                newName: "ThumbnailUrl");

            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "LessonItem",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "AudioURL",
                table: "LessonItem",
                newName: "AudioUrl");

            migrationBuilder.RenameColumn(
                name: "BackgroundURL",
                table: "Lesson",
                newName: "BackgroundImageUrl");

            migrationBuilder.RenameColumn(
                name: "WordL2AudioURL",
                table: "Exercise",
                newName: "WordL2AudioUrl");

            migrationBuilder.RenameColumn(
                name: "TextL2AudioURL",
                table: "Exercise",
                newName: "TextL2AudioUrl");

            migrationBuilder.RenameColumn(
                name: "TextExercise_TextL2AudioURL",
                table: "Exercise",
                newName: "TextExercise_TextL2AudioUrl");

            migrationBuilder.RenameColumn(
                name: "TextExercise_ImageURL",
                table: "Exercise",
                newName: "TextExercise_ImageUrl");

            migrationBuilder.RenameColumn(
                name: "RepeatAudioExercise_AudioURL",
                table: "Exercise",
                newName: "RepeatAudioExercise_AudioUrl");

            migrationBuilder.RenameColumn(
                name: "ReadingExercise_ImageURL",
                table: "Exercise",
                newName: "ReadingExercise_ImageUrl");

            migrationBuilder.RenameColumn(
                name: "ReadAloudExercise_ImageURL",
                table: "Exercise",
                newName: "ReadAloudExercise_ImageUrl");

            migrationBuilder.RenameColumn(
                name: "ListeningExercise_ImageURL",
                table: "Exercise",
                newName: "ListeningExercise_ImageUrl");

            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Exercise",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "FillInSentenceExercise_ImageURL",
                table: "Exercise",
                newName: "FillInSentenceExercise_ImageUrl");

            migrationBuilder.RenameColumn(
                name: "AudioURL",
                table: "Exercise",
                newName: "AudioUrl");

            migrationBuilder.RenameColumn(
                name: "ThumbnailURL",
                table: "Course",
                newName: "ThumbnailUrl");

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "LessonItem",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "Exercise",
                type: "nvarchar(34)",
                maxLength: 34,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AudioUrl",
                table: "WordExample",
                newName: "AudioURL");

            migrationBuilder.RenameColumn(
                name: "ThumbnailUrl",
                table: "Topic",
                newName: "ThumbnailURL");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "LessonItem",
                newName: "ImageURL");

            migrationBuilder.RenameColumn(
                name: "AudioUrl",
                table: "LessonItem",
                newName: "AudioURL");

            migrationBuilder.RenameColumn(
                name: "BackgroundImageUrl",
                table: "Lesson",
                newName: "BackgroundURL");

            migrationBuilder.RenameColumn(
                name: "WordL2AudioUrl",
                table: "Exercise",
                newName: "WordL2AudioURL");

            migrationBuilder.RenameColumn(
                name: "TextL2AudioUrl",
                table: "Exercise",
                newName: "TextL2AudioURL");

            migrationBuilder.RenameColumn(
                name: "TextExercise_TextL2AudioUrl",
                table: "Exercise",
                newName: "TextExercise_TextL2AudioURL");

            migrationBuilder.RenameColumn(
                name: "TextExercise_ImageUrl",
                table: "Exercise",
                newName: "TextExercise_ImageURL");

            migrationBuilder.RenameColumn(
                name: "RepeatAudioExercise_AudioUrl",
                table: "Exercise",
                newName: "RepeatAudioExercise_AudioURL");

            migrationBuilder.RenameColumn(
                name: "ReadingExercise_ImageUrl",
                table: "Exercise",
                newName: "ReadingExercise_ImageURL");

            migrationBuilder.RenameColumn(
                name: "ReadAloudExercise_ImageUrl",
                table: "Exercise",
                newName: "ReadAloudExercise_ImageURL");

            migrationBuilder.RenameColumn(
                name: "ListeningExercise_ImageUrl",
                table: "Exercise",
                newName: "ListeningExercise_ImageURL");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Exercise",
                newName: "ImageURL");

            migrationBuilder.RenameColumn(
                name: "FillInSentenceExercise_ImageUrl",
                table: "Exercise",
                newName: "FillInSentenceExercise_ImageURL");

            migrationBuilder.RenameColumn(
                name: "AudioUrl",
                table: "Exercise",
                newName: "AudioURL");

            migrationBuilder.RenameColumn(
                name: "ThumbnailUrl",
                table: "Course",
                newName: "ThumbnailURL");

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "LessonItem",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13);

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(34)",
                oldMaxLength: 34);
        }
    }
}
