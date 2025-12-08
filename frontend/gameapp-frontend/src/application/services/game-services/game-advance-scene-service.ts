import type { IGameRepository } from "../../repositories/igame-repository";
import { Game } from "../../../domain/entities/game";
import type { IGameAdvanceSceneUseCase } from "../../usecases/game-use-cases/game-advance-scene-use-case";
import { Scene } from "../../../domain/entities/scenes/scene";
import { UserAction } from "../../../domain/enumerates/user-action";
import { ChangeBiomeScene } from "../../../domain/entities/scenes/change-biome-scene";
import { NothingHappensScene } from "../../../domain/entities/scenes/nothing-happens-scene";
import { ItemScene } from "../../../domain/entities/scenes/item-scene";
import { TradeScene } from "../../../domain/entities/scenes/trade-scene";
import { EnemyScene } from "../../../domain/entities/scenes/enemy-scene";

export class GameAdvanceSceneService implements IGameAdvanceSceneUseCase {
    constructor(private readonly gameRepository: IGameRepository) { }

    async advance(currentSceneSelectedId: string, game: Game): Promise<Game> {
        // cant advance if cannot move forward
        if (!game.currentUserActions.find(userAction => userAction === UserAction.MOVE_FORWARD)) {
            return game;
        }

        let updatedGame;
        let updateUserActions: UserAction[] = [UserAction.USE_ITEM];

        // There are two or more scenes to move(must select one current scene first)
        if (game.currentScenes.length > 1) {
            const currentSceneSelected: Scene | undefined = game.currentScenes.find(scene => scene.id == currentSceneSelectedId);

            if (currentSceneSelected === undefined) {
                throw new Error(`Selected scene not found in game current scenes: '${currentSceneSelectedId}'`);
            }

            updatedGame = game.setCurrentScenes([currentSceneSelected])

            switch (true) {
                case currentSceneSelected instanceof NothingHappensScene:
                    updateUserActions.push(UserAction.MOVE_FORWARD);
                    break;

                case currentSceneSelected instanceof ChangeBiomeScene:
                    updateUserActions.push(UserAction.MOVE_FORWARD);
                    break;

                case currentSceneSelected instanceof ItemScene:
                    updateUserActions.push(UserAction.MOVE_FORWARD);
                    updateUserActions.push(UserAction.GET_ITEM);
                    updateUserActions.push(UserAction.CHANGE_ITEM);
                    updateUserActions.push(UserAction.USE_CURRENT_SCENE_ITEM);
                    break;
                
                case currentSceneSelected instanceof TradeScene:
                    updateUserActions.push(UserAction.MOVE_FORWARD);
                    updateUserActions.push(UserAction.BUY_ITEMS);
                    updateUserActions.push(UserAction.SOLD_ITEMS);
                    break;

                case currentSceneSelected instanceof EnemyScene:
                    updateUserActions.push(UserAction.ATTACK_ENEMY_WITH_ITEM);
                    updateUserActions.push(UserAction.ATTACK_ENEMY_WITHOUT_ITEM);
                    updatedGame = updatedGame.setCurrentEnemy(currentSceneSelected.enemy);
                    break;

                default:
                    break;
            }

            updatedGame = updatedGame.setCurrentUserActions(updateUserActions);


            // Only one scene to move(must generate current scenes again)
        } else {
            updatedGame = await this.gameRepository.generateNewScene(currentSceneSelectedId, game);
        }

        return updatedGame;
    }
}
