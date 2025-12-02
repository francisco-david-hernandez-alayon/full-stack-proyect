import { Game } from "../../../domain/entities/game";
import { Scene } from "../../../domain/entities/scenes/scene.js";
import { UserAction } from "../../../domain/enumerates/user-action";
import { Character } from "../../../domain/value-objects/characters/character";
import { Enemy } from "../../../domain/entities/enemy";
import { NothingHappensScene } from "../../../domain/entities/scenes/nothing-happens-scene.js";
import { CharacterJsonRequest } from "./character-json-request";
import { EnemyJsonRequest } from "./enemy-json-request";
import { FinalSceneJsonRequest } from "./final-scene-json-request";
import { SceneJsonRequest } from "./scene-json-request";

export class GamePutJsonRequest {
    constructor(game) {
        if (!game) throw new TypeError("game instance is required");

        if (!(game instanceof Game)) {
            throw new TypeError("game must be an instance of Game");
        }

        // 1. Character
        if (!(game.character instanceof Character)) {
            throw new TypeError("game.character must be an instance of Character");
        } 
        this.character = new CharacterJsonRequest(game.character);

        // 2. NumberScenesToFinish
        if (typeof game.numberScenesToFinish !== "number" || !Number.isInteger(game.numberScenesToFinish)) {
            throw new TypeError("game.numberScenesToFinish must be a positive integer");
        }
        this.numberScenesToFinish = game.numberScenesToFinish;

        // 3. FinalScene
        if (!(game.finalScene instanceof NothingHappensScene)) {
            throw new TypeError("game.finalScene must be an instance of NothingHappensScene");
        }
        this.finalScene = new FinalSceneJsonRequest(game.finalScene);

        // 4. ListCurrentScenes 
        if (!Array.isArray(game.currentScenes)) {
            throw new TypeError("game.currentScenes must be an array");
        }
        this.listCurrentScenes = game.currentScenes.map(scene => {
            if (!(scene instanceof Scene)) {
                throw new TypeError("All elements of game.listCurrentScenes must be instances of Scene");
            }
            return new SceneJsonRequest(scene);
        });

        // 5. ListCurrentUserActions
        if (!Array.isArray(game.currentUserActions)) {
            throw new TypeError("game.currentUserActions must be an array");
        }
        const validActions = Object.values(UserAction);
        this.listCurrentUserActions = game.currentUserActions.map(action => {
            if (!validActions.includes(action)) {
                throw new TypeError(`Invalid UserAction value: '${action}'`);
            }
            return action;
        });

        // 6. ListCompletedScenes
        if (!Array.isArray(game.completedScenes)) {
            throw new TypeError("game.completedScenes must be an array");
        }
        this.listCompletedScenes = game.completedScenes.map(scene => {
            if (!(scene instanceof Scene)) {
                throw new TypeError("All elements of game.listCompletedScenes must be instances of Scene");
            }
            return new SceneJsonRequest(scene);
        });


        // 7. CurrentEnemy (OPTIONAL)
        if ((game.currentEnemy instanceof Enemy)) {
            this.currentEnemy = new EnemyJsonRequest(game.currentEnemy);
        } 
        

    }

    toString() {
        return JSON.stringify(this, null, 2);
    }
}
