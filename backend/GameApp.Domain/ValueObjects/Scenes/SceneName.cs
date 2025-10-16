namespace GameApp.Domain.ValueObjects.Scenes;

// Value Object of Scene Name
public class SceneName
{
    private static readonly string _messageIfEmpty = "Scene name cannot be empty";
    private readonly string _name;

    // Constructor
    public SceneName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException(_messageIfEmpty, nameof(value));

        _name = value;
    }

    public string GetName() => _name;


    public SceneName SetName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException(_messageIfEmpty, nameof(newName));

        return new SceneName(newName);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not SceneName other)
            return false;

        return _name == other._name;
    }

    public override int GetHashCode() => _name.GetHashCode();

    public override string ToString() => _name;
}
