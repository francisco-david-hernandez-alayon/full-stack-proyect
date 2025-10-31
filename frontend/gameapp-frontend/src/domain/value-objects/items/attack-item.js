import { Item } from './item.js'

// Specific class for attack items
export class AttackItem extends Item {
    constructor(name, description, attackDamage, speedAttack, durability) {
        super(name, description);

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
        return new AttackItem(this._name, this._description, newValue, this._speedAttack, this._durability);
    }

    setSpeedAttack(newValue) {
        return new AttackItem(this._name, this._description, this._attackDamage, newValue, this._durability);
    }

    setDurability(newValue) {
        return new AttackItem(this._name, this._description, this._attackDamage, this._speedAttack, newValue);
    }

    toString() {
        return `${this._name.toString()} attack item: AttackDamage=${this._attackDamage}, SpeedAttack=${this._speedAttack}, durability=${this._durability}`;
    }
}