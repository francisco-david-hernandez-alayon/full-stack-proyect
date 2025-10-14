namespace GameApp.Domain.ValueObjects.Items;


// Value Object for a game's inventory item description
public class ItemDescription
{
    private static readonly string _messageIfEmpty = "Item description cannot be empty";
    private readonly string _description;

    public ItemDescription(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException(_messageIfEmpty, nameof(value));

        _description = value;
    }

    public string GetDescription() => _description;

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

        return _description == other._description;
    }

    public override int GetHashCode() => _description.GetHashCode();

    public override string ToString() => _description;
}
