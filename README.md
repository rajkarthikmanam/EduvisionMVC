# EduvisionMVC

Dynamic ASP.NET Core MVC app with EF Core (SQLite for dev), full CRUD (Students, Courses, Enrollments, Departments, Instructors), API demo, and Chart.js visualization.

---

## API Endpoints

- `GET /api/health` — service heartbeat (UTC time).
- `GET /api/stats` — aggregate counts (students, courses, departments, instructors).
- `GET /api/charts/gradesByCourse` — JSON for Chart.js (avg grades by course).
- `GET /api/charts/enrollmentByDept` — JSON for Chart.js (enrollments by department).

> External calls use timeouts + graceful fallbacks. Dev DB is created via EF Core migrations.

---

## Run locally

```bash
dotnet build
dotnet ef database update
dotnet watch
# open https://localhost:5xxx
