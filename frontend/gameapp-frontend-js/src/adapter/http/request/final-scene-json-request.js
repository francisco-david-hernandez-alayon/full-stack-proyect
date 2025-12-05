
import { NothingHappensScene } from "../../../domain/entities/scenes/nothing-happens-scene.js";

export class FinalSceneJsonRequest {
    constructor(finalScene) {
        if (!finalScene) throw new TypeError("finalScene is required");

        if (!(finalScene instanceof NothingHappensScene)) {
            throw new TypeError("finalScene must be an instance of Scene");
        }

        this.id = finalScene.id; 
        this.name = finalScene.name.name; 
        this.description = finalScene.description.description; 
        this.biome = finalScene.biome;
    }

    toString() {
        return JSON.stringify(this, null, 2);
    }
}