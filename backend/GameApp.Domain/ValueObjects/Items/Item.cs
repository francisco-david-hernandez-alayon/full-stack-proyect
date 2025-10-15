namespace GameApp.Domain.ValueObjects.Items;


public class Item
{
    protected readonly ItemName _name;
    protected readonly ItemDescription _description;

    protected Item(ItemName name, ItemDescription description)
    {
        _name = name;
        _description = description;
    }

    public ItemName GetName() => _name;
    public ItemDescription GetDescription() => _description;

}