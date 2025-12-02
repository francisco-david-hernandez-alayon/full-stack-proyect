import { Game } from "../../../domain/entities/game";
import { UserAction } from "../../../domain/enumerates/user-action";
import { WarriorCharacter } from "../../../domain/value-objects/characters/warrior-character";
import { NothingHappensScene } from "../../../domain/entities/scenes/nothing-happens-scene.js";
import { SceneDescription } from "../../../domain/value-objects/scenes/scene-description";
import { SceneName } from "../../../domain/value-objects/scenes/scene-name";
import { CharacterType } from "../enumerates/character-type";
import { SceneJsonResponse } from "./scene-json-response";
import { ItemJsonResponse } from "./item-json-response";
import { EnemyJsonResponse } from "./enemy-json-response";

export class GameJsonResponse {
    constructor(GameJson) {
        if (!GameJson) throw new TypeError("GameJson response is required");

        this.id = GameJson.id;

        this.character = {
            type: GameJson.character.type,
            currentHealthPoints: GameJson.character.currentHealthPoints,
            currentFoodPoints: GameJson.character.currentFoodPoints,
            currentMoney: GameJson.character.currentMoney,
            inventoryList: GameJson.character.inventoryList ?? [],
        };

        this.numberScenesToFinish = GameJson.numberScenesToFinish;

        this.listCompletedScenes = GameJson.listCompletedScenes ?? [];
        this.listCurrentScenes = GameJson.listCurrentScenes ?? [];
        this.listCurrentUserActions = GameJson.listCurrentUserActions ?? [];

        this.finalScene = {
            name: GameJson.finalScene.name,
            description: GameJson.finalScene.description,
            biome: GameJson.finalScene.biome,
        };

        this.currentEnemy = GameJson.currentEnemy ?? null;
    }

    toGame() {
        let char;

        switch (this.character.type) {
            case CharacterType.Warrior: {
                const inventory = this.character.inventoryList.map(i => new ItemJsonResponse(i).toItem());
                char = new WarriorCharacter(
                    this.character.currentHealthPoints,
                    this.character.currentFoodPoints,
                    this.character.currentMoney,
                    inventory
                );
                break;
            }

            default:
                throw new TypeError(`Unknown character type received: '${this.character.type}'`);
        }

        const finalScene = new NothingHappensScene(
            new SceneName(this.finalScene.name),
            new SceneDescription(this.finalScene.description),
            this.finalScene.biome
        );

        const currentScenes = this.listCurrentScenes.map(scene => new SceneJsonResponse(scene).toScene());
        const completedScenes = this.listCompletedScenes.map(scene => new SceneJsonResponse(scene).toScene());

        const currentEnemy = this.currentEnemy
            ? new EnemyJsonResponse(this.currentEnemy).toEnemy()
            : null;

        const userActions = this.listCurrentUserActions.map(a => {
            if (!Object.values(UserAction).includes(a)) {
                throw new TypeError(`Invalid UserAction: ${a}`);
            }
            return a;
        });

        return new Game(
            char,
            this.numberScenesToFinish,
            finalScene,
            currentScenes,
            userActions,
            completedScenes,
            currentEnemy,
            this.id
        );
    }
}
