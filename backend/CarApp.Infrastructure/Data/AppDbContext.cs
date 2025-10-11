using Microsoft.EntityFrameworkCore;
using CarApp.Domain.Entities;

namespace CarApp.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Car> Cars => Set<Car>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public void SeedData()
    {
        if (!Cars.Any())
        {
            Cars.AddRange(
                new Car { Id = 1, Brand = "Toyota", Model = "Corolla" },
                new Car { Id = 2, Brand = "Honda", Model = "Civic" }
            );
            SaveChanges();
        }
    }
}
