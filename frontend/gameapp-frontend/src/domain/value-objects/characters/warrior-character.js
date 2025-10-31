import {CharacterName} from './character-name'
import { Character } from './character';

// Concrete WarriorCharacter
export class WarriorCharacter extends Character {
    static CHARACTER_NAME = new CharacterName("Warrior");
    static DEFAULT_MAX_HEALTH = 150;
    static DEFAULT_MAX_FOOD = 100;
    static DEFAULT_MAX_SLOTS = 5;
    static DEFAULT_MONEY = 10;

    constructor(currentHealthPoints = null, currentFoodPoints = null, currentMoney = null, inventoryList = null) {
        super(
            WarriorCharacter.CHARACTER_NAME,
            WarriorCharacter.DEFAULT_MAX_HEALTH,
            WarriorCharacter.DEFAULT_MAX_FOOD,
            WarriorCharacter.DEFAULT_MAX_SLOTS,
            WarriorCharacter.DEFAULT_MONEY,
            currentHealthPoints,
            currentFoodPoints,
            currentMoney,
            inventoryList
        );
    }

    cloneWith(currentHealthPoints, currentFoodPoints, currentMoney, inventoryList) {
        return new WarriorCharacter(currentHealthPoints, currentFoodPoints, currentMoney, [...inventoryList]);
    }

    toString() {
        const inventoryStr = this._inventoryList.map(i => i?.toString() ?? "Empty").join(", ");
        return `${this._name.toString()} Warrior character: HP=${this._currentHealthPoints}/${this._maxHealthPoints}, ` +
            `Food=${this._currentFoodPoints}/${this._maxFoodPoints}, InventorySlots=${this._maxInventorySlots}, ` +
            `Money=${this._currentMoney}, Inventory=[${inventoryStr}]`;
    }
}