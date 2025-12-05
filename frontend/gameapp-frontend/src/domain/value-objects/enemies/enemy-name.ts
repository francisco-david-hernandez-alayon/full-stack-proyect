// Value Object for enemy name
export class EnemyName {
    static ERROR_EMPTY = "Enemy name cannot be empty";

    private _name: string;

    constructor(name: string) {
        this._name = name;
    }

    get name(): string {
        return this._name;
    }

    setName(newName: string): EnemyName {
        return new EnemyName(newName);
    }

    equals(other: unknown): boolean {
        return other instanceof EnemyName &&
               this._name === other._name;
    }

    toString(): string {
        return this._name;
    }
}


