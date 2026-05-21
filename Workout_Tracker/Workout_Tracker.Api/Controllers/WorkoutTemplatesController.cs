using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workout_Tracker.Application.DTOs.WorkoutTemplate;
using Workout_Tracker.Application.Interfaces;

namespace Workout_Tracker.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkoutTemplatesController : ControllerBase
{
    private readonly IWorkoutTemplateService _service;

    public WorkoutTemplatesController(IWorkoutTemplateService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WorkoutTemplateResponse>>> GetWorkoutTemplatesAsync()
    {
        var workoutTemplates = await _service.GetWorkoutTemplatesAsync();
        return Ok(workoutTemplates);
    }

    [HttpGet("{id}", Name = "GetWorkoutTemplateById")]
    public async Task<ActionResult<WorkoutTemplateResponse>> GetWorkoutTemplateByIdAsync(int id)
    {
        var workoutTemplate = await _service.GetWorkoutTemplateByIdAsync(id);

        return Ok(workoutTemplate);
    }

    [HttpPost]
    public async Task<ActionResult<WorkoutTemplateResponse>> CreateWorkoutTemplate(CreateWorkoutTemplateRequest request)
    {
        var createdWorkoutTemplate = await _service.CreateWorkoutTemplateAsync(request);

        return CreatedAtRoute(
            "GetWorkoutTemplateById", 
            new {id =  createdWorkoutTemplate.Id},
            createdWorkoutTemplate);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWorkoutTemplateAsync
        (int id, UpdateWorkoutTemplateRequest workoutTemplateDto)
    {
        await _service.UpdateWorkoutTemplateAsync(id, workoutTemplateDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWorkoutTemplateAsync(int id)
    {
        await _service.DeleteWorkoutTemplateAsync(id);
        return NoContent();
    }
}
