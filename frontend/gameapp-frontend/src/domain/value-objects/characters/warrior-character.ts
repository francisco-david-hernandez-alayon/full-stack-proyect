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

    // Character Ability
    static HITS_NEEDED_TO_GET_ABILITY = 10;
    static ABILITY_DAMAGE = 30;
    private readonly _currentHits: number;



    constructor(
        currentHealthPoints: number | null = null,
        currentFoodPoints: number | null = null,
        currentMoney: number | null = null,
        inventoryList: Item[] | null = null,
        currentHits: number = 0
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

        this._currentHits = currentHits;
    }

    cloneWith(
        currentHealthPoints: number,
        currentFoodPoints: number,
        currentMoney: number,
        inventoryList: Item[]
    ): WarriorCharacter {
        return new WarriorCharacter(currentHealthPoints, currentFoodPoints, currentMoney, [...inventoryList], this._currentHits);
    }

    // getters
    getHits(): number {
        return this._currentHits;
    }

    getHitsToGetAbility(): number {
        return WarriorCharacter.HITS_NEEDED_TO_GET_ABILITY;
    }

    getAbilityDamage(): number {
        return WarriorCharacter.ABILITY_DAMAGE;
    }

    // Determines if the character can use its special ability
    canUseAbility(): boolean {
        return this._currentHits >= WarriorCharacter.HITS_NEEDED_TO_GET_ABILITY;
    }



    // setters
    setHits(newHits: number): WarriorCharacter {
        return new WarriorCharacter(
            this._currentHealthPoints,
            this._currentFoodPoints,
            this._currentMoney,
            [...this._inventoryList],
            newHits
        );
    }

    // Adds one hit, respecting the maximum 
    addHit(): WarriorCharacter {
        const newHits = Math.min(this._currentHits + 1, WarriorCharacter.HITS_NEEDED_TO_GET_ABILITY);
        return this.setHits(newHits);
    }

    // Resets hits to zero 
    resetHits(): WarriorCharacter {
        return this.setHits(0);
    }


    toString(): string {
        const inventoryStr = this._inventoryList.map(i => i?.toString() ?? "Empty").join(", ");
        return `${this._name.toString()} Warrior character(atq=${this._attackDamage}, spd=${this._attackSpeed}): HP=${this._currentHealthPoints}/${this._maxHealthPoints}, ` +
            `Food=${this._currentFoodPoints}/${this._maxFoodPoints}, InventorySlots=${this._maxInventorySlots}, ` +
            `Money=${this._currentMoney}, Inventory=[${inventoryStr}] Hits=[${this._currentHits}/${WarriorCharacter.HITS_NEEDED_TO_GET_ABILITY}]
`;
    }
}
