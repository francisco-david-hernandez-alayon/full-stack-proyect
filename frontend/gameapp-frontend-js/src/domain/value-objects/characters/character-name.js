// Value Object for Character Name
export class CharacterName {
    static ERROR_EMPTY = "Character name cannot be empty";

    constructor(name) {
        this.#validateName(name);
        this._name = name;
    }

    #validateName(name) {
        if (!name || name.trim().length === 0) {
            throw new Error(CharacterName.ERROR_EMPTY);
        }
    }

    // getter
    get name() {
        return this._name;
    }

    // setter
    setName(newName) {
        this.#validateName(newName);
        return new CharacterName(newName);
    }

    equals(other) {
        if (!(other instanceof CharacterName)) return false;
        return this._name === other._name;
    }

    toString() {
        return this._name;
    }
}