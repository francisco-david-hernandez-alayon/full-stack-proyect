namespace GameApp.Domain.ValueObjects;

// Value Object of Character Name for character's entities
public class CharacterName
{
    private static readonly string _messageIfEmpty = "Character name cannot be empty";
    private readonly string Name;



    // Constructor
    public CharacterName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException(_messageIfEmpty, nameof(value));

        Name = value;
    }

    public string GetName() => Name;


    public CharacterName SetName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException(_messageIfEmpty, nameof(newName));

        return new CharacterName(newName);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not CharacterName other)
            return false;

        return Name == other.Name;
    }

    public override int GetHashCode() => Name.GetHashCode();

    public override string ToString() => Name;
}
