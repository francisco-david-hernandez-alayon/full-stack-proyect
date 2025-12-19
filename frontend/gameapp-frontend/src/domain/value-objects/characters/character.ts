import { Item } from "../../entities/items/item";
import { CharacterName } from "./character-name";

// Abstract base class Character
export abstract class Character {
    protected _name: CharacterName;
    protected _maxHealthPoints: number;
    protected _maxFoodPoints: number;
    protected _maxInventorySlots: number;
    protected _startingMoney: number;
    protected _attackSpeed: number;
    protected _attackDamage: number;

    protected _currentHealthPoints: number;
    protected _currentFoodPoints: number;
    protected _currentMoney: number;
    protected _inventoryList: Item[];

    constructor(
        name: CharacterName,
        maxHealthPoints: number,
        maxFoodPoints: number,
        maxInventorySlots: number,
        startingMoney: number,
        attackSpeed: number,
        attackDamage: number,
        currentHealthPoints: number | null = null,
        currentFoodPoints: number | null = null,
        currentMoney: number | null = null,
        inventoryList: Item[] | null = null
    ) {
        if (!(name instanceof CharacterName)) throw new TypeError("name must be CharacterName");

        this._name = name;
        this._maxHealthPoints = maxHealthPoints;
        this._maxFoodPoints = maxFoodPoints;
        this._maxInventorySlots = maxInventorySlots;
        this._startingMoney = startingMoney;
        this._attackSpeed = attackSpeed;
        this._attackDamage = attackDamage;

        this._currentHealthPoints = currentHealthPoints ?? maxHealthPoints;
        this._currentFoodPoints = currentFoodPoints ?? maxFoodPoints;
        this._currentMoney = currentMoney ?? startingMoney;
        this._inventoryList = inventoryList ?? [];

        this.validateItemList(this._inventoryList, "_inventoryList");
    }

    private validateItemList(list: Item[], paramName: string) {
        if (!Array.isArray(list)) throw new TypeError(`${paramName} must be an array`);
        for (const item of list) {
            if (!(item instanceof Item)) {
                throw new TypeError(`All elements of ${paramName} must be instances of Item or its subclasses`);
            }
        }
    }

    // getters
    get name(): CharacterName { return this._name; }
    get maxHealthPoints(): number { return this._maxHealthPoints; }
    get maxFoodPoints(): number { return this._maxFoodPoints; }
    get maxInventorySlots(): number { return this._maxInventorySlots; }
    get startingMoney(): number { return this._startingMoney; }
    get attackSpeed(): number {return this._attackSpeed; }
    get attackDamage(): number {return this._attackDamage; }
    get currentHealthPoints(): number { return this._currentHealthPoints; }
    get currentFoodPoints(): number { return this._currentFoodPoints; }
    get currentMoney(): number { return this._currentMoney; }
    get inventoryList(): Item[] { return this._inventoryList; }

    // Abstract clone method
    abstract cloneWith(
        currentHealthPoints: number,
        currentFoodPoints: number,
        currentMoney: number,
        inventoryList: Item[]
    ): Character;

    // setters / modifiers (return new instance)
    addItemInventory(newItem: Item): Character {
        if (this._inventoryList.length >= this._maxInventorySlots) return this;

        const newInventory = [...this._inventoryList, newItem];
        return this.cloneWith(this._currentHealthPoints, this._currentFoodPoints, this._currentMoney, newInventory);
    }

    removeItemInventory(index: number): Character {
        if (index < 0 || index >= this._inventoryList.length) return this;

        const newInventory = [...this._inventoryList];
        newInventory.splice(index, 1);
        return this.cloneWith(this._currentHealthPoints, this._currentFoodPoints, this._currentMoney, newInventory);
    }

    receiveDamage(damage: number): Character {
        const newHealth = Math.max(0, this._currentHealthPoints - damage);
        return this.cloneWith(newHealth, this._currentFoodPoints, this._currentMoney, this._inventoryList);
    }

    heal(amount: number): Character {
        const newHealth = Math.min(this._maxHealthPoints, this._currentHealthPoints + amount);
        return this.cloneWith(newHealth, this._currentFoodPoints, this._currentMoney, this._inventoryList);
    }

    eat(amount: number): Character {
        const newFood = Math.min(this._maxFoodPoints, this._currentFoodPoints + amount);
        return this.cloneWith(this._currentHealthPoints, newFood, this._currentMoney, this._inventoryList);
    }

    getHungry(amount: number): Character {
        const newFood = Math.max(0, this._currentFoodPoints - amount);
        return this.cloneWith(this._currentHealthPoints, newFood, this._currentMoney, this._inventoryList);
    }

    earnMoney(amount: number): Character {
        return this.cloneWith(this._currentHealthPoints, this._currentFoodPoints, this._currentMoney + amount, this._inventoryList);
    }

    spendMoney(amount: number): Character {
        const newMoney = Math.max(0, this._currentMoney - amount);
        return this.cloneWith(this._currentHealthPoints, this._currentFoodPoints, newMoney, this._inventoryList);
    }
}
