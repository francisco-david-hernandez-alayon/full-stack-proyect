import { Item } from './item';
import { ItemName } from '../../value-objects/items/item-name';
import { ItemDescription } from '../../value-objects/items/item-description';
import type { ItemRarity } from '../../enumerates/item-rarity';

export class AttackItem extends Item {
    private _attackDamage: number;
    private _speedAttack: number;
    private _durability: number;

    constructor(
        rarity: ItemRarity,
        name: ItemName,
        description: ItemDescription,
        tradePrice: number,
        attackDamage: number,
        speedAttack: number,
        durability: number,
        id: string | null = null
    ) {
        super(rarity, name, description, tradePrice, id);
        
        this._attackDamage = attackDamage;
        this._speedAttack = speedAttack;
        this._durability = durability;
    }

    // getters
    get attackDamage(): number { return this._attackDamage; }
    get speedAttack(): number { return this._speedAttack; }
    get durability(): number { return this._durability; }

    // setters (inmutable, devuelven nueva instancia)
    setAttackDamage(newValue: number): AttackItem {
        return new AttackItem(this._rarity, this._name, this._description, this._tradePrice, newValue, this._speedAttack, this._durability, this._id);
    }

    setSpeedAttack(newValue: number): AttackItem {
        return new AttackItem(this._rarity, this._name, this._description, this._tradePrice, this._attackDamage, newValue, this._durability, this._id);
    }

    setDurability(newValue: number): AttackItem {
        return new AttackItem(this._rarity, this._name, this._description, this._tradePrice, this._attackDamage, this._speedAttack, newValue, this._id);
    }

    toString(): string {
        return `${this._name.toString()} attack item(${this._id}, rarity=${this._rarity}), price=${this._tradePrice}: AttackDamage=${this._attackDamage}, SpeedAttack=${this._speedAttack}, durability=${this._durability}`;
    }
}
