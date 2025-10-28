namespace GameApp.Domain.ValueObjects.Items;


public abstract class Item
{
    private readonly ItemName Name;
    private readonly ItemDescription Description;

    protected Item(ItemName name, ItemDescription description)
    {
        Name = name;
        Description = description;
    }

    public ItemName GetName() => Name;
    public ItemDescription GetDescription() => Description;

}