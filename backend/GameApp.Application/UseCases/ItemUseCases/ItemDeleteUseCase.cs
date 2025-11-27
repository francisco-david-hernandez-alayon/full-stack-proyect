using GameApp.Domain.Entities.Items;


namespace GameApp.Application.UseCases.ItemUseCases;

public interface ItemDeleteUseCase
{
    public Task<Item?> DeleteItem(Guid id);
}