import { CharacterName } from './character-name';
import { Character } from './character';
import { Item } from '../../entities/items/item';

export class ThiefCharacter extends Character {
    static CHARACTER_NAME = new CharacterName("Thief");
    static DEFAULT_MAX_HEALTH = 120;
    static DEFAULT_MAX_FOOD = 90;
    static DEFAULT_MAX_SLOTS = 6;
    static DEFAULT_MONEY = 30;
    static DEFAULT_ATTACK_SPEED = 4;
    static DEFAULT_ATTACK_DAMAGE = 4;

    // Character Ability
    static EXTRA_MONEY_WHEN_KILL_ENEMY = 5;

    constructor(
        currentHealthPoints: number | null = null,
        currentFoodPoints: number | null = null,
        currentMoney: number | null = null,
        inventoryList: Item[] | null = null
    ) {
        super(
            ThiefCharacter.CHARACTER_NAME,
            ThiefCharacter.DEFAULT_MAX_HEALTH,
            ThiefCharacter.DEFAULT_MAX_FOOD,
            ThiefCharacter.DEFAULT_MAX_SLOTS,
            ThiefCharacter.DEFAULT_MONEY,
            ThiefCharacter.DEFAULT_ATTACK_SPEED,
            ThiefCharacter.DEFAULT_ATTACK_DAMAGE,
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
    ): ThiefCharacter {
        return new ThiefCharacter(
            currentHealthPoints,
            currentFoodPoints,
            currentMoney,
            [...inventoryList]
        );
    }

    // getters
    getExtraMoneyWhenKillEnemy(): number {
        return ThiefCharacter.EXTRA_MONEY_WHEN_KILL_ENEMY;
    }

    toString(): string {
        const inventoryStr = this._inventoryList.map(i => i?.toString() ?? "Empty").join(", ");
        return `${this._name.toString()} Thief character(atq=${this._attackDamage}, spd=${this._attackSpeed}): ` +
            `HP=${this._currentHealthPoints}/${this._maxHealthPoints}, ` +
            `Food=${this._currentFoodPoints}/${this._maxFoodPoints}, ` +
            `InventorySlots=${this._maxInventorySlots}, ` +
            `Money=${this._currentMoney}, Inventory=[${inventoryStr}] ` +
            `ExtraMoneyWhenKill=[${ThiefCharacter.EXTRA_MONEY_WHEN_KILL_ENEMY}]`;
    }
}
