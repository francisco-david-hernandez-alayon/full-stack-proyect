import { Enemy } from "../../../domain/entities/enemy";
import type { EnemyDifficulty } from "../../../domain/enumerates/enemy-difficulty";
import { CriticalDamage } from "../../../domain/value-objects/enemies/critical-damage";
import { EnemyName } from "../../../domain/value-objects/enemies/enemy-name";

export class EnemyJsonResponse {
    id: string;
    difficulty: EnemyDifficulty;
    name: string;
    healthPoints: number;
    damageAttack: number;
    speedAttack: number;
    criticalDamage: {
        criticalProbability: number;
        extraDamage: number;
    };
    moneyReward: number;

    constructor(enemyJson: {
        id: string;
        difficulty: EnemyDifficulty;
        name: string;
        healthPoints: number;
        damageAttack: number;
        speedAttack: number;
        criticalDamage: {
            criticalProbability: number;
            extraDamage: number;
        };
        moneyReward: number;
    }) {
        if (!enemyJson) throw new TypeError("enemyJson response is required");

        this.id = enemyJson.id;
        this.difficulty = enemyJson.difficulty;
        this.name = enemyJson.name;
        this.healthPoints = enemyJson.healthPoints;
        this.damageAttack = enemyJson.damageAttack;
        this.speedAttack = enemyJson.speedAttack;
        this.criticalDamage = enemyJson.criticalDamage;
        this.moneyReward = enemyJson.moneyReward;
    }

    toEnemy(): Enemy {
        const name = new EnemyName(this.name);
        const criticalDamage = new CriticalDamage(
            this.criticalDamage.criticalProbability,
            this.criticalDamage.extraDamage
        );

        return new Enemy(
            this.difficulty,
            name,
            this.healthPoints,
            this.damageAttack,
            this.speedAttack,
            criticalDamage,
            this.moneyReward,
            this.id
        );
    }
}
