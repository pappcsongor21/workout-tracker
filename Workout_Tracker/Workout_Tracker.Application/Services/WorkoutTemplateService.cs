using Microsoft.EntityFrameworkCore;
using Workout_Tracker.Application.DTOs.Exercise;
using Workout_Tracker.Application.DTOs.TemplateExercise;
using Workout_Tracker.Application.DTOs.WorkoutTemplate;
using Workout_Tracker.Application.Exceptions;
using Workout_Tracker.Application.Interfaces;
using Workout_Tracker.Model.Entities;
using Workout_Tracker.Persistence;

namespace Workout_Tracker.Application.Services;

public class WorkoutTemplateService : IWorkoutTemplateService
{
    private readonly AppDbContext _context;

    public WorkoutTemplateService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<WorkoutTemplateResponse>> GetWorkoutTemplatesAsync()
    {
        var responseDtos = await _context.WorkoutTemplates
            .Select(w => new WorkoutTemplateResponse
            {
                Id = w.Id,
                ColorHex = w.ColorHex,
                Name = w.Name,
                Exercises = w.Exercises.Select(e => new TemplateExerciseResponse
                {
                    Id = e.Id,
                    OrderNum = e.OrderNum,
                    TargetSets = e.TargetSets,
                    TargetRepsMin = e.TargetRepsMin,
                    TargetRepsMax = e.TargetRepsMax,
                    TargetIntensity = e.TargetIntensity,

                    Exercise = new ExerciseResponse
                    {
                        Id = e.Exercise.Id,
                        Name = e.Exercise.Name,
                        MuscleGroup = e.Exercise.MuscleGroup,
                        Description = e.Exercise.Description
                    }
                }).ToList()
            })
        .ToListAsync();

        return responseDtos;
    }

    public async Task<WorkoutTemplateResponse> GetWorkoutTemplateByIdAsync(int id)
    {
        var workoutTemplate = await _context.WorkoutTemplates
            .Include(w => w.Exercises)
            .ThenInclude(e => e.Exercise)
            .FirstOrDefaultAsync(w => w.Id == id);

        if (workoutTemplate == null)
        {
            throw new NotFoundException(nameof(WorkoutTemplate), id);
        }

        var responseDto = new WorkoutTemplateResponse
        {
            Id = workoutTemplate.Id,
            ColorHex = workoutTemplate.ColorHex,
            Name = workoutTemplate.Name,
            Exercises = workoutTemplate.Exercises.Select(e => new TemplateExerciseResponse
            {
                Id = e.Id,
                OrderNum = e.OrderNum,
                TargetSets = e.TargetSets,
                TargetRepsMin = e.TargetRepsMin,
                TargetRepsMax = e.TargetRepsMax,
                TargetIntensity = e.TargetIntensity,

                Exercise = new ExerciseResponse
                {
                    Id = e.Exercise.Id,
                    Name = e.Exercise.Name,
                    MuscleGroup = e.Exercise.MuscleGroup,
                    Description = e.Exercise.Description
                }
            }).ToList()
        };

        return responseDto;
    }

    public async Task<WorkoutTemplateCreatedResponse> CreateWorkoutTemplateAsync(CreateWorkoutTemplateRequest request)
    {
        var template = new WorkoutTemplate
        {
            Name = request.Name,
            ColorHex = request.ColorHex,
            Exercises = request.Exercises.Select(e => new TemplateExercise
            {
                ExerciseId = e.ExerciseId,
                OrderNum = e.OrderNum,
                TargetSets = e.TargetSets,
                TargetRepsMin = e.TargetRepsMin,
                TargetRepsMax = e.TargetRepsMax,
                TargetIntensity = e.TargetIntensity,
                RestSeconds = e.RestSeconds
            }).ToList()
        };

        await _context.AddAsync(template);
        await _context.SaveChangesAsync();

        var responseDto = new WorkoutTemplateCreatedResponse
        {
            Id = template.Id,
            Name = template.Name,
            ColorHex = template.ColorHex,
            Exercises = template.Exercises.Select(e => new TemplateExerciseCreatedResponse
            {
                Id = e.Id,
                ExerciseId = e.ExerciseId,
                OrderNum = e.OrderNum,
                TargetSets = e.TargetSets,
                TargetRepsMin = e.TargetRepsMin,
                TargetRepsMax = e.TargetRepsMax,
                TargetIntensity = e.TargetIntensity,
                RestSeconds = e.RestSeconds
            }).ToList()
        };

        return responseDto;
    }

    public Task DeleteWorkoutTemplateAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateWorkoutTemplateAsync(UpdateWorkoutTemplateRequest workoutTemplateDto)
    {
        throw new NotImplementedException();
    }
}
