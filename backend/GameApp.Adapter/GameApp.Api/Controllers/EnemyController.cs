using Microsoft.AspNetCore.Mvc;
using GameApp.Application.Services.EnemyServices;
using GameApp.Adapter.Api.Mappers;
using GameApp.Domain.ValueObjects.Enemies;
using GameApp.Domain.Entities;
using GameApp.Adapter.Api.dtos.EnemysDtos;

namespace GameApp.Adapter.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnemyController : ControllerBase
{
    private readonly EnemyGetService _getService;
    private readonly EnemyCreateService _createService;
    private readonly EnemyUpdateService _updateService;
    private readonly EnemyDeleteService _deleteService;

    public EnemyController(
        EnemyGetService getService,
        EnemyCreateService createService,
        EnemyUpdateService updateService,
        EnemyDeleteService deleteService)
    {
        _getService = getService;
        _createService = createService;
        _updateService = updateService;
        _deleteService = deleteService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var enemies = await _getService.GetAllEnemys();
        return Ok(EnemyDtoMapper.ToDtoList(enemies));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            Enemy? enemy = await _getService.GetEnemy(id);
            if (enemy is null)
                return NotFound($"Enemy with ID {id} not found.");

            return Ok(EnemyDtoMapper.ToDto(enemy));
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
            Enemy? enemy = await _getService.GetEnemyByName(new EnemyName(name));
            if (enemy is null)
                return NotFound($"Enemy with name {name} not found.");

            return Ok(EnemyDtoMapper.ToDto(enemy));
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EnemyCreateRequestDto request)
    {
        try
        {
            Enemy enemyToCreate = EnemyDtoMapper.ToDomainFromCreateRequest(request);
            Enemy? createdEnemy = await _createService.CreateEnemy(enemyToCreate);

            return createdEnemy is not null
                ? Ok(EnemyDtoMapper.ToDto(createdEnemy))
                : BadRequest("The Enemy could not be created");
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] EnemyUpdateRequestDto request)
    {
        try
        {
            Enemy enemyToUpdate = EnemyDtoMapper.ToDomainFromUpdateRequest(request);
            Enemy? updatedEnemy = await _updateService.UpdateEnemy(id, enemyToUpdate);

            return updatedEnemy is not null
                ? Ok(EnemyDtoMapper.ToDto(updatedEnemy))
                : NotFound();
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
            Enemy? deletedEnemy = await _deleteService.DeleteEnemy(id);

            if (deletedEnemy is null)
                return NotFound($"Enemy with ID {id} not found.");

            return Ok(EnemyDtoMapper.ToDto(deletedEnemy));
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
