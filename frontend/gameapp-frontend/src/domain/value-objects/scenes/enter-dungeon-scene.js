import { Scene } from "../../entities/scene";
import { ChangeBiomeScene } from "./change-biome-scene";

// EnterDungeonScene
export class EnterDungeonScene extends Scene {
    constructor(name, description, biome, possibleScenes = [], id = null) {
        super(name, description, biome, id);
        this._possibleScenes = possibleScenes;
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