using Workout_Tracker.Application.DTOs.TemplateExercise;

namespace Workout_Tracker.Application.DTOs.WorkoutTemplate;

public record WorkoutTemplateCreatedResponse
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string ColorHex { get; init; } = string.Empty;
    public List<TemplateExerciseCreatedResponse> Exercises { get; init; } = new();
}
