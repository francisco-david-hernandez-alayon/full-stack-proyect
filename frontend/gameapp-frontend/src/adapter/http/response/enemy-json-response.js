import { Enemy } from "../../../domain/entities/enemy.js";
import { EnemyName } from "../../../domain/value-objects/enemies/enemy-name.js";

export class EnemyJsonResponse {
    constructor(enemyJson) {
        if (!enemyJson) throw new TypeError("enemyJson response is required");

        this.id = enemyJson.id;
        this.name = enemyJson.name;
        this.healthPoints = enemyJson.healthPoints;
        this.damageAttack = enemyJson.damageAttack;
        this.speedAttack = enemyJson.speedAttack;
        this.moneyReward = enemyJson.moneyReward;
    }

    toEnemy() {
        const name = new EnemyName(this.name);

        return new Enemy(
            name,
            this.healthPoints,
            this.damageAttack,
            this.speedAttack,
            this.moneyReward,
            this.id
        );
    }
}
