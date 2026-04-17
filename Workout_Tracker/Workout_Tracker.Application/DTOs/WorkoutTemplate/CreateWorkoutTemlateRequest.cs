using Workout_Tracker.Application.DTOs.TemplateExercise;

namespace Workout_Tracker.Application.DTOs.WorkoutTemplate;

public record CreateWorkoutTemplateRequest
{
    public string Name { get; init; } = string.Empty;
    public string ColorHex { get; init; } = "#808080";
    public List<CreateTemplateExerciseRequest> Exercises { get; init; } = new();
}
