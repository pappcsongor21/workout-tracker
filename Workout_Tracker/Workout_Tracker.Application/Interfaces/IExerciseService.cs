using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workout_Tracker.Model.Entities;

namespace Workout_Tracker.Application.Interfaces
{
    public interface IExerciseService
    {
        Task<List<Exercise>> GetAllExercises();
        Task CreateExercise(Exercise exercise);
    }
}
