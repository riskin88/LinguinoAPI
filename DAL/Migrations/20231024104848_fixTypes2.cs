using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class fixTypes2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "OrderOnMap",
                table: "Lesson",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EstimatedTimeMs",
                table: "Exercise",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderOnMap",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "EstimatedTimeMs",
                table: "Exercise");
        }
    }
}
