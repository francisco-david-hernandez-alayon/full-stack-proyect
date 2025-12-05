import { Item } from './item.js'

// Specific class for attack items
export class AttackItem extends Item {
    constructor(name, description, tradePrice, attackDamage, speedAttack, durability, id = null) {
        super(name, description, tradePrice, id);

        this.#validateNumber(attackDamage, "attackDamage");
        this.#validateNumber(speedAttack, "speedAttack");
        this.#validateNumber(durability, "durability");

        this._attackDamage = attackDamage;
        this._speedAttack = speedAttack;
        this._durability = durability;
    }

    #validateNumber(value, paramName) {
        if (typeof value !== "number" || !Number.isFinite(value)) {
            throw new TypeError(`Parameter '${paramName}' must be a finite number`);
        }
    }

    // getter
    get attackDamage() {
        return this._attackDamage;
    }

    get speedAttack() {
        return this._speedAttack;
    }

    get durability() {
        return this._durability;
    }

    // setter
    setAttackDamage(newValue) {
        return new AttackItem(this._name, this._description, this._tradePrice, newValue, this._speedAttack, this._durability, this._id);
    }

    setSpeedAttack(newValue) {
        return new AttackItem(this._name, this._description, this._tradePrice, this._attackDamage, newValue, this._durability, this._id);
    }

    setDurability(newValue) {
        return new AttackItem(this._name, this._description, this._tradePrice, this._attackDamage, this._speedAttack, newValue, this._id);
    }

    toString() {
        return `${this._name.toString()} attack item(${this._id}), price=${this._tradePrice}: AttackDamage=${this._attackDamage}, SpeedAttack=${this._speedAttack}, durability=${this._durability}`;
    }
}