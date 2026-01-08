import type { CriticalDamage } from "../../../domain/value-objects/enemies/critical-damage";

export class CriticalDamageJsonRequest {
    criticalProbability: number;
    extraDamage: number;

    constructor(cd: CriticalDamage) {
        if (!cd) throw new TypeError("Critical Damage is required");

        this.criticalProbability = cd.criticalProbability;
        this.extraDamage = cd.extraDamage;
    }

    toString(): string {
        return JSON.stringify(this, null, 2);
    }
}
