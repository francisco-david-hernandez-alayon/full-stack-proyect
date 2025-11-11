import { Enemy } from "../enemies/enemy";
import { Scene } from "../../entities/scene";

// EnemyScene
export class EnemyScene extends Scene {
    constructor(name, description, biome, enemy, id = null) {
        super(name, description, biome, id);
        if (!(enemy instanceof Enemy)) throw new TypeError("enemy must be Enemy");
        this._enemy = enemy;
    }

    // getter
    get enemy() { return this._enemy; }

    // setter
    setSceneName(newName) { return new EnemyScene(newName, this._description, this._biome, this._enemy); }
    setSceneDescription(newDescription) { return new EnemyScene(this._name, newDescription, this._biome, this._enemy); }
    setBiome(newBiome) { return new EnemyScene(this._name, this._description, newBiome, this._enemy); }
    
    setEnemy(newEnemy) { return new EnemyScene(this._name, this._description, this._biome, newEnemy); }

    toString() {
        return `${this._name} Enemy Scene: Description=${this._description}, Biome=${this._biome}, Enemy=${this._enemy}`;
    }
}