using Workout_Tracker.Application.DTOs.TemplateExercise;

namespace Workout_Tracker.Application.DTOs.WorkoutTemplate;

public class UpdateWorkoutTemplateRequest
{
    public string Name { get; init; } = string.Empty;
    public string ColorHex { get; init; } = "#808080";
    public List<UpdateTemplateExerciseRequest> Exercises { get; init; } = new();
}
