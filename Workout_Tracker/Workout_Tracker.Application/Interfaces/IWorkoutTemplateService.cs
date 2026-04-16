using Workout_Tracker.Application.DTOs.WorkoutTemplate;

namespace Workout_Tracker.Application.Interfaces;

public interface IWorkoutTemplateService
{
    Task<IEnumerable<WorkoutTemplateResponse>> GetWorkoutTemplatesAsync();
    Task<WorkoutTemplateResponse> GetWorkoutTemplateByIdAsync(int id);
    Task<WorkoutTemplateResponse> CreateWorkoutTemplateAsync(CreateWorkoutTemplateRequest workoutTemplateDto);
    Task UpdateWorkoutTemplateAsync(UpdateWorkoutTemplateRequest workoutTemplateDto);
    Task DeleteWorkoutTemplateAsync(int id);
}
