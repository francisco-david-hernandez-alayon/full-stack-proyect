import { Scene } from "../../entities/scene";

// NothingHappensScene
export class NothingHappensScene extends Scene {
    constructor(name, description, biome, id = null) {
        super(name, description, biome, id);
    }

    // setter
    setSceneName(newName) { return new NothingHappensScene(newName, this._description, this._biome); }
    setSceneDescription(newDescription) { return new NothingHappensScene(this._name, newDescription, this._biome); }
    setBiome(newBiome) { return new NothingHappensScene(this._name, this._description, newBiome); }

    toString() {
        return `${this._name} NothingHappens Scene: Description=${this._description}, Biome=${this._biome}`;
    }
}