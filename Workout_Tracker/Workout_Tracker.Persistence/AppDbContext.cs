using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workout_Tracker.Model.Entities;

namespace Workout_Tracker.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<TemplateExercise> TemplateExercises { get; set; }
    public DbSet<WorkoutTemplate> WorkoutTemplates { get; set; }
    public DbSet<WorkoutSet> WorkoutSets { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}
