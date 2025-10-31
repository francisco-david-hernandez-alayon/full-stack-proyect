import { Character } from '../value-objects/characters/character';
import { NothingHappensScene } from '../value-objects/scenes/nothing-happens-scene.js';
import { Scene } from '../value-objects/scenes/scene.js';
import { v4 as uuidv4 } from "uuid";

export class Game {
    constructor(character, numberScenesToFinish, finalScene, listCurrentScenes = [], listCompletedScenes = [], id = null) {
        this._id = id ?? uuidv4();

        if (!(character instanceof Character)) throw new TypeError("character must be an instance of Character");
        this._character = character;

        if (typeof numberScenesToFinish !== "number" || !Number.isFinite(numberScenesToFinish)) {
            throw new TypeError("numberScenesToFinish must be a finite number");
        }
        this._numberScenesToFinish = numberScenesToFinish;

        if (!(finalScene instanceof NothingHappensScene)) throw new TypeError("finalScene must be an instance of NothingHappensScene");
        this._finalScene = finalScene;

        this.#validateSceneList(listCurrentScenes, "listCurrentScenes");
        this._listCurrentScenes = [...listCurrentScenes];

        this.#validateSceneList(listCompletedScenes, "listCompletedScenes");
        this._listCompletedScenes = [...listCompletedScenes];
    }

    #validateSceneList(list, paramName) {
        if (!Array.isArray(list)) throw new TypeError(`${paramName} must be an array`);
        for (const scene of list) {
            if (!(scene instanceof Scene)) {
                throw new TypeError(`All elements of ${paramName} must be instances of Scene or its subclasses`);
            }
        }
    }

    // getter
    get id() { return this._id; }
    get character() { return this._character; }
    get numberScenesToFinish() { return this._numberScenesToFinish; }
    get completedScenes() { return [...this._listCompletedScenes]; }
    get finalScene() { return this._finalScene; }
    get currentScenes() { return [...this._listCurrentScenes]; }

    // setter
    setCharacter(newCharacter) {
        return new Game(newCharacter, this._numberScenesToFinish, this._finalScene, this._listCurrentScenes, this._id, this._listCompletedScenes);
    }

    setNumberScenesToFinish(newNumber) {
        return new Game(this._character, newNumber, this._finalScene, this._listCurrentScenes, this._id, this._listCompletedScenes);
    }

    addCompletedScene(newScene) {
        const newList = [...this._listCompletedScenes, newScene];
        return new Game(this._character, this._numberScenesToFinish, this._finalScene, this._listCurrentScenes, this._id, newList);
    }

    removeLastCompletedScene() {
        if (this._listCompletedScenes.length === 0) return this;
        const newList = [...this._listCompletedScenes];
        newList.pop();
        return new Game(this._character, this._numberScenesToFinish, this._finalScene, this._listCurrentScenes, this._id, newList);
    }

    setFinalScene(newFinalScene) {
        return new Game(this._character, this._numberScenesToFinish, newFinalScene, this._listCurrentScenes, this._id, this._listCompletedScenes);
    }

    setCurrentScenes(newList) {
        return new Game(this._character, this._numberScenesToFinish, this._finalScene, newList, this._id, this._listCompletedScenes);
    }

    updateGame(newCharacter, newNumberScenesToFinish, newCompletedScenes, newFinalScene, newListCurrentScenes) {
        return new Game(newCharacter, newNumberScenesToFinish, newFinalScene, newListCurrentScenes, this._id, newCompletedScenes);
    }

    toString() {
        const completedStr = this._listCompletedScenes.map(s => s.name.toString()).join(", ");
        const currentStr = this._listCurrentScenes.map(s => s.name.toString()).join(", ");
        return `Game ${this._id}: Character=${this._character.name.toString()}, NumberScenesToFinish=${this._numberScenesToFinish}, ` +
            `CompletedScenes=[${completedStr}], FinalScene=${this._finalScene?.name.toString()}, CurrentScenes=[${currentStr}]`;
    }
}
