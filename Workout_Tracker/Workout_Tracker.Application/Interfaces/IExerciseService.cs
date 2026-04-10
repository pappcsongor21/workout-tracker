using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workout_Tracker.Application.DTOs.Exercise;
using Workout_Tracker.Model.Entities;

namespace Workout_Tracker.Application.Interfaces
{
    public interface IExerciseService
    {
        Task<IEnumerable<ExerciseResponse>> GetAllExercisesAsync();
        Task<ExerciseResponse> GetExerciseByIdAsync(int id);
        Task<ExerciseResponse> CreateExerciseAsync(CreateExerciseRequest exerciseDto);
        Task UpdateExerciseAsync(UpdateExerciseRequest exerciseDto);
        Task DeleteExerciseAsync(int id);
    }
}
