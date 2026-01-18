using Microsoft.AspNetCore.Mvc;
using GameApp.Domain.Entities;
using GameApp.Domain.ValueObjects.Characters;
using GameApp.Domain.Enumerates;
using GameApp.Adapter.Api.Mappers;
using GameApp.Application.Services.GameServices;
using GameApp.Domain.Entities.Scenes;
using GameApp.Adapter.Api.dtos.GamesDto;

namespace GameApp.Adapter.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly GameGetService _getService;
    private readonly GameCreateService _createService;
    private readonly GameUpdateService _updateService;
    private readonly GameDeleteService _deleteService;
    private readonly GameGenerateNewSceneService _generateNewScene;

    public GameController(GameGetService getService, GameCreateService createService, GameUpdateService updateService, GameDeleteService deleteService, GameGenerateNewSceneService generateNewScene)
    {
        _getService = getService;
        _createService = createService;
        _updateService = updateService;
        _deleteService = deleteService;
        _generateNewScene = generateNewScene;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        // Use service
        var games = await _getService.GetAllGames();

        // Response
        return Ok(GameDtoMapper.ToDtoList(games));
    }



    [HttpGet("id/{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            // Use service
            Game? game = await _getService.GetGame(id);

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
            FinalScene finalScene = FinalSceneDtoMapper.ToDomain(request.FinalScene);
            List<Scene> currentScenes = request.ListCurrentScenes?
                .Select(SceneDtoMapper.ToDomain)
                .ToList() ?? new List<Scene>();
            List<UserAction> currentUserAction = request.ListCurrentUserActions;


            // Console.WriteLine("Game data to create: " + character, finalScene, currentScenes, currentUserAction);

            // Use service
            Game? createdGame = await _createService.CreateGame(
                request.Difficulty,
                character,
                request.NumberScenesToFinish,
                finalScene,
                currentScenes,
                currentUserAction
            );



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
            FinalScene finalScene = FinalSceneDtoMapper.ToDomain(request.FinalScene);
            List<Scene> completedScenes = request.ListCompletedScenes?
                .Select(SceneDtoMapper.ToDomain)
                .ToList() ?? new List<Scene>();
            List<Scene> currentScenes = request.ListCurrentScenes?
                .Select(SceneDtoMapper.ToDomain)
                .ToList() ?? new List<Scene>();
            List<UserAction> currentUserAction = request.ListCurrentUserActions;
            GameStatus status = request.Status;
            Enemy? currentEnemy = EnemyDtoMapper.ToDomainPosibleNull(request.CurrentEnemy);

            // Use service
            Game? updatedGame = await _updateService.UpdateGame(id, request.Difficulty, character, request.NumberScenesToFinish, completedScenes, finalScene, currentScenes, currentUserAction, status, currentEnemy);

            // Response
            return updatedGame is not null
                ? Ok(GameDtoMapper.ToDto(updatedGame))
                : Ok(GameDtoMapper.ToDto(new Game(id, request.Difficulty, character, request.NumberScenesToFinish, completedScenes, finalScene, currentScenes, currentUserAction, status, currentEnemy)));    // game not updated

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
            Game? deletedGame = await _deleteService.DeleteGame(id);

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




    // GENERATE NEW SCENE FOR GAME
    [HttpPut("next-scenes")]
    public async Task<IActionResult> GetNexScenesToGame([FromBody] GameNextSceneRequestDto request)
    {
        try
        {
            // Transform request Dto to Domain
            Game? currentGame = GameNextSceneDtoMapper.ToDomain(request);
            Guid idSceneSelected = request.IdSceneSelected;

            Console.WriteLine(currentGame.ToString());

            // Use service
            Game? updatedGame = await _generateNewScene.GenerateNewSceneToGame(idSceneSelected, currentGame);

            // Response
            return updatedGame is not null
                ? Ok(GameDtoMapper.ToDto(updatedGame))
                : BadRequest();

        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }


}
