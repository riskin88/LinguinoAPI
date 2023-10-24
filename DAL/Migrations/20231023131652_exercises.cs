using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class exercises : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "OrderInLesson",
                table: "LessonItemLesson",
                type: "float",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonItemId = table.Column<long>(type: "bigint", nullable: true),
                    OrderInItem = table.Column<double>(type: "float", nullable: true),
                    EstimatedTimeMs = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercise_LessonItem_LessonItemId",
                        column: x => x.LessonItemId,
                        principalTable: "LessonItem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_LessonItemId",
                table: "Exercise",
                column: "LessonItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropColumn(
                name: "OrderInLesson",
                table: "LessonItemLesson");
        }
    }
}
