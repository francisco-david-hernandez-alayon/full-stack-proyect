import { Enemy } from "../../../domain/entities/enemy";
import { EnemyName } from "../../../domain/value-objects/enemies/enemy-name";

export class EnemyJsonResponse {
    id: string;
    name: string;
    healthPoints: number;
    damageAttack: number;
    speedAttack: number;
    moneyReward: number;

    constructor(enemyJson: {
        id: string;
        name: string;
        healthPoints: number;
        damageAttack: number;
        speedAttack: number;
        moneyReward: number;
    }) {
        if (!enemyJson) throw new TypeError("enemyJson response is required");

        this.id = enemyJson.id;
        this.name = enemyJson.name;
        this.healthPoints = enemyJson.healthPoints;
        this.damageAttack = enemyJson.damageAttack;
        this.speedAttack = enemyJson.speedAttack;
        this.moneyReward = enemyJson.moneyReward;
    }

    toEnemy(): Enemy {
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
