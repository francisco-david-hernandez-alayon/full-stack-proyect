using Microsoft.AspNetCore.Mvc;
using GameApp.Domain.Entities.Items;
using GameApp.Adapter.Api.Mappers;
using GameApp.Application.Services.ItemServices;
using GameApp.Adapter.Api.dtos.ItemsDto;
using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Adapter.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemController : ControllerBase
{
    private readonly ItemGetService _getService;
    private readonly ItemCreateService _createService;
    private readonly ItemUpdateService _updateService;
    private readonly ItemDeleteService _deleteService;

    public ItemController(
        ItemGetService getService,
        ItemCreateService createService,
        ItemUpdateService updateService,
        ItemDeleteService deleteService)
    {
        _getService = getService;
        _createService = createService;
        _updateService = updateService;
        _deleteService = deleteService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var items = await _getService.GetAllItems();
        return Ok(ItemDtoMapper.ToDtoList(items));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            Item? item = await _getService.GetItem(id);
            if (item is null)
                return NotFound($"Item with ID {id} not found.");

            return Ok(ItemDtoMapper.ToDto(item));
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
            Item? item = await _getService.GetItemByName(new ItemName(name));
            if (item is null)
                return NotFound($"Item with name {name} not found.");

            return Ok(ItemDtoMapper.ToDto(item));
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ItemCreateRequestDto request)
    {
        try
        {
            Item itemToCreate = ItemDtoMapper.ToDomainFromCreateRequest(request);
            Item? createdItem = await _createService.CreateItem(itemToCreate);

            return createdItem is not null
                ? Ok(ItemDtoMapper.ToDto(createdItem))
                : BadRequest("The Item could not be created");
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] ItemUpdateRequestDto request)
    {
        try
        {
            Item itemToUpdate = ItemDtoMapper.ToDomainFromUpdateRequest(request);
            Item? updatedItem = await _updateService.UpdateItem(id, itemToUpdate);

            return updatedItem is not null
                ? Ok(ItemDtoMapper.ToDto(updatedItem))
                : NotFound(); // Item not updated
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
            Item? deletedItem = await _deleteService.DeleteItem(id);

            if (deletedItem is null)
                return NotFound($"Item with ID {id} not found.");

            return Ok(ItemDtoMapper.ToDto(deletedItem));
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
