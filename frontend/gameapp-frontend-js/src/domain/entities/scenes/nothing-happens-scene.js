import { Scene } from "./scene.js";

// NothingHappensScene
export class NothingHappensScene extends Scene {
    constructor(name, description, biome, id = null) {
        super(name, description, biome, id);
    }

    // setter
    setSceneName(newName) { return new NothingHappensScene(newName, this._description, this._biome, this._id); }
    setSceneDescription(newDescription) { return new NothingHappensScene(this._name, newDescription, this._biome, this._id); }
    setBiome(newBiome) { return new NothingHappensScene(this._name, this._description, newBiome, this._id); }

    toString() {
        return `${this._name} NothingHappens Scene(${this._id}): Description=${this._description}, Biome=${this._biome}`;
    }
}