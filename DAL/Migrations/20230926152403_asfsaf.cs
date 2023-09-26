using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class asfsaf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LessonsTotal",
                table: "UserTopic");

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "UserTopic",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "LessonsTotal",
                table: "Topic",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "UserTopic");

            migrationBuilder.DropColumn(
                name: "LessonsTotal",
                table: "Topic");

            migrationBuilder.AddColumn<long>(
                name: "LessonsTotal",
                table: "UserTopic",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
