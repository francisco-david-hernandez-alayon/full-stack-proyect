namespace GameApp.Domain.Enumerates;

public enum UserAction
{
    // SCENARIO
    MoveForward,  // move forward in a chosen direction

    // ITEMS
    UseItem,  // use an item from inventory
    UseCurrentSceneItem, // use an item that is not in inventory(take item on current scene and use it without adding to inventory)
    GetItem,  // get an item to inventory(space on inventory is required)
    ChangeItem,   // Change item from inventory for a new one(max space on inventory reached)

    // TRADES
    BuyItems,   // Can buy items to merchant
    SoldItems,  // Sold items

    // COMBAT
    AttackEnemyWithItem, // attack current enemy with attack an item
    AttackEnemyWithoutItem,   // attack current enemy without an attack item
}