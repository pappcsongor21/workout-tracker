using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using Workout_Tracker.Application.DTOs.Exercise;
using Workout_Tracker.Application.Interfaces;

namespace Workout_Tracker.Api.Controllers
{
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
            var exercises = await _service.GetAllExercises();
            return Ok(exercises);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExerciseByIdAsync(int id)
        {
            var exercise = await _service.GetExerciseById(id);
            return Ok(exercise);
        }

        [HttpPost]
        public async Task<ActionResult<ExerciseResponse>> CreateExerciseAsync(CreateExerciseRequest exercise)
        {
            var createdExercise = await _service.CreateExercise(exercise);

            return CreatedAtAction(
                nameof(GetExerciseByIdAsync), 
                new {id = createdExercise.Id}, 
                createdExercise);
            //here nameof(method) results in a location(url with an id) at the end
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExerciseAsync(int id, UpdateExerciseRequest exerciseDto)
        {
            await _service.UpdateExercise(exerciseDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExerciseAsync(int id)
        {
            await _service.DeleteExercise(id);
            return NoContent();
        }
    }
}
