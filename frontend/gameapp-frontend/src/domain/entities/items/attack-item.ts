import { Item } from './item';
import { ItemName } from '../../value-objects/items/item-name';
import { ItemDescription } from '../../value-objects/items/item-description';
import type { ItemRarity } from '../../enumerates/item-rarity';
import type { CriticalDamage } from '../../value-objects/enemies/critical-damage';
import type { ItemIcon } from '../../enumerates/item-icon';

export class AttackItem extends Item {
    private _attackDamage: number;
    private _speedAttack: number;
    private _durability: number;
    private _criticalDamage: CriticalDamage;

    constructor(
        rarity: ItemRarity,
        name: ItemName,
        description: ItemDescription,
        icon: ItemIcon, 
        tradePrice: number,
        attackDamage: number,
        speedAttack: number,
        durability: number,
        criticalDamage: CriticalDamage,
        id: string | null = null
    ) {
        super(rarity, name, description, icon, tradePrice, id);
        
        this._attackDamage = attackDamage;
        this._speedAttack = speedAttack;
        this._durability = durability;
        this._criticalDamage = criticalDamage;
    }

    // getters
    get attackDamage(): number { return this._attackDamage; }
    get speedAttack(): number { return this._speedAttack; }
    get durability(): number { return this._durability; }
    get criticalDamage(): CriticalDamage { return this._criticalDamage; }

    // setters (inmutable, devuelven nueva instancia)
    setAttackDamage(newValue: number): AttackItem {
        return new AttackItem(this._rarity, this._name, this._description, this._icon, this._tradePrice, newValue, this._speedAttack, this._durability, this._criticalDamage, this._id);
    }

    setSpeedAttack(newValue: number): AttackItem {
        return new AttackItem(this._rarity, this._name, this._description, this._icon, this._tradePrice, this._attackDamage, newValue, this._durability, this._criticalDamage, this._id);
    }

    setDurability(newValue: number): AttackItem {
        return new AttackItem(this._rarity, this._name, this._description, this._icon, this._tradePrice, this._attackDamage, this._speedAttack, newValue, this._criticalDamage, this._id);
    }

    setCriticalDamage(newCriticalDamage: CriticalDamage): AttackItem {
        return new AttackItem(this._rarity, this._name, this._description, this._icon, this._tradePrice, this._attackDamage, this._speedAttack, this._durability, newCriticalDamage, this._id);
    }


    toString(): string {
        return `${this._name.toString()} attack item(${this._id}, rarity=${this._rarity}), price=${this._tradePrice}: AttackDamage=${this._attackDamage}, SpeedAttack=${this._speedAttack}, durability=${this._durability}, CriticalDamage=${this._criticalDamage}`;
    }
}
