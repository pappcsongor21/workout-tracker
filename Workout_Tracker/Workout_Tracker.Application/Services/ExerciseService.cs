using Microsoft.EntityFrameworkCore;
using Workout_Tracker.Application.DTOs.Exercise;
using Workout_Tracker.Application.Exceptions;
using Workout_Tracker.Application.Interfaces;
using Workout_Tracker.Model.Entities;
using Workout_Tracker.Persistence;

namespace Workout_Tracker.Application.Services;

public class ExerciseService : IExerciseService
{
    private readonly AppDbContext _context;

    public ExerciseService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ExerciseResponse>> GetAllExercisesAsync()
    {
        var exercises = await _context.Exercises.ToListAsync();
        var exerciseDtos = exercises.Select(e => new ExerciseResponse
        {
            Id = e.Id,
            Name = e.Name,
            MuscleGroup = e.MuscleGroup,
            Description = e.Description
        }).ToList();

        return exerciseDtos;
    }

    public async Task<ExerciseResponse> GetExerciseByIdAsync(int id)
    {
        var exercise = await _context.Exercises.FirstOrDefaultAsync(e => e.Id == id);

        if (exercise == null) throw new NotFoundException(nameof(Exercise), id);


        return new ExerciseResponse
        {
            Id = exercise.Id,
            Name = exercise.Name,
            MuscleGroup = exercise.MuscleGroup,
            Description = exercise.Description
        };
    }

    public async Task<ExerciseResponse> CreateExerciseAsync(CreateExerciseRequest exerciseDto)
    {
        var newExercise = new Exercise
        {
            Name = exerciseDto.Name,
            MuscleGroup = exerciseDto.MuscleGroup,
            Description = exerciseDto.Description
        };
        await _context.AddAsync(newExercise);
        await _context.SaveChangesAsync();

        return new ExerciseResponse
        {
            Id = newExercise.Id,
            Name = newExercise.Name,
            MuscleGroup = newExercise.MuscleGroup,
            Description = newExercise.Description
        };
    }

    public async Task UpdateExerciseAsync(UpdateExerciseRequest exerciseDto)
    {
        var exercise = await _context.Exercises.FirstOrDefaultAsync(e => e.Id == exerciseDto.Id);

        if (exercise == null) throw new NotFoundException(nameof(Exercise), exerciseDto.Id);

        exercise.Name = exerciseDto.Name;
        exercise.MuscleGroup = exerciseDto.MuscleGroup;
        exercise.Description = exerciseDto.Description;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteExerciseAsync(int id)
    {
        var exercise = await _context.Exercises.FirstOrDefaultAsync(e => e.Id == id);

        if (exercise == null) throw new NotFoundException(nameof(Exercise), id);

        _context.Exercises.Remove(exercise);
        await _context.SaveChangesAsync();
    }
}
