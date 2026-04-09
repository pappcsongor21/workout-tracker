using Microsoft.EntityFrameworkCore;
using Workout_Tracker.Application.Interfaces;
using Workout_Tracker.Application.Services;
using Workout_Tracker.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=workout.db"));

builder.Services.AddScoped<IExerciseService, ExerciseService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
