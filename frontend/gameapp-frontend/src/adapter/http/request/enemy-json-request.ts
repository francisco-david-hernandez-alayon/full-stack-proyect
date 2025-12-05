import { Enemy } from "../../../domain/entities/enemy";

export class EnemyJsonRequest {
    id: string;
    name: string;
    healthPoints: number;
    damageAttack: number;
    speedAttack: number;
    moneyReward: number;

    constructor(enemy: Enemy) {
        if (!enemy) throw new TypeError("enemy is required");
        if (!(enemy instanceof Enemy)) throw new TypeError("enemy must be an instance of Enemy");

        this.id = enemy.id;
        this.name = enemy.name.name;
        this.healthPoints = enemy.healthPoints;
        this.damageAttack = enemy.attackDamage;
        this.speedAttack = enemy.speedAttack;
        this.moneyReward = enemy.rewardMoney;
    }

    toString(): string {
        return JSON.stringify(this, null, 2);
    }
}
