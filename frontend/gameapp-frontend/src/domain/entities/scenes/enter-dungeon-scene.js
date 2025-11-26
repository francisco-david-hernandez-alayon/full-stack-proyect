import { Scene } from "./scene.js";
import { ChangeBiomeScene } from "./change-biome-scene";

// EnterDungeonScene
export class EnterDungeonScene extends Scene {
    constructor(name, description, biome, possibleScenes = [], id = null) {
        super(name, description, biome, id);
        this.#validatePossibleScene(possibleScenes);
        this._possibleScenes = possibleScenes;
    }

    #validatePossibleScene(possibleScenes) {
        if (!Array.isArray(possibleScenes)) {
            throw new TypeError("possibleScenes must be an array of Scene");
        }

        for (const s of possibleScenes) {
            if (!(s instanceof Scene)) {
                throw new TypeError("each element of possibleScenes must be an instance of Scene");
            }
        }
    }

    // getter
    get possibleScenes() { return [...this._possibleScenes]; }

    // setter
    setSceneName(newName) { return new ChangeBiomeScene(newName, this._description, this._biome, this._possibleScenes); }
    setSceneDescription(newDescription) { return new ChangeBiomeScene(this._name, newDescription, this._biome, this._possibleScenes); }
    setBiome(newBiome) { return new ChangeBiomeScene(this._name, this._description, newBiome, this._possibleScenes); }


    setPossibleScenes(newScenes) {
        return new EnterDungeonScene(this._name, this._description, this._biome, newScenes);
    }

    generateRandomScene() {
        const randomIndex = Math.floor(Math.random() * this._possibleScenes.length);
        return this._possibleScenes[randomIndex];
    }

    toString() {
        const scenesStr = this._possibleScenes.map(s => s.name.toString()).join(", ");
        return `EnterDungeonScene: ${this._name} - ${this._biome}\nDescription: ${this._description}\nPossible Scenes: [${scenesStr}]`;
    }
}