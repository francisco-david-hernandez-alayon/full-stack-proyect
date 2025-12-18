import { Game } from "../../../domain/entities/game";
import { UserAction } from "../../../domain/enumerates/user-action";
import { WarriorCharacter } from "../../../domain/value-objects/characters/warrior-character";
import { CharacterType } from "../../../application/enumerates/character-type";
import { FinalSceneJsonRequest } from "./final-scene-json-request";
import { SceneJsonRequest } from "./scene-json-request";

export class GamePostJsonRequest {
    character: CharacterType;
    numberScenesToFinish: number;
    finalScene: FinalSceneJsonRequest;
    listCurrentScenes: SceneJsonRequest[];
    listCurrentUserActions: UserAction[];

    constructor(game: Game) {
        if (!game) throw new TypeError("game instance is required");

        // 1. Character
        if (game.character instanceof WarriorCharacter) {
            this.character = CharacterType.Warrior;
        } else {
            throw new TypeError(`Unknown character class: '${game.character.constructor.name}'`);
        }

        // 2. NumberScenesToFinish
        this.numberScenesToFinish = game.numberScenesToFinish;

        // 3. FinalScene
        this.finalScene = new FinalSceneJsonRequest(game.finalScene);

        // 4. ListCurrentScenes 
        this.listCurrentScenes = game.currentScenes.map(scene => {
            return new SceneJsonRequest(scene);
        });

        // 5. ListCurrentUserActions
        this.listCurrentUserActions = game.currentUserActions.map(action => {
            return action;
        });
    }

    toString(): string {
        return JSON.stringify(this, null, 2);
    }
}
