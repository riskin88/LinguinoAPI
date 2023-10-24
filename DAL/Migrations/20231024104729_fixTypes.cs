using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class fixTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderOnMap",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "EstimatedTimeMs",
                table: "Exercise");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OrderOnMap",
                table: "Lesson",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "EstimatedTimeMs",
                table: "Exercise",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
