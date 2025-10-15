namespace GameApp.Domain.ValueObjects.Items;


// Specific class for item that affect to atributes
class AtributeItem : Item
{
    private readonly int _healthPointsReceived;

    private readonly int _foodPointsReceived;


    // constructor
    public AtributeItem(ItemName name, ItemDescription description, int healthPointsReceived, int foodPointsReceived)
        : base(name, description)
    {
        _healthPointsReceived = healthPointsReceived;
        _foodPointsReceived = foodPointsReceived;
    }
    
    // getters
    public int GetHealthPointsReceived() => _healthPointsReceived;

    public int GetFoodPointsReceived() => _foodPointsReceived;

    // To string
    public override string ToString()
    {
        return $"{_name.GetName()} atribute item: " + $"HealthPointsReceived={_healthPointsReceived}, _FoodPointsReceived={_foodPointsReceived}";
    }
}