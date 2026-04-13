using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_Tracker.Model.Entities;

public class WorkoutTemplate
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int ColorNum { get; set; }

    public ICollection<TemplateExercise> Exercises { get; set; } = new HashSet<TemplateExercise>();
}
