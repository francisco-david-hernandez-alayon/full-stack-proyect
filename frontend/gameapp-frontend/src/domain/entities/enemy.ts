import { EnemyName } from '../value-objects/enemies/enemy-name';
import { v4 as uuidv4, validate as uuidValidate } from 'uuid';

export class Enemy {
    static ERROR_INVALID_NAME = "Parameter 'name' must be an instance of EnemyName";
    static ERROR_INVALID_NUMBER = (param: string) => `Parameter '${param}' must be a finite number`;

    private _id: string;
    private _name: EnemyName;
    private _healthPoints: number;
    private _attackDamage: number;
    private _speedAttack: number;
    private _rewardMoney: number;

    constructor(
        name: EnemyName,
        healthPoints: number,
        attackDamage: number,
        speedAttack: number,
        rewardMoney: number,
        id?: string
    ) {

        if (id) {
            if (!uuidValidate(id)) {
                throw new TypeError(`Invalid UUID: ${id}`);
            }
            this._id = id;
        } else {
            this._id = uuidv4();
        }
        this._name = name;
        this._healthPoints = healthPoints;
        this._attackDamage = attackDamage;
        this._speedAttack = speedAttack;
        this._rewardMoney = rewardMoney;
    }

    // Getters
    get id(): string { return this._id; }
    get name(): EnemyName { return this._name; }
    get healthPoints(): number { return this._healthPoints; }
    get attackDamage(): number { return this._attackDamage; }
    get speedAttack(): number { return this._speedAttack; }
    get rewardMoney(): number { return this._rewardMoney; }

    // Setters (inmutables)
    setName(newName: EnemyName): Enemy {
        return new Enemy(newName, this._healthPoints, this._attackDamage, this._speedAttack, this._rewardMoney, this._id);
    }

    setHealthPoints(newHealthPoints: number): Enemy {
        return new Enemy(this._name, newHealthPoints, this._attackDamage, this._speedAttack, this._rewardMoney, this._id);
    }

    setAttackDamage(newAttackDamage: number): Enemy {
        return new Enemy(this._name, this._healthPoints, newAttackDamage, this._speedAttack, this._rewardMoney, this._id);
    }

    setSpeedAttack(newSpeedAttack: number): Enemy {
        return new Enemy(this._name, this._healthPoints, this._attackDamage, newSpeedAttack, this._rewardMoney, this._id);
    }

    setRewardMoney(newRewardMoney: number): Enemy {
        return new Enemy(this._name, this._healthPoints, this._attackDamage, this._speedAttack, newRewardMoney, this._id);
    }

    receiveDamage(damage: number): Enemy {
        const newHealthPoints = Math.max(0, this._healthPoints - damage);
        return new Enemy(this._name, newHealthPoints, this._attackDamage, this._speedAttack, this._rewardMoney, this._id);
    }

    toString(): string {
        return `${this._name.toString()} Enemy(${this._id}): ` +
            `HealthPoints=${this._healthPoints}, ` +
            `AttackDamage=${this._attackDamage}, ` +
            `SpeedAttack=${this._speedAttack}, ` +
            `RewardMoney=${this._rewardMoney}`;
    }
}
