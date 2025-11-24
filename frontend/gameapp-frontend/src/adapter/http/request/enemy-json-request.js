import { Enemy } from "../../../domain/value-objects/enemies/enemy.js";

export class EnemyJsonRequest {
    constructor(enemy) {
        if (!enemy) throw new TypeError("enemy is required");
        if (!(enemy instanceof Enemy)) throw new TypeError("enemy must be an instance of Enemy");

        this.name = enemy._name;
        this.healthPoints = enemy._healthPoints;
        this.damageAttack = enemy._damageAttack;
        this.speedAttack = enemy._speedAttack;
        this.moneyReward = enemy._moneyReward;
    }

    toString() {
        return JSON.stringify(this, null, 2);
    }
}
