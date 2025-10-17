using Microsoft.AspNetCore.Mvc;
using GameApp.Application.Services;
using GameApp.Domain.Entities;

namespace GameApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly GameService _service;
    public GameController(GameService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _service.GetAllGamesAsync());

    [HttpPost]
    public async Task<IActionResult> Post(Game game)
    {
        await _service.AddGameAsync(game);
        return Ok(game);
    }
}
