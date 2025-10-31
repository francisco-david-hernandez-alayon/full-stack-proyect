import { EnemyName } from './enemy-name.js';

export class Enemy {
    static ERROR_INVALID_NAME = "Parameter 'name' must be an instance of EnemyName";
    static ERROR_INVALID_NUMBER = (param) => `Parameter '${param}' must be a finite number`;
    static ERROR_INVALID_DAMAGE = "Damage must be a finite number";

    constructor(name, healthPoints, attackDamage, speedAttack, rewardMoney) {
        this.#validateName(name);
        this.#validateNumber(healthPoints, "healthPoints");
        this.#validateNumber(attackDamage, "attackDamage");
        this.#validateNumber(speedAttack, "speedAttack");
        this.#validateNumber(rewardMoney, "rewardMoney");

        this._name = name;
        this._healthPoints = healthPoints;
        this._attackDamage = attackDamage;
        this._speedAttack = speedAttack;
        this._rewardMoney = rewardMoney;
    }

    #validateName(name) {
        if (!(name instanceof EnemyName)) {
            throw new TypeError(Enemy.ERROR_INVALID_NAME);
        }
    }

    #validateNumber(value, paramName) {
        if (typeof value !== "number" || !Number.isFinite(value)) {
            throw new TypeError(Enemy.ERROR_INVALID_NUMBER(paramName));
        }
    }

    // Getters
    get name() { return this._name; }
    get healthPoints() { return this._healthPoints; }
    get attackDamage() { return this._attackDamage; }
    get speedAttack() { return this._speedAttack; }
    get rewardMoney() { return this._rewardMoney; }

    // Setters
    setName(newName) {
        return new Enemy(newName, this._healthPoints, this._attackDamage, this._speedAttack, this._rewardMoney);
    }

    setHealthPoints(newHealthPoints) {
        return new Enemy(this._name, newHealthPoints, this._attackDamage, this._speedAttack, this._rewardMoney);
    }

    setAttackDamage(newAttackDamage) {
        return new Enemy(this._name, this._healthPoints, newAttackDamage, this._speedAttack, this._rewardMoney);
    }

    setSpeedAttack(newSpeedAttack) {
        return new Enemy(this._name, this._healthPoints, this._attackDamage, newSpeedAttack, this._rewardMoney);
    }

    setRewardMoney(newRewardMoney) {
        return new Enemy(this._name, this._healthPoints, this._attackDamage, this._speedAttack, newRewardMoney);
    }

    receiveDamage(damage) {
        this.#validateNumber(damage, "damage");

        let newHealthPoints = this._healthPoints - damage;
        if (newHealthPoints < 0) newHealthPoints = 0;

        return new Enemy(this._name, newHealthPoints, this._attackDamage, this._speedAttack, this._rewardMoney);
    }

    toString() {
        return `${this._name.toString()} Enemy: ` +
            `HealthPoints=${this._healthPoints}, ` +
            `AttackDamage=${this._attackDamage}, ` +
            `SpeedAttack=${this._speedAttack}, ` +
            `RewardMoney=${this._rewardMoney}`;
    }

}
