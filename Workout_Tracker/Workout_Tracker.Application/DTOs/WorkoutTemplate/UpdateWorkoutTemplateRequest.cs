namespace Workout_Tracker.Application.DTOs.WorkoutTemplate;

public class UpdateWorkoutTemplateRequest
{
    public string Name { get; init; } = string.Empty;
    public string ColorHex { get; init; } = "#808080";
    public List<UpdateWorkoutTemplateRequest> Exercises { get; init; } = new();
}
