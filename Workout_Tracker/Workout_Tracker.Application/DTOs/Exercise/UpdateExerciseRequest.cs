namespace Workout_Tracker.Application.DTOs.Exercise;

public record UpdateExerciseRequest
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string MuscleGroup { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
}
