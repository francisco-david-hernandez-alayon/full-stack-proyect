namespace GameApp.Domain.ValueObjects.Scenes;


// Value Object for a game's scene description
public class SceneDescription
{
    private static readonly string _messageIfEmpty = "Scene description cannot be empty";
    public string Description { get; private set; } = default!;


    public SceneDescription(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException(_messageIfEmpty, nameof(value));

        Description = value;
    }

    public string GetDescription() => Description;

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

        return Description == other.Description;
    }

    public override int GetHashCode() => Description.GetHashCode();

    public override string ToString() => Description;
}
