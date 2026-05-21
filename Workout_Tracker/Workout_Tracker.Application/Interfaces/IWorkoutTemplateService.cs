using Workout_Tracker.Application.DTOs.WorkoutTemplate;

namespace Workout_Tracker.Application.Interfaces;

public interface IWorkoutTemplateService
{
    Task<IEnumerable<WorkoutTemplateResponse>> GetWorkoutTemplatesAsync();
    Task<WorkoutTemplateResponse> GetWorkoutTemplateByIdAsync(int id);
    Task<WorkoutTemplateCreatedResponse> CreateWorkoutTemplateAsync(CreateWorkoutTemplateRequest workoutTemplateDto);
    Task UpdateWorkoutTemplateAsync(int id, UpdateWorkoutTemplateRequest workoutTemplateDto);
    Task DeleteWorkoutTemplateAsync(int id);
}
