namespace GameApp.Domain.ValueObjects.Items;


public class Item
{
    private readonly ItemName _name;
    private readonly ItemDescription _description;

    public Item(ItemName name, ItemDescription description)
    {
        _name = name;
        _description = description;
    }

    public ItemName GetName() => _name;
    public ItemDescription GetDescription() => _description;

}