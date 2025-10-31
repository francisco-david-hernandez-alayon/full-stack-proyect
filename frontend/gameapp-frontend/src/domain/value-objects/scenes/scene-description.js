// Value Object for Scene Description
export class SceneDescription {
    static ERROR_EMPTY = "Scene description cannot be empty";

    constructor(description) {
        this.#validateDescription(description);
        this._description = description;
    }

    #validateDescription(desc) {
        if (!desc || desc.trim().length === 0) throw new Error(SceneDescription.ERROR_EMPTY);
    }

    // getter
    get description() { return this._description; }

    // setter
    setDescription(newDescription) {
        this.#validateDescription(newDescription);
        return new SceneDescription(newDescription);
    }

    equals(other) {
        return other instanceof SceneDescription && this._description === other._description;
    }

    toString() { return this._description; }
}