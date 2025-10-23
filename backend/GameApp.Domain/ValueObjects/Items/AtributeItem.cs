namespace GameApp.Domain.ValueObjects.Items;


// Specific class for item that affect to atributes
public class AtributeItem : Item
{
    public int HealthPointsReceived { get; private set; }
    public int FoodPointsReceived { get; private set; }



    // constructor
    public AtributeItem(ItemName name, ItemDescription description, int healthPointsReceived, int foodPointsReceived)
        : base(name, description)
    {
        HealthPointsReceived = healthPointsReceived;
        FoodPointsReceived = foodPointsReceived;
    }

    // getters
    public int GetHealthPointsReceived() => HealthPointsReceived;

    public int GetFoodPointsReceived() => FoodPointsReceived;

    // To string
    public override string ToString()
    {
        return $"{GetName()} atribute item: " + $"HealthPointsReceived={HealthPointsReceived}, FoodPointsReceived={FoodPointsReceived}";
    }
}