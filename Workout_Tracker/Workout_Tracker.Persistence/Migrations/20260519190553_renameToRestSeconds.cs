using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workout_Tracker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class renameToRestSeconds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RestTime",
                table: "TemplateExercises",
                newName: "RestSeconds");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RestSeconds",
                table: "TemplateExercises",
                newName: "RestTime");
        }
    }
}
