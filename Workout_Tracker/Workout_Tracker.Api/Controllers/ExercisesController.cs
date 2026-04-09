using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using Workout_Tracker.Application.Interfaces;
using Workout_Tracker.Model.Entities;

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
        public async Task<IActionResult> GetExercises()
        {
            var exercises = await _service.GetAllExercises();
            return Ok(exercises);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExercise(Exercise exercise)
        {
            await _service.CreateExercise(exercise);

            return Ok(exercise);
        }
    }
}
