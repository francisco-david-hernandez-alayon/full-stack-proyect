using Microsoft.AspNetCore.Mvc;
using GameApp.Application.Services;
using GameApp.Domain.Entities;
using GameApp.Domain.ValueObjects.Characters;
using GameApp.Domain.ValueObjects.Scenes;
using GameApp.Api.dtos;
using GameApp.Domain.Enumerates;
using GameApp.Api.Mappers;
using System.Text.Json;
using GameApp.Application.Services.GameServices;

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
    public async Task<IActionResult> Get()
    {
        // Use service
        var games = await _getService.GetAllGamesAsync();

        // Response
        return Ok(GameDtoMapper.ToDtoList(games));
    }



    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            // Use service
            Game? game = await _getService.GetGameAsync(id);

            // Response
            if (game is null)
                return NotFound($"Game with ID {id} not found.");

            return Ok(GameDtoMapper.ToDto(game));
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] GameCreateRequestDto request)
    {
        try
        {
            // Tansform request Dto to Domain
            Character character = CharacterDtoMapper.ToDomainFromType(request.Character);
            NothingHappensScene finalScene = FinalSceneDtoMapper.ToDomain(request.FinalScene);
            List<Scene> currentScenes = request.ListCurrentScenes?
                .Select(SceneDtoMapper.ToDomain)
                .ToList() ?? new List<Scene>();
            List<UserAction> currentUserAction = request.ListCurrentUserActions;

            // Use service
            Game? createdGame = await _createService.CreateGameAsync(
                character,
                request.NumberScenesToFinish,
                finalScene,
                currentScenes,
                currentUserAction
            );

            Console.WriteLine("Game created: " + createdGame);

            // Response
            return createdGame is not null
                ? Ok(GameDtoMapper.ToDto(createdGame))
                : BadRequest("The game could not be created");

        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }


    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] GameUpdateRequestDto request)
    {
        try
        {
            // Transform request Dto to Domain
            Character character = CharacterDtoMapper.ToDomain(request.Character);
            NothingHappensScene finalScene = FinalSceneDtoMapper.ToDomain(request.FinalScene);
            List<Scene> completedScenes = request.ListCompletedScenes?
                .Select(SceneDtoMapper.ToDomain)
                .ToList() ?? new List<Scene>();
            List<Scene> currentScenes = request.ListCurrentScenes?
                .Select(SceneDtoMapper.ToDomain)
                .ToList() ?? new List<Scene>();
            List<UserAction> currentUserAction = request.ListCurrentUserActions;

            // Use service
            Game? updatedGame = await _updateService.UpdateGameAsync(id, character, request.NumberScenesToFinish, completedScenes, finalScene, currentScenes, currentUserAction);

            Console.WriteLine("Game updated: '" + updatedGame + "'");

            // Response
            return updatedGame is not null
                ? Ok(GameDtoMapper.ToDto(updatedGame))
                : Ok(GameDtoMapper.ToDto(new Game(id, character, request.NumberScenesToFinish, completedScenes, finalScene, currentScenes, currentUserAction)));    // game not updated

        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }


    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            // Use service
            Game? deletedGame = await _deleteService.DeleteGameAsync(id);

            // Response
            if (deletedGame is null)
                return NotFound($"Game with ID {id} not found.");

            return Ok(GameDtoMapper.ToDto(deletedGame));
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }


}
