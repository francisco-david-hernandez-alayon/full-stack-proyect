using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Domain.Entities.Items;


// Specific class for item that affect to atributes
public class AtributeItem : Item
{
    private readonly int HealthPointsReceived;
    private readonly int FoodPointsReceived;



    // Default constructor
    public AtributeItem(ItemName name, ItemDescription description, int healthPointsReceived, int foodPointsReceived)
        : base(name, description)
    {
        HealthPointsReceived = healthPointsReceived;
        FoodPointsReceived = foodPointsReceived;
    }

    // Restore constructor
    public AtributeItem(Guid id, ItemName name, ItemDescription description, int healthPointsReceived, int foodPointsReceived)
        : base(id, name, description)
    {
        HealthPointsReceived = healthPointsReceived;
        FoodPointsReceived = foodPointsReceived;
    }

    // getters
    public int GetHealthPointsReceived() => HealthPointsReceived;

    public int GetFoodPointsReceived() => FoodPointsReceived;

    // setters
    public AtributeItem SetHealthPointsReceived(int newHealthPointsReceived) => new AtributeItem(GetGuid(), GetName(), GetDescription(), newHealthPointsReceived, GetFoodPointsReceived()); 

    public AtributeItem SetFoodPointsReceived(int newFoodPointsReceived) => new AtributeItem(GetGuid(), GetName(), GetDescription(), GetHealthPointsReceived(), newFoodPointsReceived); 

    // To string
    public override string ToString()
    {
        return $"{GetName()} atribute item({GetGuid()}): " + $"HealthPointsReceived={HealthPointsReceived}, FoodPointsReceived={FoodPointsReceived}";
    }
}