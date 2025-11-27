using GameApp.Application.UseCases.ItemUseCases;
using GameApp.Domain.Entities.Items;
using GameApp.Domain.Repositories;

namespace GameApp.Application.Services.ItemServices;

public class ItemDeleteService : ItemDeleteUseCase
{
    private readonly IItemRepository _repo;

    public ItemDeleteService(IItemRepository repo) => _repo = repo;

    public async Task<Item?> DeleteItem(Guid id)
    {
        return await _repo.DeleteAsync(id);
    }
}