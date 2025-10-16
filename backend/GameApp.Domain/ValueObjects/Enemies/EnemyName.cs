namespace GameApp.Domain.ValueObjects.Enemies;

// Value Object of Enemy Name
public class EnemyName
{
    private static readonly string _messageIfEmpty = "Enemy name cannot be empty";
    private readonly string _name;

    // Constructor
    public EnemyName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException(_messageIfEmpty, nameof(value));

        _name = value;
    }

    public string GetName() => _name;


    public EnemyName SetName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException(_messageIfEmpty, nameof(newName));

        return new EnemyName(newName);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not EnemyName other)
            return false;

        return _name == other._name;
    }

    public override int GetHashCode() => _name.GetHashCode();

    public override string ToString() => _name;
}
