import { Item } from "../../entities/items/item";
import {CharacterName} from './character-name';


// Abstract base class Character
export class Character {
  constructor(name, maxHealthPoints, maxFoodPoints, maxInventorySlots, startingMoney,
              currentHealthPoints = null, currentFoodPoints = null, currentMoney = null, inventoryList = null) {
    if (!(name instanceof CharacterName)) throw new TypeError("name must be CharacterName");

    this._name = name;
    this._maxHealthPoints = maxHealthPoints;
    this._maxFoodPoints = maxFoodPoints;
    this._maxInventorySlots = maxInventorySlots;
    this._startingMoney = startingMoney;

    this._currentHealthPoints = currentHealthPoints ?? maxHealthPoints;
    this._currentFoodPoints = currentFoodPoints ?? maxFoodPoints;
    this._currentMoney = currentMoney ?? startingMoney;
    this._inventoryList = inventoryList ?? [];

    this.#validateItemList(this._inventoryList, "_inventoryList");
  }

  #validateItemList(list, paramName) {
          if (!Array.isArray(list)) throw new TypeError(`${paramName} must be an array`);
          for (const item of list) {
              if (!(item instanceof Item)) {
                  throw new TypeError(`All elements of ${paramName} must be instances of Item or its subclasses`);
              }
          }
      }

  // getters
  get name() { return this._name; }
  get maxHealthPoints() { return this._maxHealthPoints; }
  get maxFoodPoints() { return this._maxFoodPoints; }
  get maxInventorySlots() { return this._maxInventorySlots; }
  get startingMoney() { return this._startingMoney; }
  get currentHealthPoints() { return this._currentHealthPoints; }
  get currentFoodPoints() { return this._currentFoodPoints; }
  get currentMoney() { return this._currentMoney; }
  get inventoryList() { return this._inventoryList; }

  // Abstract clone method
  cloneWith(currentHealthPoints, currentFoodPoints, currentMoney, inventoryList) {
    throw new Error("Method 'cloneWith' must be implemented in subclass");
  }

  // setters
  addItemInventory(newItem) {
    if (this._inventoryList.length >= this._maxInventorySlots) return this;

    const newInventory = [...this._inventoryList, newItem];
    return this.cloneWith(this._currentHealthPoints, this._currentFoodPoints, this._currentMoney, newInventory);
  }

  removeItemInventory(index) {
    if (index < 0 || index >= this._inventoryList.length) return this;

    const newInventory = [...this._inventoryList];
    newInventory.splice(index, 1);
    return this.cloneWith(this._currentHealthPoints, this._currentFoodPoints, this._currentMoney, newInventory);
  }

  receiveDamage(damage) {
    const newHealth = Math.max(0, this._currentHealthPoints - damage);
    return this.cloneWith(newHealth, this._currentFoodPoints, this._currentMoney, this._inventoryList);
  }

  heal(amount) {
    const newHealth = Math.min(this._maxHealthPoints, this._currentHealthPoints + amount);
    return this.cloneWith(newHealth, this._currentFoodPoints, this._currentMoney, this._inventoryList);
  }

  eat(amount) {
    const newFood = Math.min(this._maxFoodPoints, this._currentFoodPoints + amount);
    return this.cloneWith(this._currentHealthPoints, newFood, this._currentMoney, this._inventoryList);
  }

  getHungry(amount) {
    const newFood = Math.max(0, this._currentFoodPoints - amount);
    return this.cloneWith(this._currentHealthPoints, newFood, this._currentMoney, this._inventoryList);
  }

  earnMoney(amount) {
    return this.cloneWith(this._currentHealthPoints, this._currentFoodPoints, this._currentMoney + amount, this._inventoryList);
  }

  spendMoney(amount) {
    const newMoney = Math.max(0, this._currentMoney - amount);
    return this.cloneWith(this._currentHealthPoints, this._currentFoodPoints, newMoney, this._inventoryList);
  }
}