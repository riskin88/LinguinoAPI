using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class xx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemsTotal",
                table: "UserLesson");

            migrationBuilder.RenameColumn(
                name: "FromInterval",
                table: "LearningStep",
                newName: "ToInterval");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateToReview",
                table: "UserLessonItem",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemState",
                table: "UserLessonItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "LessonItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "ItemsTotal",
                table: "Lesson",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "ExercisesInSession",
                table: "LearningStep",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateToReview",
                table: "UserLessonItem");

            migrationBuilder.DropColumn(
                name: "ItemState",
                table: "UserLessonItem");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "LessonItem");

            migrationBuilder.DropColumn(
                name: "ItemsTotal",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "ExercisesInSession",
                table: "LearningStep");

            migrationBuilder.RenameColumn(
                name: "ToInterval",
                table: "LearningStep",
                newName: "FromInterval");

            migrationBuilder.AddColumn<long>(
                name: "ItemsTotal",
                table: "UserLesson",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
