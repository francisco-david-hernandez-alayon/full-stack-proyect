using MongoDB.Driver;
using GameApp.Domain.Repositories;
using GameApp.Api;
using System.Text.Json.Serialization;
using GameApp.Infrastructure.Repositories;
using GameApp.Application.Services.GameServices;

var builder = WebApplication.CreateBuilder(args);

// Configure Api: Add API controllers from Api project using a marker class
builder.Services.AddControllers()
       .AddApplicationPart(typeof(Marker).Assembly)
       .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Configure Infrastructure
// 1. Configure mongoDb conexion
var mongoClient = new MongoClient("mongodb://localhost:27017"); 
var database = mongoClient.GetDatabase("GameAppDb");

// 2. Register IMongoDatabase and repository
builder.Services.AddSingleton(database);
builder.Services.AddScoped<IGameRepository, GameRepository>();


// Configure services: Dependency Injection
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<GameGetService>();
builder.Services.AddScoped<GameCreateService>();
builder.Services.AddScoped<GameUpdateService>();
builder.Services.AddScoped<GameDeleteService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllers();
app.Run();
