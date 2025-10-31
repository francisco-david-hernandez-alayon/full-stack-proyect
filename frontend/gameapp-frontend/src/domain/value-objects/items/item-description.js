// Value Object for item description
export class ItemDescription {
  static ERROR_EMPTY = "Item description cannot be empty";

  constructor(description) {
    this.#validateDescription(description);
    this._description = description;
  }

  #validateDescription(description) {
    if (!description || description.trim().length === 0) {
      throw new Error(ItemDescription.ERROR_EMPTY);
    }
  }

  // getter
  get description() {
    return this._description;
  }

  // setter
  setDescription(newDescription) {
    this.#validateDescription(newDescription);
    return new ItemDescription(newDescription);
  }

  equals(other) {
    if (!(other instanceof ItemDescription)) return false;
    return this._description === other._description;
  }

  toString() {
    return this._description;
  }
}