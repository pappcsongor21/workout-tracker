# Workout Tracker

This is a .NET 8 based Web API project designed for tracking and managing workouts, exercises, and workout templates. The project follows a layered architecture, separating the data model, business logic, and API endpoints for easier maintenance.

## Technology Stack
- **Framework:** .NET 8
- **API:** ASP.NET Core Web API (Controllers)
- **Database:** SQLite, Entity Framework Core ORM
- **Testing:** xUnit, Moq

## Project Structure
The solution consists of the following main modules:
- **Workout_Tracker.Api:** The entry point of the application. It receives HTTP requests, contains the Controllers, and the Swagger documentation.
- **Workout_Tracker.Application:** The business logic layer. This includes DTOs (Data Transfer Objects), custom exceptions (e.g., `NotFoundException`), interfaces, and services (e.g., `ExerciseService`).
- **Workout_Tracker.Model (Domain):** Contains the core data model entities (`Exercise`, `Workout`, `WorkoutSet`, `WorkoutTemplate`, `TemplateExercise`).
- **Workout_Tracker.Persistence:** The layer responsible for database connection and migrations (`AppDbContext`).
- **Workout_Tracker.Test:** Contains the unit tests for the project, focusing on testing the Controllers and mocked services.

## Features
Currently, the system has the following capabilities:
- **Exercise Management:** Provides full CRUD (Create, Read, Update, Delete) operations via the `/api/Exercises` endpoint.
- **Data Model:** The data structure for workout templates (`WorkoutTemplate`) and specific workout logging (`Workout`) is ready, with a relational database schema.
- **Documentation:** Built-in Swagger UI for easy local testing of the endpoints.

## Running Locally

**Prerequisites:**
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

**Steps:**
1. Open a terminal in the root folder of the solution.
2. Restore the NuGet packages:
   ```bash
   dotnet restore
   ```
3. Initialize the database (run migrations). Since we are using SQLite, this will create a `workout.db` file in the Api project folder:
   ```bash
   dotnet ef database update --project Workout_Tracker.Persistence --startup-project Workout_Tracker.Api
   ```
4. Start the API:
   ```bash
   dotnet run --project Workout_Tracker.Api
   ```
5. Open the Swagger UI in your browser to manually test the endpoints (e.g., `http://localhost:5070/swagger` or the URL indicated by the console).

## Running Tests
To run the existing unit tests, execute the following command in the root of the project:
```bash
dotnet test
```
