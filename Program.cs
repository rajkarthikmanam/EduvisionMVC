using EduvisionMvc.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// SQLite under App_Data
var dbPath = Path.Combine(builder.Environment.ContentRootPath, "App_Data", "app.db");
builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlite($"Data Source={dbPath}"));

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient(); // For calling external APIs

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// (Optional) JSON for chart from Enrollments DB data
app.MapGet("/api/charts/gradesByCourse", async (AppDbContext db) =>
{
    var q = db.Enrollments
        .Include(e => e.Course)
        .GroupBy(e => e.Course!.Code)
        .Select(g => new { code = g.Key, avg = Math.Round((double)g.Average(x => x.Numeric_Grade), 2) })
        .OrderBy(x => x.code)
        .ToList();

    return Results.Json(new { labels = q.Select(x => x.code), values = q.Select(x => x.avg) });
});

app.Run();
