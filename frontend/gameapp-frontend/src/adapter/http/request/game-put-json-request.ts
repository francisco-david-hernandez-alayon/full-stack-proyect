import { Game } from "../../../domain/entities/game";
import { UserAction } from "../../../domain/enumerates/user-action";
import { CharacterJsonRequest } from "./character-json-request";
import { EnemyJsonRequest } from "./enemy-json-request";
import { FinalSceneJsonRequest } from "./final-scene-json-request";
import { SceneJsonRequest } from "./scene-json-request";

export class GamePutJsonRequest {
    character: CharacterJsonRequest;
    numberScenesToFinish: number;
    finalScene: FinalSceneJsonRequest;
    listCurrentScenes: SceneJsonRequest[];
    listCurrentUserActions: UserAction[];
    listCompletedScenes: SceneJsonRequest[];
    currentEnemy?: EnemyJsonRequest;

    constructor(game: Game) {
        this.character = new CharacterJsonRequest(game.character);
        this.numberScenesToFinish = game.numberScenesToFinish;
        this.finalScene = new FinalSceneJsonRequest(game.finalScene);

        this.listCurrentScenes = game.currentScenes.map(scene => new SceneJsonRequest(scene));

        this.listCompletedScenes = game.completedScenes.map(scene => new SceneJsonRequest(scene));

        this.listCurrentUserActions = game.currentUserActions.map(action => action);

        if (game.currentEnemy) {
            this.currentEnemy = new EnemyJsonRequest(game.currentEnemy);
        }
    }

    toString(): string {
        return JSON.stringify(this, null, 2);
    }
}
