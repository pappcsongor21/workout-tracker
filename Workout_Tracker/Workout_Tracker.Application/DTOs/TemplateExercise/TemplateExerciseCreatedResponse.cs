namespace Workout_Tracker.Application.DTOs.TemplateExercise;

public record TemplateExerciseCreatedResponse
{
    public int Id { get; init; }
    public int ExerciseId { get; init; }
    public int OrderNum { get; init; }
    public int TargetSets { get; init; }
    public int TargetRepsMin { get; init; }
    public int TargetRepsMax { get; init; }
    public string TargetIntensity { get; init; } = string.Empty;
    public int RestSeconds { get; init; }
}
