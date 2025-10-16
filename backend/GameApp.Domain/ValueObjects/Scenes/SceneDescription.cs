namespace GameApp.Domain.ValueObjects.Scenes;


// Value Object for a game's scene description
public class SceneDescription
{
    private static readonly string _messageIfEmpty = "Scene description cannot be empty";
    private readonly string _description;

    public SceneDescription(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException(_messageIfEmpty, nameof(value));

        _description = value;
    }

    public string GetDescription() => _description;

    public SceneDescription SetDescription(string newDescription)
    {
        if (string.IsNullOrWhiteSpace(newDescription))
            throw new ArgumentException(_messageIfEmpty, nameof(newDescription));

        return new SceneDescription(newDescription);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not SceneDescription other)
            return false;

        return _description == other._description;
    }

    public override int GetHashCode() => _description.GetHashCode();

    public override string ToString() => _description;
}
