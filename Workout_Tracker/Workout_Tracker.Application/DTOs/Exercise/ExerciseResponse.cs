using System.Security.Cryptography.X509Certificates;

namespace Workout_Tracker.Application.DTOs.Exercise
{
    public record ExerciseResponse(int Id, string Name, string MuscleGroup, string Description);
}
