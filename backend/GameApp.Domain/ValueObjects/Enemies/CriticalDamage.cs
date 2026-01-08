namespace GameApp.Domain.ValueObjects.Combat;

// Value Object of Critical Damage
public class CriticalDamage
{
    private static readonly string _invalidProbabilityMessage =
        "Critical probability must be between 0 and 100";

    private static readonly string _invalidExtraDamageMessage =
        "Extra critical damage must be greater than or equal to 0";

    private readonly int CriticalProbability;
    private readonly int ExtraDamage;

    // Constructor
    public CriticalDamage(int criticalProbability, int extraDamage)
    {
        if (criticalProbability < 0 || criticalProbability > 100)
            throw new ArgumentException(_invalidProbabilityMessage, nameof(criticalProbability));

        if (extraDamage < 0)
            throw new ArgumentException(_invalidExtraDamageMessage, nameof(extraDamage));

        CriticalProbability = criticalProbability;
        ExtraDamage = extraDamage;
    }

    // Getters
    public int GetCriticalProbability() => CriticalProbability;
    public int GetExtraDamage() => ExtraDamage;

    // setters
    public CriticalDamage SetCriticalProbability(int newProbability)
    {
        return new CriticalDamage(newProbability, ExtraDamage);
    }

    public CriticalDamage SetExtraDamage(int newExtraDamage)
    {
        return new CriticalDamage(CriticalProbability, newExtraDamage);
    }

    // Equality
    public override bool Equals(object? obj)
    {
        if (obj is not CriticalDamage other)
            return false;

        return CriticalProbability == other.CriticalProbability
            && ExtraDamage == other.ExtraDamage;
    }

    public override int GetHashCode()
        => HashCode.Combine(CriticalProbability, ExtraDamage);

    public override string ToString()
        => $"CriticalDamage(probability={CriticalProbability}%, extraDamage={ExtraDamage})";
}
