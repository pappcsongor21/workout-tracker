namespace Workout_Tracker.Application.DTOs.Exercise
{
    public record UpdateExerciseRequest(int Id, string Name, string MuscleGroup, string Description);
}
