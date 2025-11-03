# EduvisionMVC

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
