using Microsoft.AspNetCore.Mvc;
using Moq;
using Workout_Tracker.Api.Controllers;
using Workout_Tracker.Application.DTOs.Exercise;
using Workout_Tracker.Application.Interfaces;

namespace Workout_Tracker.Tests.Controllers
{
    public class ExerciseControllerTests
    {
        private readonly Mock<IExerciseService> _mockService;
        private readonly ExercisesController _controller;

        public ExerciseControllerTests()
        {
            _mockService = new Mock<IExerciseService>();
            _controller = new ExercisesController(_mockService.Object);
        }

        [Fact]
        public async Task GetExercisesAsync_WhenExercisesExist_ReturnsOkResult()
        {
            var expectedExercises = new List<ExerciseResponse>
            {
                new ExerciseResponse { Id = 1, Name = "Pullup", MuscleGroup = "Back", Description = "Back pocket."},
                new ExerciseResponse { Id = 2, Name= "Dip", MuscleGroup = "Chest", Description = "Controlled."}
            };

            _mockService.Setup(s => s.GetAllExercisesAsync()).ReturnsAsync(expectedExercises);

            var result = await _controller.GetExercisesAsync();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            var returnedExercises = Assert.IsAssignableFrom<IEnumerable<ExerciseResponse>>(okResult.Value);

            Assert.Equal(2, returnedExercises.Count());
        }

        [Fact]
        public async Task GetExerciseByIdAsync_WhenExerciseExists_ReturnsOkResult()
        {
            var expectedExercise = new ExerciseResponse
            {
                Id = 1,
                Name = "Pullup",
                MuscleGroup = "Back",
                Description = "Full rom"
            };

            _mockService.Setup(s => s.GetExerciseByIdAsync(expectedExercise.Id)).ReturnsAsync(expectedExercise);

            var result = await _controller.GetExerciseByIdAsync(expectedExercise.Id);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            var returnedExercise = Assert.IsType<ExerciseResponse>(okResult.Value);

            Assert.Equal(expectedExercise.Name, returnedExercise.Name);
        }

        [Fact]
        public async Task CreateExerciseAsync_Generally_ReturnCreatedAtRouteResult()
        {
            var request = new CreateExerciseRequest
            {
                Name = "Dip",
                MuscleGroup = "Chest",
                Description = "On parallel bars"
            };

            var expectedResponse = new ExerciseResponse
            {
                Id = 5,
                Name = "Dip",
                MuscleGroup = "Chest",
                Description = "On parallel bars"
            };

            _mockService.Setup(s => s.CreateExerciseAsync(It.IsAny<CreateExerciseRequest>())).ReturnsAsync(expectedResponse);

            var result = await _controller.CreateExerciseAsync(request);

            var createdAtRouteResult = Assert.IsType<CreatedAtRouteResult>(result.Result);

            Assert.Equal("GetExerciseById", createdAtRouteResult.RouteName);

            Assert.NotNull(createdAtRouteResult.RouteValues);
            Assert.True(createdAtRouteResult.RouteValues.ContainsKey("id"));
            Assert.Equal(expectedResponse.Id, createdAtRouteResult.RouteValues["id"]);

            var returnedValue = Assert.IsType<ExerciseResponse>(createdAtRouteResult.Value);
            Assert.Equal(expectedResponse.Id, returnedValue.Id);
            Assert.Equal(expectedResponse.Name, returnedValue.Name);

        }
    }
}
