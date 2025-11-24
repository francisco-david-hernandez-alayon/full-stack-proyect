import { Scene } from "../../../domain/entities/scene";
import { UserAction } from "../../../domain/enumerates/user-action";
import { WarriorCharacter } from "../../../domain/value-objects/characters/warrior-character";
import { NothingHappensScene } from "../../../domain/value-objects/scenes/nothing-happens-scene";
import { CharacterType } from "../enumerates/character-type";
import { FinalSceneJsonRequest } from "./final-scene-json-request";
import { SceneJsonRequest } from "./scene-json-request";

export class GamePostJsonRequest {
    constructor(game) {
        if (!game) throw new TypeError("game instance is required");

        // 1. Character
        if (game._character instanceof  WarriorCharacter) {
            this.character = CharacterType.Warrior;
        } else {
            throw new TypeError(`Unknown character class: '${game._character.constructor.name}'`);
        }

        // 2. NumberScenesToFinish
        if (typeof game._numberScenesToFinish !== "number" || !Number.isInteger(game._numberScenesToFinish) || game._numberScenesToFinish <= 0) {
            throw new TypeError("game._numberScenesToFinish must be a positive integer");
        }
        this.numberScenesToFinish = game.numberScenesToFinish;

        // 3. FinalScene
        if (!(game._finalScene instanceof NothingHappensScene)) {
            throw new TypeError("game._finalScene must be an instance of NothingHappensScene");
        }
        this.finalScene = new FinalSceneJsonRequest(game._finalScene);

        // 4. ListCurrentScenes 
        if (!Array.isArray(game._listCurrentScenes)) {
            throw new TypeError("game._listCurrentScenes must be an array");
        }
        this.listCurrentScenes = game._listCurrentScenes.map(scene => {
            if (!(scene instanceof Scene)) {
                throw new TypeError("All elements of game._listCurrentScenes must be instances of Scene");
            }
            return new SceneJsonRequest(scene);
        });

        // 5. ListCurrentUserActions
        if (!Array.isArray(game._listCurrentUserActions)) {
            throw new TypeError("game._listCurrentUserActions must be an array");
        }
        const validActions = Object.values(UserAction);
        this.listCurrentUserActions = game._listCurrentUserActions.map(action => {
            if (!validActions.includes(action)) {
                throw new TypeError(`Invalid UserAction value: '${action}'`);
            }
            return action;
        });
    }

    toString() {
        return JSON.stringify(this, null, 2);
    }
}
