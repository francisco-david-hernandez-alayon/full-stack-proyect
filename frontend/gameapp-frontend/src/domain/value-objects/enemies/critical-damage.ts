// Value Object for critical damage
export class CriticalDamage {
    static ERROR_INVALID_PROBABILITY =
        "Critical probability must be between 0 and 100";

    static ERROR_INVALID_EXTRA_DAMAGE =
        "Extra critical damage must be greater than or equal to 0";

    private readonly _criticalProbability: number;
    private readonly _extraDamage: number;

    constructor(criticalProbability: number, extraDamage: number) {
        if (criticalProbability < 0 || criticalProbability > 100) {
            throw new Error(CriticalDamage.ERROR_INVALID_PROBABILITY);
        }

        if (extraDamage < 0) {
            throw new Error(CriticalDamage.ERROR_INVALID_EXTRA_DAMAGE);
        }

        this._criticalProbability = criticalProbability;
        this._extraDamage = extraDamage;
    }

    // getters
    get criticalProbability(): number {
        return this._criticalProbability;
    }

    get extraDamage(): number {
        return this._extraDamage;
    }

    // immutable setters
    setCriticalProbability(newProbability: number): CriticalDamage {
        return new CriticalDamage(newProbability, this._extraDamage);
    }

    setExtraDamage(newExtraDamage: number): CriticalDamage {
        return new CriticalDamage(this._criticalProbability, newExtraDamage);
    }

    // equality
    equals(other: unknown): boolean {
        return other instanceof CriticalDamage &&
            this._criticalProbability === other._criticalProbability &&
            this._extraDamage === other._extraDamage;
    }

    toString(): string {
        return `CriticalDamage(probability=${this._criticalProbability}%, extraDamage=${this._extraDamage})`;
    }
}
