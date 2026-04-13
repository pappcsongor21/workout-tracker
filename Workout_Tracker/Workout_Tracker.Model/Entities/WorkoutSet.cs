using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_Tracker.Model.Entities;

public class WorkoutSet
{
    public int Id { get; set; }
    public int ExerciseId { get; set; }
    public Exercise Exercise { get; set; } = null!;

    public int OrderNum {  get; set; }
    public int TargetReps { get; set; }
    public int TargetIntensity { get; set; }
    public int ActualReps { get; set; }
    public int ActualIntensity { get; set; }
    public int RPE { get; set; }
}
