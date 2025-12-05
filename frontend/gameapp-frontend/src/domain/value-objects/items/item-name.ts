// Value Object for item name
export class ItemName {
    static ERROR_EMPTY = "Item name cannot be empty";

    private _name: string;

    constructor(name: string) {
        this._name = name;
    }

    get name(): string {
        return this._name;
    }

    setName(newName: string): ItemName {
        return new ItemName(newName);
    }

    equals(other: unknown): boolean {
        return other instanceof ItemName &&
               this._name === other._name;
    }

    toString(): string {
        return this._name;
    }
}
