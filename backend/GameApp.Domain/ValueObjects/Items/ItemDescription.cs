namespace GameApp.Domain.ValueObjects.Items;


// Value Object for a game's inventory item description
public class ItemDescription
{
    private static readonly string _messageIfEmpty = "Item description cannot be empty";
    
    private readonly string Description;

    public ItemDescription(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException(_messageIfEmpty, nameof(value));

        Description = value;
    }

    public string GetDescription() => Description;

    public ItemDescription SetDescription(string newDescription)
    {
        if (string.IsNullOrWhiteSpace(newDescription))
            throw new ArgumentException(_messageIfEmpty, nameof(newDescription));

        return new ItemDescription(newDescription);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not ItemDescription other)
            return false;

        return Description == other.Description;
    }

    public override int GetHashCode() => Description.GetHashCode();

    public override string ToString() => Description;
}
