using Microsoft.AspNetCore.Mvc;
using GameApp.Domain.Entities;
using GameApp.Domain.ValueObjects.Characters;
using GameApp.Domain.ValueObjects.Scenes;
using GameApp.Domain.Enumerates;
using GameApp.Api.Mappers;
using GameApp.Application.Services.SceneServices;
using SceneApp.Application.Services.SceneServices;
using GameApp.Api.dtos;

namespace GameApp.Api.Controllers;

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
        var Scenes = await _getService.GetAllScenesAsync();

        // Response
        return Ok(SceneDtoMapper.ToDtoList(Scenes));
    }



    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            // Use service
            Scene? Scene = await _getService.GetSceneAsync(id);

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


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] SceneCreateRequestDto request)
    {
        try
        {
            // Tansform request Dto to Domain
            Scene sceneToCreate = SceneDtoMapper.ToDomainFromCreateRequest(request);

            // Use service
            Scene? createdScene = await _createService.CreateSceneAsync(sceneToCreate);

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
            Scene? updatedScene = await _updateService.UpdateSceneAsync(id, sceneToCreate);

            Console.WriteLine("Scene updated: '" + updatedScene + "'");

            // Response
            return updatedScene is not null
                ? Ok(SceneDtoMapper.ToDto(updatedScene))
                : Ok(SceneDtoMapper.ToDto(sceneToCreate));    // Scene not updated

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
            Scene? deletedScene = await _deleteService.DeleteSceneAsync(id);

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
