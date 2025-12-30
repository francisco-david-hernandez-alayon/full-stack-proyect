import { FinalScene } from "../../../domain/entities/scenes/final-scene";

export class FinalSceneJsonRequest {
    id: string;
    name: string;
    description: string;
    biome: string;

    constructor(finalScene: FinalScene) {
        if (!finalScene) throw new TypeError("finalScene is required");
        if (!(finalScene instanceof FinalScene)) {
            throw new TypeError("finalScene must be an instance of FinalScene");
        }

        this.id = finalScene.id;
        this.name = finalScene.name.name;
        this.description = finalScene.description.description;
        this.biome = finalScene.biome;
    }

    toString(): string {
        return JSON.stringify(this, null, 2);
    }
}
