import { Scene } from "./scene";

// NothingHappensScene
export class NothingHappensScene extends Scene {
    constructor(name, description, biome) {
        super(name, description, biome);
    }

    // setter
    setSceneName(newName) { return new NothingHappensScene(newName, this._description, this._biome); }
    setSceneDescription(newDescription) { return new NothingHappensScene(this._name, newDescription, this._biome); }
    setBiome(newBiome) { return new NothingHappensScene(this._name, this._description, newBiome); }

    toString() {
        return `${this._name} NothingHappens Scene: Description=${this._description}, Biome=${this._biome}`;
    }
}