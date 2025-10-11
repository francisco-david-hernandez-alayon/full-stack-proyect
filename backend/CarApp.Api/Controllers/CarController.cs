using Microsoft.AspNetCore.Mvc;
using CarApp.Application.Services;
using CarApp.Domain.Entities;

namespace CarApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarController : ControllerBase
{
    private readonly CarService _service;
    public CarController(CarService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _service.GetAllCarsAsync());

    [HttpPost]
    public async Task<IActionResult> Post(Car car)
    {
        await _service.AddCarAsync(car);
        return Ok(car);
    }
}
