import { Scene } from "../../../domain/entities/scene";
import { Biome } from "../../../domain/enumerates/biome";
import { NothingHappensScene } from "../../../domain/value-objects/scenes/nothing-happens-scene";
import { SceneDescription } from "../../../domain/value-objects/scenes/scene-description";
import { SceneName } from "../../../domain/value-objects/scenes/scene-name";

export class FinalSceneJsonRequest {
    constructor(finalScene) {
        if (!finalScene) throw new TypeError("finalScene is required");

        if (!(finalScene instanceof NothingHappensScene)) {
            throw new TypeError("finalScene must be an instance of Scene");
        }

        // Name
        this.name = finalScene.name.name; 

        // Description
        this.description = finalScene.description.description; 

        // Biome
        this.biome = finalScene.biome;
    }

    toString() {
        return JSON.stringify(this, null, 2);
    }
}