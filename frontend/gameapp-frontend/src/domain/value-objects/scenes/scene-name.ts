// Value Object for Scene Name
export class SceneName {
    static ERROR_EMPTY = "Scene name cannot be empty";

    private _name: string;

    constructor(name: string) {
        this._name = name;
    }

    get name(): string {
        return this._name;
    }

    setName(newName: string): SceneName {
        return new SceneName(newName);
    }

    equals(other: unknown): boolean {
        return other instanceof SceneName &&
               this._name === other._name;
    }

    toString(): string {
        return this._name;
    }
}

