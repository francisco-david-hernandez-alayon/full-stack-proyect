import { Scene } from "./scene";

// ChangeBiomeScene
export class ChangeBiomeScene extends Scene {
    constructor(name, description, biome) {
        super(name, description, biome);
    }

    // setter
    setSceneName(newName) { return new ChangeBiomeScene(newName, this._description, this._biome); }
    setSceneDescription(newDescription) { return new ChangeBiomeScene(this._name, newDescription, this._biome); }
    setBiome(newBiome) { return new ChangeBiomeScene(this._name, this._description, newBiome); }



    toString() {
        return `ChangeBiomeScene: ${this._name} - Description=${this._description}, BiomeToChange=${this._biome}`;
    }
}