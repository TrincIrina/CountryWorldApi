using CountryWorldApi;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>();
var app = builder.Build();

app.MapGet("/api", () => new { Message = "server is running" });
app.MapGet("/api/ping", () => new { Message = "pong" });

// CRUD-обработчики

// 1. GET /api/country
app.MapGet("/api/country", async (ApplicationDbContext db) =>
{
    return await db.Countries.ToListAsync();
});

// 2. GET /api/country/{id}
app.MapGet("/api/country/{id:int}", async (int id, ApplicationDbContext db) =>
{
    return await db.Countries.FirstOrDefaultAsync(d => d.Id == id);
});

// 3. POST /api/country
app.MapPost("/api/country", async (Country country, ApplicationDbContext db) =>
{
    await db.Countries.AddAsync(country);
    await db.SaveChangesAsync();
    return country;
});

// 4. DELETE /api/country/{id}
app.MapDelete("/api/country/{id:int}", async (int id, ApplicationDbContext db) =>
{
    Country? deleted = await db.Countries.FirstOrDefaultAsync(d => d.Id == id);
    if (deleted != null)
    {
        db.Countries.Remove(deleted);
        await db.SaveChangesAsync();
    }
});

app.Run();
