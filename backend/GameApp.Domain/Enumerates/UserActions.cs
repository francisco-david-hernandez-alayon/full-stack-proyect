namespace GameApp.Domain.Enumerates;

public enum UserActions
{

    // SCENARIO
    moveForward,  // move forward in a chosen direction


    // ITEMS
    UseItem,  // use an item from inventory

    UseCurrentSceneItem, // use an item that is not in inventory(take item on current scenario and use it without adding to inventory)

    GetItem,  // get an item to inventory(space on inventory is required)

    ChangeItem,   // Change item from inventory for a new one(max space on inventory reached)

    // Trades
    AcceptTrade,   // Accept current Trade
    DeclineTrade,  // Decline current Trade


    // COMBAT
    attackEnemyWithItem, // attack current enemy with attack an item
    attackEnemyWithoutItem,   // attack current enemy without an attack item
}