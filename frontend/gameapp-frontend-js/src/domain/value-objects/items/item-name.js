// Value Object for item name
export class ItemName {
  static ERROR_EMPTY = "Item name cannot be empty";

  constructor(name) {
    this.#validateName(name);
    this._name = name;
  }

  #validateName(name) {
    if (!name || name.trim().length === 0) {
      throw new Error(ItemName.ERROR_EMPTY);
    }
  }

  // getter
  get name() {
    return this._name;
  }

  // setter
  setName(newName) {
    this.#validateName(newName);
    return new ItemName(newName);
  }

  equals(other) {
    if (!(other instanceof ItemName)) return false;
    return this._name === other._name;
  }

  toString() {
    return this._name;
  }
}