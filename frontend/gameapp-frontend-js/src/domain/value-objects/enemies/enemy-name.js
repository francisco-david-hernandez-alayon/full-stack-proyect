export class EnemyName {
  static ERROR_EMPTY = "Enemy name cannot be empty";

  constructor(name) {
    this.#validateName(name);
    this._name = name;
  }
  
  #validateName(name) {
    if (!name || name.trim().length === 0) {
      throw new Error(EnemyName.ERROR_EMPTY);
    }
  }

  // Getter
  get name() {
    return this._name;
  }

  // Setter
  setName(newName) {
    this.#validateName(newName);
    return new EnemyName(newName);
  }

  equals(other) {
    if (!(other instanceof EnemyName)) return false;
    return this._name === other._name;
  }

  toString() {
    return this._name;
  }
}
