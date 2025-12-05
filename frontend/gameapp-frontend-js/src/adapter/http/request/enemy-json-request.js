import { Enemy } from "../../../domain/entities/enemy";

export class EnemyJsonRequest {
    constructor(enemy) {
        if (!enemy) throw new TypeError("enemy is required");
        if (!(enemy instanceof Enemy)) throw new TypeError("enemy must be an instance of Enemy");

        this.id = enemy.id
        this.name = enemy.name.name;
        this.healthPoints = enemy.healthPoints;
        this.damageAttack = enemy.damageAttack;
        this.speedAttack = enemy.speedAttack;
        this.moneyReward = enemy.moneyReward;
    }

    toString() {
        return JSON.stringify(this, null, 2);
    }
}
