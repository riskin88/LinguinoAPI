using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class word : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "LessonItem",
                newName: "Discriminator");

            migrationBuilder.AddColumn<string>(
                name: "AudioURL",
                table: "LessonItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "LessonItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "LessonItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameL1",
                table: "LessonItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameL2",
                table: "LessonItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserLessonItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LessonItemId = table.Column<long>(type: "bigint", nullable: false),
                    IsFavorite = table.Column<bool>(type: "bit", nullable: false),
                    Repetitions = table.Column<int>(type: "int", nullable: false),
                    Interval = table.Column<int>(type: "int", nullable: false),
                    Easiness = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLessonItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLessonItem_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLessonItem_LessonItem_LessonItemId",
                        column: x => x.LessonItemId,
                        principalTable: "LessonItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLessonItem_LessonItemId",
                table: "UserLessonItem",
                column: "LessonItemId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLessonItem_UserId",
                table: "UserLessonItem",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLessonItem");

            migrationBuilder.DropColumn(
                name: "AudioURL",
                table: "LessonItem");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "LessonItem");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "LessonItem");

            migrationBuilder.DropColumn(
                name: "NameL1",
                table: "LessonItem");

            migrationBuilder.DropColumn(
                name: "NameL2",
                table: "LessonItem");

            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "LessonItem",
                newName: "Name");
        }
    }
}
