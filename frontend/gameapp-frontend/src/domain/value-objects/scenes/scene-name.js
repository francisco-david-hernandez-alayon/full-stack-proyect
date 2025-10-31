// Value Object for Scene Name
export class SceneName {
    static ERROR_EMPTY = "Scene name cannot be empty";

    constructor(name) {
        this.#validateName(name);
        this._name = name;
    }

    #validateName(name) {
        if (!name || name.trim().length === 0) throw new Error(SceneName.ERROR_EMPTY);
    }

    // getter
    get name() { return this._name; }

    // setter
    setName(newName) {
        this.#validateName(newName);
        return new SceneName(newName);
    }

    equals(other) {
        return other instanceof SceneName && this._name === other._name;
    }

    toString() { return this._name; }
}