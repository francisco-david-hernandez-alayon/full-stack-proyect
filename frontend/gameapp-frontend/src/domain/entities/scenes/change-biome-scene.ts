import { Scene } from "./scene";
import { SceneName } from "../../value-objects/scenes/scene-name";
import { SceneDescription } from "../../value-objects/scenes/scene-description";
import { Biome } from "../../enumerates/biome";

export class ChangeBiomeScene extends Scene {
    constructor(
        name: SceneName,
        description: SceneDescription,
        biome: Biome,
        id?: string
    ) {
        super(name, description, biome, id);
    }

    setSceneName(newName: SceneName) {
        return new ChangeBiomeScene(newName, this._description, this._biome, this._id);
    }
    setSceneDescription(newDescription: SceneDescription) {
        return new ChangeBiomeScene(this._name, newDescription, this._biome, this._id);
    }
    setBiome(newBiome: Biome) {
        return new ChangeBiomeScene(this._name, this._description, newBiome, this._id);
    }

    toString(): string {
        return `ChangeBiomeScene(${this._id}): ${this._name} - Description=${this._description}, BiomeToChange=${this._biome}`;
    }
}
