import { CharacterName } from "./character-name";
import { Character } from "./character";
import { Item } from "../../entities/items/item";

export class BerserkerCharacter extends Character {
    static CHARACTER_NAME = new CharacterName("Berserker");
    static DEFAULT_MAX_HEALTH = 200;
    static DEFAULT_MAX_FOOD = 60;
    static DEFAULT_MAX_SLOTS = 4;
    static DEFAULT_MONEY = 0;
    static DEFAULT_ATTACK_SPEED = 3;
    static DEFAULT_ATTACK_DAMAGE = 10;

    // Character Ability
    static KILLS_NEEDED_TO_GET_ABILITY = 5;
    static ABILITY_CURE = 50;

    private readonly _currentKills: number;

    constructor(
        currentHealthPoints: number | null = null,
        currentFoodPoints: number | null = null,
        currentMoney: number | null = null,
        inventoryList: Item[] | null = null,
        currentKills: number = 0
    ) {
        super(
            BerserkerCharacter.CHARACTER_NAME,
            BerserkerCharacter.DEFAULT_MAX_HEALTH,
            BerserkerCharacter.DEFAULT_MAX_FOOD,
            BerserkerCharacter.DEFAULT_MAX_SLOTS,
            BerserkerCharacter.DEFAULT_MONEY,
            BerserkerCharacter.DEFAULT_ATTACK_SPEED,
            BerserkerCharacter.DEFAULT_ATTACK_DAMAGE,
            currentHealthPoints,
            currentFoodPoints,
            currentMoney,
            inventoryList
        );

        this._currentKills = currentKills;
    }

    cloneWith(
        currentHealthPoints: number,
        currentFoodPoints: number,
        currentMoney: number,
        inventoryList: Item[]
    ): BerserkerCharacter {
        return new BerserkerCharacter(
            currentHealthPoints,
            currentFoodPoints,
            currentMoney,
            [...inventoryList],
            this._currentKills
        );
    }

    // getters
    getKills(): number {
        return this._currentKills;
    }

    getKillsToGetAbility(): number {
        return BerserkerCharacter.KILLS_NEEDED_TO_GET_ABILITY;
    }

    getAbilityCure(): number {
        return BerserkerCharacter.ABILITY_CURE;
    }

    canUseAbility(): boolean {
        return this._currentKills >= BerserkerCharacter.KILLS_NEEDED_TO_GET_ABILITY;
    }

    // setters
    setKills(newKills: number): BerserkerCharacter {
        return new BerserkerCharacter(
            this._currentHealthPoints,
            this._currentFoodPoints,
            this._currentMoney,
            [...this._inventoryList],
            newKills
        );
    }

    addKill(): BerserkerCharacter {
        const newKills = Math.min(
            this._currentKills + 1,
            BerserkerCharacter.KILLS_NEEDED_TO_GET_ABILITY
        );
        return this.setKills(newKills);
    }

    resetKills(): BerserkerCharacter {
        return this.setKills(0);
    }

    toString(): string {
        const inventoryStr = this._inventoryList
            .map(i => i?.toString() ?? "Empty")
            .join(", ");

        return `${this._name.toString()} Berserker character(atq=${this._attackDamage}, spd=${this._attackSpeed}): ` +
            `HP=${this._currentHealthPoints}/${this._maxHealthPoints}, ` +
            `Food=${this._currentFoodPoints}/${this._maxFoodPoints}, InventorySlots=${this._maxInventorySlots}, ` +
            `Money=${this._currentMoney}, Inventory=[${inventoryStr}] Kills=[${this._currentKills}/${BerserkerCharacter.KILLS_NEEDED_TO_GET_ABILITY}]`;
    }
}
