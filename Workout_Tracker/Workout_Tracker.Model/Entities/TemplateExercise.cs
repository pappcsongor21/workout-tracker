using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_Tracker.Model.Entities
{
    public class TemplateExercise
    {
        public int Id { get; set; }

        public int ExerciseId { get; set;  }
        public Exercise Exercise { get; set; } = null!;

        public int WorkoutTemplateId { get; set; }
        public WorkoutTemplate WorkoutTemplate { get; set; } = null!;

        public int OrderNum { get; set; }
        public int TargetSets { get; set; }
        public int TargetRepsMin { get; set; }
        public int TargetRepsMax { get; set; }
    }
}
