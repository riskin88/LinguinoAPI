using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class wordExamples : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VideoURL",
                table: "Lesson",
                newName: "VideoId");

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Lesson",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WordExample",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextL1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TextL2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AudioURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WordId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordExample", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordExample_LessonItem_WordId",
                        column: x => x.WordId,
                        principalTable: "LessonItem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WordExample_WordId",
                table: "WordExample",
                column: "WordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WordExample");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Lesson");

            migrationBuilder.RenameColumn(
                name: "VideoId",
                table: "Lesson",
                newName: "VideoURL");
        }
    }
}
