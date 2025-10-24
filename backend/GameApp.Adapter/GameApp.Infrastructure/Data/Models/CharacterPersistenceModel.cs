using System.Collections.Generic;

namespace GameApp.Infrastructure.Data.Models;

public class CharacterPersistenceModel
{
    public Guid Id { get; set; }

    public string Type { get; set; } = default!;

    public int CurrentHealthPoints { get; set; }
    public int CurrentFoodPoints { get; set; }
    public int CurrentMoney { get; set; }

    public string InventoryJson { get; set; } = default!;
}
