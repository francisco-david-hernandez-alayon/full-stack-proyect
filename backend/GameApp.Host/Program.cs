using MongoDB.Driver;
using GameApp.Domain.Repositories;
using System.Text.Json.Serialization;
using GameApp.Application.Services.GameServices;
using SceneApp.Application.Services.SceneServices;
using GameApp.Application.Services.SceneServices;
using GameApp.Application.Services.ItemServices;
using GameApp.Adapter.Infrastructure.Repositories;
using GameApp.Adapter.Api;
using GameApp.Application.Services.EnemyServices;

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
// 1. Configure mongoDb conection
var mongoClient = new MongoClient("mongodb://localhost:27017"); 
var database = mongoClient.GetDatabase("GameAppDb");

// 2. Register IMongoDatabase and repository
builder.Services.AddSingleton(database);


// Configure services: Dependency Injection
// Item
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<ItemGetService>();
builder.Services.AddScoped<ItemCreateService>();
builder.Services.AddScoped<ItemUpdateService>();
builder.Services.AddScoped<ItemDeleteService>();

// Enemy
builder.Services.AddScoped<IEnemyRepository, EnemyRepository>();
builder.Services.AddScoped<EnemyGetService>();
builder.Services.AddScoped<EnemyCreateService>();
builder.Services.AddScoped<EnemyUpdateService>();
builder.Services.AddScoped<EnemyDeleteService>();

// Game
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<GameGetService>();
builder.Services.AddScoped<GameCreateService>();
builder.Services.AddScoped<GameUpdateService>();
builder.Services.AddScoped<GameDeleteService>();
builder.Services.AddScoped<IGameRepository>(sp =>
{
    var db = sp.GetRequiredService<IMongoDatabase>();
    var sceneRepo = sp.GetRequiredService<ISceneRepository>();
    var itemRepo = sp.GetRequiredService<IItemRepository>();
    var enemyRepo = sp.GetRequiredService<IEnemyRepository>();
    return new GameRepository(db, sceneRepo, itemRepo, enemyRepo);
});

// Scene
builder.Services.AddScoped<ISceneRepository, SceneRepository>();
builder.Services.AddScoped<SceneGetService>();
builder.Services.AddScoped<SceneCreateService>();
builder.Services.AddScoped<SceneUpdateService>();
builder.Services.AddScoped<SceneDeleteService>();
builder.Services.AddScoped<ISceneRepository>(sp =>
{
    var db = sp.GetRequiredService<IMongoDatabase>();
    var itemRepo = sp.GetRequiredService<IItemRepository>();
    var enemyRepo = sp.GetRequiredService<IEnemyRepository>();
    return new SceneRepository(db, itemRepo, enemyRepo);
});

var app = builder.Build();

// seed initial data
using (var scope = app.Services.CreateScope())
{
    var itemRepo = scope.ServiceProvider.GetRequiredService<IItemRepository>();
    var enemyRepo = scope.ServiceProvider.GetRequiredService<IEnemyRepository>();
    var sceneRepo = scope.ServiceProvider.GetRequiredService<ISceneRepository>();
    var gameRepo = scope.ServiceProvider.GetRequiredService<IGameRepository>();
    
    await itemRepo.SeedAsync();
    await enemyRepo.SeedAsync();
    await sceneRepo.SeedAsync();
    await gameRepo.SeedAsync();
    
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
