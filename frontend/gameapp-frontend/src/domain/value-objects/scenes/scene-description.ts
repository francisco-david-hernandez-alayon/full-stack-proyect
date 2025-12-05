// Value Object for Scene Description
export class SceneDescription {
    static ERROR_EMPTY = "Scene description cannot be empty";

    private _description: string;

    constructor(description: string) {
        this._description = description;
    }

    get description(): string {
        return this._description;
    }

    setDescription(newDescription: string): SceneDescription {
        return new SceneDescription(newDescription);
    }

    equals(other: unknown): boolean {
        return other instanceof SceneDescription &&
               this._description === other._description;
    }

    toString(): string {
        return this._description;
    }
}
