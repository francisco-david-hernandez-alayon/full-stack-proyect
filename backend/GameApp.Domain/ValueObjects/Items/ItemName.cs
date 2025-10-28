namespace GameApp.Domain.ValueObjects.Items;


// Value Object for a game's inventory item name
public class ItemName
{
    private static readonly string _messageIfEmpty = "Item name cannot be empty";
    
    private readonly string Name;

    public ItemName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException(_messageIfEmpty, nameof(value));

        Name = value;
    }

    public string GetName() => Name;

    public ItemName SetName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException(_messageIfEmpty, nameof(newName));

        return new ItemName(newName);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not ItemName other)
            return false;

        return Name == other.Name;
    }

    public override int GetHashCode() => Name.GetHashCode();

    public override string ToString() => Name;
}
