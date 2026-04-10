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
        Task<List<ExerciseResponse>> GetAllExercises();
        Task<ExerciseResponse> GetExerciseById(int id);
        Task<ExerciseResponse> CreateExercise(CreateExerciseRequest exerciseDto);
        Task UpdateExercise(UpdateExerciseRequest exerciseDto);
        Task DeleteExercise(int id);
    }
}
