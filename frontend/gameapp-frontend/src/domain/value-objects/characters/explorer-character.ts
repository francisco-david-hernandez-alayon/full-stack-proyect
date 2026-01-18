import { CharacterName } from "./character-name";
import { Character } from "./character";
import { Item } from "../../entities/items/item";

export class ExplorerCharacter extends Character {
    static CHARACTER_NAME = new CharacterName("Explorer");
    static DEFAULT_MAX_HEALTH = 100;
    static DEFAULT_MAX_FOOD = 140;
    static DEFAULT_MAX_SLOTS = 7;
    static DEFAULT_MONEY = 20;
    static DEFAULT_ATTACK_SPEED = 2;
    static DEFAULT_ATTACK_DAMAGE = 3;

    // Character Ability
    static NOTHING_HAPPENS_SCENES_NEEDED = 3;
    static PROBABILITY_OF_RARE_ITEM = 15;

    private readonly _currentNothingHappensScenes: number;

    constructor(
        currentHealthPoints: number | null = null,
        currentFoodPoints: number | null = null,
        currentMoney: number | null = null,
        inventoryList: Item[] | null = null,
        currentNothingHappensScenes: number = 0
    ) {
        super(
            ExplorerCharacter.CHARACTER_NAME,
            ExplorerCharacter.DEFAULT_MAX_HEALTH,
            ExplorerCharacter.DEFAULT_MAX_FOOD,
            ExplorerCharacter.DEFAULT_MAX_SLOTS,
            ExplorerCharacter.DEFAULT_MONEY,
            ExplorerCharacter.DEFAULT_ATTACK_SPEED,
            ExplorerCharacter.DEFAULT_ATTACK_DAMAGE,
            currentHealthPoints,
            currentFoodPoints,
            currentMoney,
            inventoryList
        );

        this._currentNothingHappensScenes = currentNothingHappensScenes;
    }

    cloneWith(
        currentHealthPoints: number,
        currentFoodPoints: number,
        currentMoney: number,
        inventoryList: Item[]
    ): ExplorerCharacter {
        return new ExplorerCharacter(
            currentHealthPoints,
            currentFoodPoints,
            currentMoney,
            [...inventoryList],
            this._currentNothingHappensScenes
        );
    }

    // getters
    getNothingHappensScenesToGetAbility(): number {
        return ExplorerCharacter.NOTHING_HAPPENS_SCENES_NEEDED;
    }

    getProbabilityOfRareItem(): number {
        return ExplorerCharacter.PROBABILITY_OF_RARE_ITEM;
    }

    getCurrentNothingHappensScenes(): number {
        return this._currentNothingHappensScenes;
    }

    canUseAbility(): boolean {
        return this._currentNothingHappensScenes >= ExplorerCharacter.NOTHING_HAPPENS_SCENES_NEEDED;
    }

    // setters
    setCurrentNothingHappensScenes(value: number): ExplorerCharacter {
        return new ExplorerCharacter(
            this._currentHealthPoints,
            this._currentFoodPoints,
            this._currentMoney,
            [...this._inventoryList],
            value
        );
    }

    addNothingHappensScene(): ExplorerCharacter {
        const newValue = Math.min(
            this._currentNothingHappensScenes + 1,
            ExplorerCharacter.NOTHING_HAPPENS_SCENES_NEEDED
        );
        return this.setCurrentNothingHappensScenes(newValue);
    }

    resetNothingHappensScenes(): ExplorerCharacter {
        return this.setCurrentNothingHappensScenes(0);
    }

    toString(): string {
        const inventoryStr = this._inventoryList
            .map(i => i?.toString() ?? "Empty")
            .join(", ");

        return `${this._name.toString()} Explorer character(atq=${this._attackDamage}, spd=${this._attackSpeed}): ` +
            `HP=${this._currentHealthPoints}/${this._maxHealthPoints}, ` +
            `Food=${this._currentFoodPoints}/${this._maxFoodPoints}, InventorySlots=${this._maxInventorySlots}, ` +
            `Money=${this._currentMoney}, Inventory=[${inventoryStr}] currentNothingHappensScenes=[${this._currentNothingHappensScenes}/${ExplorerCharacter.NOTHING_HAPPENS_SCENES_NEEDED}]`;
    }
}
