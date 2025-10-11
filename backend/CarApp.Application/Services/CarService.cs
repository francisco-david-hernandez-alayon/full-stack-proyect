using CarApp.Domain.Entities;
using CarApp.Domain.Repositories;

namespace CarApp.Application.Services;

public class CarService
{
    private readonly ICarRepository _repo;
    public CarService(ICarRepository repo) => _repo = repo;

    public Task<IEnumerable<Car>> GetAllCarsAsync() => _repo.GetAllAsync();
    public Task AddCarAsync(Car car) => _repo.AddAsync(car);
}
