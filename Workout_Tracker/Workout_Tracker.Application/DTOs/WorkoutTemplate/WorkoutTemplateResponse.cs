using Workout_Tracker.Application.DTOs.TemplateExercise;

namespace Workout_Tracker.Application.DTOs.WorkoutTemplate;

public record WorkoutTemplateResponse
{
    public int Id { get; set; }
    public string Name { get; init; } = string.Empty;
    public string ColorHex {  get; init; } = "#808080";
    public List<TemplateExerciseResponse> Exercises { get; init; } = new List<TemplateExerciseResponse>(); 
}
