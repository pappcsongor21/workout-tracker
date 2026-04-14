using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workout_Tracker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWorokutTemplateColorToHex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorNum",
                table: "WorkoutTemplates");

            migrationBuilder.AddColumn<string>(
                name: "ColorHex",
                table: "WorkoutTemplates",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorHex",
                table: "WorkoutTemplates");

            migrationBuilder.AddColumn<int>(
                name: "ColorNum",
                table: "WorkoutTemplates",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
