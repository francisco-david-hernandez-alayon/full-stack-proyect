using GameApp.Domain.Entities.Items;


namespace GameApp.Application.UseCases.ItemUseCases;

public interface ItemUpdateUseCase
{
    public Task<Item?> UpdateItem(Guid id, Item item);
}