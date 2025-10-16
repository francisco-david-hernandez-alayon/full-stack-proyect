namespace GameApp.Domain.ValueObjects.Enemies;

// Class for an enemy
public class Enemy
{
    public readonly EnemyName _name;
    public readonly int _healtPoints;
    public readonly int _damageAttack;
    public readonly int _speedAttack;
    public readonly int _moneyReward;

    // constructor
    public Enemy(EnemyName name, int healtPoints, int damageAttack, int speedAttack, int moneyReward)
    {
        _name = name;
        _healtPoints = healtPoints;
        _damageAttack = damageAttack;
        _speedAttack = speedAttack;
        _moneyReward = moneyReward;
    }

    // Getters
    public EnemyName GetName() => _name;
    public int GetHealtPoints() => _healtPoints;
    public int GetDamageAttack() => _damageAttack;
    public int GetSpeedAttack() => _speedAttack;
    public int GetMoneyReward() => _moneyReward;

    // Setters
    public Enemy SetName(EnemyName newName) => new Enemy(newName, _healtPoints, _damageAttack, _speedAttack, _moneyReward);
    public Enemy SetHealtPoints(int newHealtPoints) => new Enemy(_name, newHealtPoints, _damageAttack, _speedAttack, _moneyReward);
    public Enemy SetDamageAttack(int newDamageAttack) => new Enemy(_name, _healtPoints, newDamageAttack, _speedAttack, _moneyReward);
    public Enemy SetSpeedAttack(int newSpeedAttack) => new Enemy(_name, _healtPoints, _damageAttack, newSpeedAttack, _moneyReward);
    public Enemy SetMoneyReward(int newMoneyReward) => new Enemy(_name, _healtPoints, _damageAttack, _speedAttack, newMoneyReward);
    public Enemy ReceiveDamage(int damage) {
        int newHealtPoints = _healtPoints - damage;

        if (newHealtPoints < 0) {
            newHealtPoints = 0;
        }

        return new Enemy(_name, newHealtPoints, _damageAttack, _speedAttack, _moneyReward);
    }

    // To string
    public override string ToString()
    {
        return $"{_name.GetName()} Enemy: " +
               $"HealthPoints={_healtPoints}, " +
               $"DamageAttack={_damageAttack}, " +
               $"SpeedAttack={_speedAttack}, " +
               $"MoneyReward={_moneyReward}";
    }

}