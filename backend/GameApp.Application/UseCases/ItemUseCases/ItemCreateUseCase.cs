using GameApp.Domain.Entities.Items;


namespace GameApp.Application.UseCases.ItemUseCases;

public interface ItemCreateUseCase
{
    public Task<Item?> CreateItem(Item item);
}