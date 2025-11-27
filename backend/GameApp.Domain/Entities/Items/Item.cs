using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Domain.Entities.Items;


public abstract class Item
{
    private readonly Guid Id;
    private readonly ItemName Name;
    private readonly ItemDescription Description;

    // Default constructor
    protected Item(ItemName name, ItemDescription description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
    }

    // Restore Constructor
    protected Item(Guid id, ItemName name, ItemDescription description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public Guid GetGuid() => Id;
    public ItemName GetName() => Name;
    public ItemDescription GetDescription() => Description;

}