import { Game } from "../../../domain/entities/game.js";
import { UserAction } from "../../../domain/enumerates/user-action.js";
import { WarriorCharacter } from "../../../domain/value-objects/characters/warrior-character.js";
import { NothingHappensScene } from "../../../domain/entities/scenes/nothing-happens-scene.js";
import { SceneDescription } from "../../../domain/value-objects/scenes/scene-description.js";
import { SceneName } from "../../../domain/value-objects/scenes/scene-name.js";
import { CharacterType } from "../enumerates/character-type.js";
import { SceneJsonResponse } from "./scene-json-response.js";
import { ItemJsonResponse } from "./item-json-response.js";
import { EnemyJsonResponse } from "./enemy-json-response.js";

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
