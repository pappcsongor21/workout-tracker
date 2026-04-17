namespace Workout_Tracker.Application.DTOs.TemplateExercise;

public record CreateTemplateExerciseRequest
{
    public int ExerciseId { get; init; }
    public int OrderNum { get; set; }
    public int TargetSets { get; set; }
    public int TargetRepsMin { get; set; }
    public int TargetRepsMax { get; set; }
    public string TargetIntensity { get; set; } = string.Empty;
    public int RestSeconds { get; set; }
}
