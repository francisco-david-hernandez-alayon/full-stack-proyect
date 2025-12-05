import { NothingHappensScene } from "../../../domain/entities/scenes/nothing-happens-scene";

export class FinalSceneJsonRequest {
    id: string;
    name: string;
    description: string;
    biome: string;

    constructor(finalScene: NothingHappensScene) {
        if (!finalScene) throw new TypeError("finalScene is required");
        if (!(finalScene instanceof NothingHappensScene)) {
            throw new TypeError("finalScene must be an instance of NothingHappensScene");
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
