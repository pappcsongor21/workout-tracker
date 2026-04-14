using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workout_Tracker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTargetIntensityAndRestTimeToTemplateExercise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestTime",
                table: "TemplateExercises",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TargetIntensity",
                table: "TemplateExercises",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RestTime",
                table: "TemplateExercises");

            migrationBuilder.DropColumn(
                name: "TargetIntensity",
                table: "TemplateExercises");
        }
    }
}
