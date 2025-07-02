using CoffeeAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=barista.db"));

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowExpoApp", policy =>
    {
        policy.AllowAnyOrigin()     // For development - allows any origin
            .AllowAnyMethod()     // Allows GET, POST, PUT, DELETE, etc.
            .AllowAnyHeader();    // Allows any headers
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
    DbInitializer.Seed(db);
}

// Enable CORS - THIS MUST BE BEFORE MapControllers()
app.UseCors("AllowExpoApp");

app.MapControllers();
app.Run();
