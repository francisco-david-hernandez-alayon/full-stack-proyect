using Microsoft.AspNetCore.Mvc;
using GameApp.Domain.ValueObjects.Scenes;
using GameApp.Domain.Entities.Scenes;
using GameApp.Adapter.Api.Mappers;
using GameApp.Application.Services.SceneServices;
using SceneApp.Application.Services.SceneServices;
using GameApp.Adapter.Api.dtos.ScenesDto;

namespace GameApp.Adapter.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SceneController : ControllerBase
{
    private readonly SceneGetService _getService;
    private readonly SceneCreateService _createService;
    private readonly SceneUpdateService _updateService;
    private readonly SceneDeleteService _deleteService;
    public SceneController(SceneGetService getService, SceneCreateService createService, SceneUpdateService updateService, SceneDeleteService deleteService)
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
        var Scenes = await _getService.GetAllScenes();

        // Response
        return Ok(SceneDtoMapper.ToDtoList(Scenes));
    }

    [HttpGet("final-scenes")]
    public async Task<IActionResult> GetFinalScenes()
    {
        // Use service
        var Scenes = await _getService.GetAllFinalScenes();

        // Response
        return Ok(SceneDtoMapper.ToDtoList(Scenes));
    }



    [HttpGet("id/{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            // Use service
            Scene? Scene = await _getService.GetScene(id);

            // Response
            if (Scene is null)
                return NotFound($"Scene with ID {id} not found.");

            return Ok(SceneDtoMapper.ToDto(Scene));
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpGet("name/{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        try
        {
            // Use service
            Scene? Scene = await _getService.GetSceneByName(new SceneName(name));

            // Response
            if (Scene is null)
                return NotFound($"Scene with name {name} not found.");

            return Ok(SceneDtoMapper.ToDto(Scene));
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] SceneCreateRequestDto request)
    {
        try
        {
            // Tansform request Dto to Domain
            Scene sceneToCreate = SceneDtoMapper.ToDomainFromCreateRequest(request);

            // Use service
            Scene? createdScene = await _createService.CreateScene(sceneToCreate);

            Console.WriteLine("Scene created: " + createdScene);

            // Response
            return createdScene is not null
                ? Ok(SceneDtoMapper.ToDto(createdScene))
                : BadRequest("The Scene could not be created");

        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }


    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] SceneUpdateRequestDto request)
    {
        try
        {
            // Transform request Dto to Domain
            Scene sceneToCreate = SceneDtoMapper.ToDomainFromUpdateRequest(request);

            // Use service
            Scene? updatedScene = await _updateService.UpdateScene(id, sceneToCreate);

            Console.WriteLine("Scene updated: '" + updatedScene + "'");

            // Response
            return updatedScene is not null
                ? Ok(SceneDtoMapper.ToDto(updatedScene))
                : NotFound();    // Scene not updated

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
            Scene? deletedScene = await _deleteService.DeleteScene(id);

            // Response
            if (deletedScene is null)
                return NotFound($"Scene with ID {id} not found.");

            return Ok(SceneDtoMapper.ToDto(deletedScene));
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }


}
