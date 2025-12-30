import { Scene } from "./scene";
import { SceneName } from "../../value-objects/scenes/scene-name";
import { SceneDescription } from "../../value-objects/scenes/scene-description";
import { Biome } from "../../enumerates/biome";

export class FinalScene extends Scene {
    constructor(name: SceneName, description: SceneDescription, biome: Biome, id?: string) {
        super(name, description, biome, id);
    }

    setSceneName(newName: SceneName) {
        return new FinalScene(newName, this._description, this._biome, this._id);
    }
    setSceneDescription(newDescription: SceneDescription) {
        return new FinalScene(this._name, newDescription, this._biome, this._id);
    }
    setBiome(newBiome: Biome) {
        return new FinalScene(this._name, this._description, newBiome, this._id);
    }

    toString(): string {
        return `${this._name} Final Scene(${this._id}): Description=${this._description}, Biome=${this._biome}`;
    }
}
