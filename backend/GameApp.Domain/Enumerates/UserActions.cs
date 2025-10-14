namespace GameApp.Domain.Enumerates;

public enum UserActions
{
    // ITEMS
    UseItem,  // use an item from inventory

    UseCurrentSceneItem, // use an item that is not in inventory(take item on current scenario and use it without adding to inventory)

    GetItem,  // get an item to inventory(space on inventory is required)

    ChangeItem,   // Change item from inventory for a new one(max space on inventory reached)




    // SCENARIO




    // COMBAT

}