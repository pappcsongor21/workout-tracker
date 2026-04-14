using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using Workout_Tracker.Application.DTOs.Exercise;
using Workout_Tracker.Application.Interfaces;

namespace Workout_Tracker.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExercisesController : ControllerBase
{
    private readonly IExerciseService _service;

    public ExercisesController(IExerciseService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ExerciseResponse>>> GetExercisesAsync()
    {
        var exercises = await _service.GetAllExercisesAsync();
        return Ok(exercises);
    }

    [HttpGet("{id}", Name = "GetExerciseById")]
    public async Task<ActionResult<ExerciseResponse>> GetExerciseByIdAsync(int id)
    {
        var exercise = await _service.GetExerciseByIdAsync(id);
        return Ok(exercise);
    }

    [HttpPost]
    public async Task<ActionResult<ExerciseResponse>> CreateExerciseAsync([FromBody] CreateExerciseRequest exercise)
    {
        var createdExercise = await _service.CreateExerciseAsync(exercise);

        return CreatedAtRoute(
            "GetExerciseById", 
            new {id = createdExercise.Id}, 
            createdExercise);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateExerciseAsync(int id, UpdateExerciseRequest exerciseDto)
    {
        await _service.UpdateExerciseAsync(exerciseDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExerciseAsync(int id)
    {
        await _service.DeleteExerciseAsync(id);
        return NoContent();
    }
}
