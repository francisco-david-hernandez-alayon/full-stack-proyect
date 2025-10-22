namespace GameApp.Domain.ValueObjects.Items;


public class Item
{
    public ItemName Name { get; private set; }
    public ItemDescription Description { get; private set; }

    protected Item(ItemName name, ItemDescription description)
    {
        Name = name;
        Description = description;
    }

    public ItemName GetName() => Name;
    public ItemDescription GetDescription() => Description;

}