import { Game } from "../../../domain/entities/game";
import { UserAction } from "../../../domain/enumerates/user-action";
import { WarriorCharacter } from "../../../domain/value-objects/characters/warrior-character";
import { CharacterType } from "../../../application/enumerates/character-type";
import { FinalSceneJsonRequest } from "./final-scene-json-request";
import { SceneJsonRequest } from "./scene-json-request";
import type { GameDifficulty } from "../../../domain/enumerates/game-difficulty";
import { ThiefCharacter } from "../../../domain/value-objects/characters/thief-caracter";
import { BerserkerCharacter } from "../../../domain/value-objects/characters/berserker-character";
import { ExplorerCharacter } from "../../../domain/value-objects/characters/explorer-character";

export class GamePostJsonRequest {
    difficulty: GameDifficulty;
    character: CharacterType;
    numberScenesToFinish: number;
    finalScene: FinalSceneJsonRequest;
    listCurrentScenes: SceneJsonRequest[];
    listCurrentUserActions: UserAction[];

    constructor(game: Game) {
        if (!game) throw new TypeError("game instance is required");

        this.difficulty = game.difficulty;

        // 1. Character
        switch (true) {
            case game.character instanceof WarriorCharacter:
                this.character = CharacterType.Warrior;
                break;

            case game.character instanceof ThiefCharacter:
                this.character = CharacterType.Thief;
                break;

            case game.character instanceof BerserkerCharacter:
                this.character = CharacterType.Berserker;
                break;
                
            case game.character instanceof ExplorerCharacter:
                this.character = CharacterType.Explorer;
                break;

            default:
                throw new TypeError(
                    `Unknown character class: '${game.character.constructor.name}'`
                );
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
