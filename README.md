# Workout Tracker

A comprehensive, full-stack web application designed for tracking and managing workouts, exercises, and custom workout templates. 

## 🚀 Features

- **Exercise Management:** Full CRUD operations for exercises, categorizing them by muscle group.
- **Workout Templates:** Create and manage custom workout templates with specific exercises, targeted sets, reps, intensity, and rest times.
- **Modern User Interface:** A responsive and interactive frontend built with React, Tailwind CSS, and Vite.
- **Layered Architecture:** A robust .NET 8 backend following clean architecture principles (API, Application, Model, Persistence layers).

## 🛠 Technology Stack

### Backend
- **Framework:** .NET 8, ASP.NET Core Web API
- **Database:** SQLite
- **ORM:** Entity Framework Core
- **Testing:** xUnit, Moq
- **Documentation:** Swagger UI

### Frontend
- **Framework:** React 19, TypeScript
- **Build Tool:** Vite
- **Styling:** Tailwind CSS v4
- **State Management & Data Fetching:** React Query (@tanstack/react-query)
- **Form Handling & Validation:** React Hook Form, Zod
- **Routing:** React Router DOM

## 📁 Project Structure

The solution consists of the following main modules:

### Backend Solution (`Workout_Tracker.slnx`)
- **`Workout_Tracker.Api`**: The entry point. Handles HTTP requests, contains the Controllers, and configures Swagger documentation.
- **`Workout_Tracker.Application`**: The business logic layer. Includes DTOs, custom exceptions, interfaces, and services.
- **`Workout_Tracker.Model` (Domain)**: Contains the core data model entities (`Exercise`, `Workout`, `WorkoutSet`, `WorkoutTemplate`, `TemplateExercise`).
- **`Workout_Tracker.Persistence`**: Handles database connections and EF Core migrations (`AppDbContext`).
- **`Workout_Tracker.Test`**: Contains unit tests focusing on testing the Controllers using mocked services.

### Frontend (`frontend/workout-tracker-ui`)
- A standalone React application communicating with the backend API.

## 🏁 Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (v18 or newer)
- npm or yarn

### Running the Backend Locally

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
5. The API will be available at http://localhost:5070 or https://localhost:7076. You can access the Swagger UI by navigating to /swagger.

### Running the Frontend Locally
1. Open a new terminal and navigate to the frontend directory:
```bash
cd frontend/workout-tracker-ui
```
2. Install dependencies:
   ```bash
   npm install
   ```
3. Start the development server:
   ```bash
   npm run dev
   ```
4. Open your browser and navigate to the URL provided by Vite (usually http://localhost:5173). Note: The frontend is configured to proxy API requests to https://localhost:7076


## Running Tests
To run the existing unit tests, execute the following command in the root of the project:
```bash
dotnet test
```
