using GameApp.Infrastructure.Data;
using GameApp.Infrastructure.Repositories;
using GameApp.Application.Services;
using GameApp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using GameApp.Api;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add API controllers from Api project using a marker class
builder.Services.AddControllers()
       .AddApplicationPart(typeof(Marker).Assembly)
       .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Infrastructure
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite("Data Source=gameapp.db"));

// Dependency Injection
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<GameGetService>();
builder.Services.AddScoped<GameCreateService>();
builder.Services.AddScoped<GameUpdateService>();
builder.Services.AddScoped<GameDeleteService>();

var app = builder.Build();

// Seed database
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
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
