using CarApp.Infrastructure.Data;
using CarApp.Infrastructure.Repositories;
using CarApp.Application.Services;
using CarApp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SQLite config
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite("Data Source=carapp.db"));

    

// DI
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<CarService>();

var app = builder.Build();

// Seed data
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated(); // Create DB if not exists
    db.SeedData();               // Insert initial cars
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllers();
app.Run();
