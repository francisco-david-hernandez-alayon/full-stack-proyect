using CarApp.Domain.Entities;

namespace CarApp.Domain.Repositories;

public interface ICarRepository
{
    Task<IEnumerable<Car>> GetAllAsync();
    Task<Car?> GetByIdAsync(int id);
    Task AddAsync(Car car);
}
