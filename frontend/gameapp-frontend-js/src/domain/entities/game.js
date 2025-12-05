import { UserAction } from '../enumerates/user-action.js';
import { Character } from '../value-objects/characters/character.js';
import { Enemy } from './enemy.js';
import { NothingHappensScene } from './scenes/nothing-happens-scene.js';
import { Scene } from './scenes/scene.js';
import { validateOrGenerateUUID } from '../../utils/validate-or-generate-uuid.js';

export class Game {
    constructor(character, numberScenesToFinish, finalScene, listCurrentScenes = [], listCurrentUserActions = [], listCompletedScenes = [], currentEnemy = null, id = null) {
        this._id = validateOrGenerateUUID(id);

        if (!(character instanceof Character)) throw new TypeError("character must be an instance of Character");
        this._character = character;

        if (typeof numberScenesToFinish !== "number" || !Number.isInteger(numberScenesToFinish) || numberScenesToFinish <= 0) {
            throw new TypeError("numberScenesToFinish must be an integer greater than 0");
        }
        this._numberScenesToFinish = numberScenesToFinish;


        if (!(finalScene instanceof NothingHappensScene)) throw new TypeError("finalScene must be an instance of NothingHappensScene");
        this._finalScene = finalScene;

        this.#validateSceneList(listCurrentScenes, "listCurrentScenes");
        this._listCurrentScenes = [...listCurrentScenes];

        this.#validateSceneList(listCompletedScenes, "listCompletedScenes");
        this._listCompletedScenes = [...listCompletedScenes];

        this.#validateUserActionsList(listCurrentUserActions, "listCurrentUserActions");
        this._listCurrentUserActions = listCurrentUserActions;

        if (currentEnemy != null && !(currentEnemy instanceof Enemy)) throw new TypeError("currentEnemy must be an instance of Enemy or null");
        this._currentEnemy = currentEnemy;
    }

    #validateSceneList(list, paramName) {
        if (!Array.isArray(list)) throw new TypeError(`${paramName} must be an array`);
        for (const scene of list) {
            if (!(scene instanceof Scene)) {
                throw new TypeError(`All elements of ${paramName} must be instances of Scene or its subclasses`);
            }
        }
    }

    #validateUserActionsList(list, paramName) {
        if (!Array.isArray(list)) {
            throw new TypeError(`${paramName} must be an array`);
        }

        const validActions = Object.values(UserAction);

        for (const action of list) {
            if (!validActions.includes(action)) {
                throw new TypeError(
                    `${paramName} contains an invalid UserAction value: '${action}'`
                );
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
    get currentUserActions() { return [...this._listCurrentUserActions]; }
    get currentEnemy() { return this._currentEnemy; }

    // setter
    setCharacter(newCharacter) {
        return new Game(newCharacter, this._numberScenesToFinish, this._finalScene, this._listCurrentScenes, this._listCurrentUserActions, this._listCompletedScenes, this._currentEnemy, this._id);
    }

    setNumberScenesToFinish(newNumber) {
        return new Game(this._character, newNumber, this._finalScene, this._listCurrentScenes, this._listCurrentUserActions, this._listCompletedScenes, this._currentEnemy, this._id);
    }

    addCompletedScene(newScene) {
        const newList = [...this._listCompletedScenes, newScene];
        return new Game(this._character, this._numberScenesToFinish, this._finalScene, this._listCurrentScenes, this._listCurrentUserActions, newList, this._currentEnemy, this._id);
    }

    removeLastCompletedScene() {
        if (this._listCompletedScenes.length === 0) return this;
        const newList = [...this._listCompletedScenes];
        newList.pop();
        return new Game(this._character, this._numberScenesToFinish, this._finalScene, this._listCurrentScenes, this._listCurrentUserActions, newList, this._currentEnemy, this._id);
    }

    setFinalScene(newFinalScene) {
        return new Game(this._character, this._numberScenesToFinish, newFinalScene, this._listCurrentScenes, this._listCurrentUserActions, this._listCompletedScenes, this._currentEnemy, this._id);
    }

    setCurrentScenes(newList) {
        return new Game(this._character, this._numberScenesToFinish, this._finalScene, newList, this._listCurrentUserActions, this._listCompletedScenes, this._currentEnemy, this._id);
    }

    setCurrentUserActions(newListCurrenUserActions) {
        return new Game(this._character, this._numberScenesToFinish, this._finalScene, this._listCurrentScenes, newListCurrenUserActions, this._listCompletedScenes, this._currentEnemy, this._id);
    }

    setCurrentEnemy(newCurrentEnemy) {
        return new Game(this._character, this._numberScenesToFinish, this._finalScene, this._listCurrentScenes, this._listCurrentUserActions, this._listCompletedScenes, newCurrentEnemy, this._id);
    }

    updateGame(newCharacter, newNumberScenesToFinish, newCompletedScenes, newFinalScene, newListCurrenUserActions, newListCurrentScenes, newCurrentEnemy) {
        return new Game(newCharacter, newNumberScenesToFinish, newFinalScene, newListCurrentScenes, newListCurrenUserActions, newCompletedScenes, newCurrentEnemy, this._id);
    }

    toString() {
        const completedStr = this._listCompletedScenes.map(s => s.name.toString()).join(", ");
        const currentScenesStr = this._listCurrentScenes.map(s => s.name.toString()).join(", ");
        const currentUserActionsStr = this._listCurrentUserActions.join(", ");
        return `Game ${this._id}: Character=${this._character.name.toString()}, NumberScenesToFinish=${this._numberScenesToFinish}, ` +
            `CompletedScenes=[${completedStr}], FinalScene=${this._finalScene?.name.toString()}, CurrentScenes=[${currentScenesStr}], CurrentUserActions=[${currentUserActionsStr}], CurrentEnemy=${this._currentEnemy}`;
    }
}
