// Value Object for item description
export class ItemDescription {
    static ERROR_EMPTY = "Item description cannot be empty";

    private _description: string;

    constructor(description: string) {
        this._description = description;
    }

    get description(): string {
        return this._description;
    }

    setDescription(newDescription: string): ItemDescription {
        return new ItemDescription(newDescription);
    }

    equals(other: unknown): boolean {
        return other instanceof ItemDescription &&
               this._description === other._description;
    }

    toString(): string {
        return this._description;
    }
}
