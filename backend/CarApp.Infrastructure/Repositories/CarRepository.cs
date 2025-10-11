using CarApp.Domain.Entities;
using CarApp.Domain.Repositories;
using CarApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CarApp.Infrastructure.Repositories;

public class CarRepository : ICarRepository
{
    private readonly AppDbContext _context;
    public CarRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Car>> GetAllAsync() => await _context.Cars.ToListAsync();
    public async Task<Car?> GetByIdAsync(int id) => await _context.Cars.FindAsync(id);
    public async Task AddAsync(Car car)
    {
        _context.Cars.Add(car);
        await _context.SaveChangesAsync();
    }
}
