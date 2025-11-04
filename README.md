# EduvisionMVC

<<<<<<< HEAD
Dynamic ASP.NET Core MVC app with EF Core (SQLite dev), CRUD,
API demo (/Api), and a Chart.js visualization.
## Technical Overview

- EF Core with SQLite (dev). Azure SQL supported for production.
- CRUD: Students, Courses, Enrollments (+ Departments, Instructors).
- API demo: /Api (multiple public sources, graceful error handling).
- Visualization: /Home/Visualize calls /api/charts/gradesByCourse (Chart.js).
## Technical Overview

- EF Core with SQLite (dev). Azure SQL supported for production.
- CRUD: Students, Courses, Enrollments (+ Departments, Instructors).
- API demo: /Api (multiple public sources, graceful error handling).
- Visualization: /Home/Visualize calls /api/charts/gradesByCourse (Chart.js).
=======
Dynamic ASP.NET Core MVC app with EF Core (SQLite for dev), CRUD, API demo, and a Chart.js visualization.

## API Endpoints

- `GET /api/health` — service heartbeat (UTC time).
- `GET /api/stats` — counts for students, courses, departments, instructors.
- `GET /api/charts/gradesByCourse` — data for Chart.js (avg grades) *(if enabled)*.
- `GET /api/charts/enrollmentByDept` — data for Chart.js *(if enabled)*.

## Run locally
dotnet build
dotnet watch
# then browse: https://localhost:5xxx
>>>>>>> 8e8bb26ee0279e2982461c883391765ecd67e26a
