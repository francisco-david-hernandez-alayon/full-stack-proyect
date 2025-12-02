import { Scene } from "./scene.js";

// ChangeBiomeScene
export class ChangeBiomeScene extends Scene {
    constructor(name, description, biome, id = null) {
        super(name, description, biome, id);
    }

    // setter
    setSceneName(newName) { return new ChangeBiomeScene(newName, this._description, this._biome, this._id); }
    setSceneDescription(newDescription) { return new ChangeBiomeScene(this._name, newDescription, this._biome, this._id); }
    setBiome(newBiome) { return new ChangeBiomeScene(this._name, this._description, newBiome, this._id); }



    toString() {
        return `ChangeBiomeScene(${this._id}): ${this._name} - Description=${this._description}, BiomeToChange=${this._biome}`;
    }
}