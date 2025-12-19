import { CharacterName } from './character-name';
import { Character } from './character';
import { Item } from '../../entities/items/item';

export class WarriorCharacter extends Character {
    static CHARACTER_NAME = new CharacterName("Warrior");
    static DEFAULT_MAX_HEALTH = 150;
    static DEFAULT_MAX_FOOD = 100;
    static DEFAULT_MAX_SLOTS = 5;
    static DEFAULT_MONEY = 10;
    static DEFAULT_ATTACK_SPEED = 3;
    static DEFAULT_ATTACK_DAMAGE = 4;

    constructor(
        currentHealthPoints: number | null = null,
        currentFoodPoints: number | null = null,
        currentMoney: number | null = null,
        inventoryList: Item[] | null = null
    ) {
        super(
            WarriorCharacter.CHARACTER_NAME,
            WarriorCharacter.DEFAULT_MAX_HEALTH,
            WarriorCharacter.DEFAULT_MAX_FOOD,
            WarriorCharacter.DEFAULT_MAX_SLOTS,
            WarriorCharacter.DEFAULT_MONEY,
            WarriorCharacter.DEFAULT_ATTACK_SPEED,
            WarriorCharacter.DEFAULT_ATTACK_DAMAGE,
            currentHealthPoints,
            currentFoodPoints,
            currentMoney,
            inventoryList
        );
    }

    cloneWith(
        currentHealthPoints: number,
        currentFoodPoints: number,
        currentMoney: number,
        inventoryList: Item[]
    ): WarriorCharacter {
        return new WarriorCharacter(currentHealthPoints, currentFoodPoints, currentMoney, [...inventoryList]);
    }

    toString(): string {
        const inventoryStr = this._inventoryList.map(i => i?.toString() ?? "Empty").join(", ");
        return `${this._name.toString()} Warrior character(atq=${this._attackDamage}, spd=${this._attackSpeed}): HP=${this._currentHealthPoints}/${this._maxHealthPoints}, ` +
            `Food=${this._currentFoodPoints}/${this._maxFoodPoints}, InventorySlots=${this._maxInventorySlots}, ` +
            `Money=${this._currentMoney}, Inventory=[${inventoryStr}]`;
    }
}
