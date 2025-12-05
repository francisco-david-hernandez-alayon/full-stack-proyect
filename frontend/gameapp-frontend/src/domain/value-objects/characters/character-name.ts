// Value Object for Character Name
export class CharacterName {
    static ERROR_EMPTY = "Character name cannot be empty";

    private _name: string;

    constructor(name: string) {
        this._name = name;
    }

    get name(): string {
        return this._name;
    }

    setName(newName: string): CharacterName {
        return new CharacterName(newName);
    }

    equals(other: unknown): boolean {
        return other instanceof CharacterName &&
               this._name === other._name;
    }

    toString(): string {
        return this._name;
    }
}
