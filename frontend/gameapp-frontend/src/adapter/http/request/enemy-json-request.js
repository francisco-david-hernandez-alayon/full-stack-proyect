import { Enemy } from "../../../domain/value-objects/enemies/enemy.js";

export class EnemyJsonRequest {
    constructor(enemy) {
        if (!enemy) throw new TypeError("enemy is required");
        if (!(enemy instanceof Enemy)) throw new TypeError("enemy must be an instance of Enemy");

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
