using Workout_Tracker.Application.DTOs.Exercise;

namespace Workout_Tracker.Application.DTOs.TemplateExercise;

public record TemplateExerciseResponse
{
    public int Id { get; init; }

    public ExerciseResponse Exercise { get; init; } = null!;

    public int OrderNum { get; set; }
    public int TargetSets { get; set; }
    public int TargetRepsMin { get; set; }
    public int TargetRepsMax { get; set; }
    public string TargetIntensity { get; set; } = string.Empty;
    public int RestSeconds { get; set; }
}
