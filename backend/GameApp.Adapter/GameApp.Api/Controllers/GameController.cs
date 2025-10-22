using Microsoft.AspNetCore.Mvc;
using GameApp.Application.Services;
using GameApp.Domain.Entities;
using GameApp.Domain.ValueObjects.Characters;
using GameApp.Domain.ValueObjects.Scenes;
using GameApp.Api.dtos;
using GameApp.Domain.Enumerates;

namespace GameApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly GameGetService _getService;
    private readonly GameCreateService _createService;
    private readonly GameUpdateService _updateService;
    private readonly GameDeleteService _deleteService;
    public GameController(GameGetService getService, GameCreateService createService, GameUpdateService updateService, GameDeleteService deleteService)
    {
        _getService = getService;
        _createService = createService;
        _updateService = updateService;
        _deleteService = deleteService;
    }

    [HttpGet]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var games = await _getService.GetAllGamesAsync();
        var dtos = games.Select(g => new GameResponseDto
        {
            Id = g.GetGuid(),
            CharacterType = "unknown",
            CompletedScenes = g.GetCompletedScenes()?.Select(s => s.GetName()?.ToString() ?? "unknown").ToList() ?? new List<string>(),
            FinalSceneName = g.GetFinalScene()?.GetName()?.ToString() ?? "unknown"
        });

        return Ok(dtos);
    }




    private Biomes ParseBiome(string biomeString)
    {
        if (Enum.TryParse<Biomes>(biomeString, true, out var biome))
            return biome;

        return Biomes.unknown;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] GameCreateRequestDto request)
    {
        try
        {
            // TEMPORAL: Tansform data form Dto
            Biomes biome = ParseBiome(request.FinalScene.Biome);
            NothingHappensScene finalScene = new NothingHappensScene(new SceneName(request.FinalScene.Name), new SceneDescription(request.FinalScene.Description), biome);

            Character warriorCharacter;

            if (request.Character.Type == "warrior")
            {
                warriorCharacter = new WarriorCharacter();
                Console.WriteLine("Warrior Character created");

                // default    
            }
            else
            {
                warriorCharacter = new WarriorCharacter();
            }


            // Use service
            Game? createdGame = await _createService.CreateGameAsync(
                warriorCharacter,
                request.NumberScenesToFinish,
                finalScene
            );

            Console.WriteLine("Game created: " + createdGame);

            // Response
            return createdGame is not null
                ? Ok(createdGame)
                : BadRequest("The game could not be created");

        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

}
