using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class L1L2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LanguageTo",
                table: "Course",
                newName: "Language2");

            migrationBuilder.RenameColumn(
                name: "LanguageFrom",
                table: "Course",
                newName: "Language1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Language2",
                table: "Course",
                newName: "LanguageTo");

            migrationBuilder.RenameColumn(
                name: "Language1",
                table: "Course",
                newName: "LanguageFrom");
        }
    }
}
