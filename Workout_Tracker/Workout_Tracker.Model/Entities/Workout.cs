using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_Tracker.Model.Entities;

public class Workout
{
    public int Id { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public ICollection<WorkoutSet> Sets { get; set; } = new List<WorkoutSet>();
    public string Notes {  get; set; } = string.Empty;
}
