import { Game } from "../../../domain/entities/game";
import { UserAction } from "../../../domain/enumerates/user-action";
import { WarriorCharacter } from "../../../domain/value-objects/characters/warrior-character";
import { Enemy } from "../../../domain/value-objects/enemies/enemy";
import { AttackItem } from "../../../domain/value-objects/items/attack-item";
import { AttributeItem } from "../../../domain/value-objects/items/attribute-item";
import { ItemDescription } from "../../../domain/value-objects/items/item-description";
import { ItemName } from "../../../domain/value-objects/items/item-name";
import { NothingHappensScene } from "../../../domain/entities/scenes/nothing-happens-scene.js";
import { SceneDescription } from "../../../domain/value-objects/scenes/scene-description";
import { SceneName } from "../../../domain/value-objects/scenes/scene-name";
import { CharacterType } from "../enumerates/character-type";
import { ItemType } from "../enumerates/item-type";
import { SceneJsonResponse } from "./scene-json-response";

export class GameJsonResponse {
    constructor(json) {
        if (!json) throw new TypeError("json response is required");

        this.id = json.id;

        this.character = {
            type: json.character.type,
            currentHealthPoints: json.character.currentHealthPoints,
            currentFoodPoints: json.character.currentFoodPoints,
            currentMoney: json.character.currentMoney,
            inventoryList: json.character.inventoryList ?? [],
        };

        this.numberScenesToFinish = json.numberScenesToFinish;

        this.listCompletedScenes =
            json.listCompletedScenes?.map(scene => this.#mapScene(scene)) ?? [];

        this.listCurrentScenes =
            json.listCurrentScenes?.map(scene => this.#mapScene(scene)) ?? [];

        this.listCurrentUserActions = json.listCurrentUserActions ?? [];

        this.finalScene = {
            name: json.finalScene.name,
            description: json.finalScene.description,
            biome: json.finalScene.biome,
        };

        this.currentEnemy = json.currentEnemy
            ? {
                name: json.currentEnemy.name,
                healthPoints: json.currentEnemy.healthPoints,
                damageAttack: json.currentEnemy.damageAttack,
                speedAttack: json.currentEnemy.speedAttack,
                moneyReward: json.currentEnemy.moneyReward,
            }
            : null;
    }




    #mapScene(scene) {
        return {
            id: scene.id,
            name: scene.name,
            description: scene.description,
            biome: scene.biome,
            sceneType: scene.sceneType,

            enemy: scene.enemy ?? null,
            possibleScenes: scene.possibleScenes ?? null,
            rewardItem: scene.rewardItem ?? null,

            characterItemsOffer: scene.characterItemsOffer ?? null,
            characterMoneyOffer: scene.characterMoneyOffer ?? null,
            merchantItemsOffer: scene.merchantItemsOffer ?? null,
            merchantMoneyOffer: scene.merchantMoneyOffer ?? null,
        };
    }


    //-------------------------------------------------------------------TO DOMAIN-----------------------------------------------------------//
    toGame() {
        // 1. Rebuild Character
        let char;

        switch (this.character.type) {

            case CharacterType.Warrior: {
                char = new WarriorCharacter(
                    this.character.currentHealthPoints,
                    this.character.currentFoodPoints,
                    this.character.currentMoney,
                    this.character.inventoryList.map(i => this.#toItem(i))
                );
                break;
            }

            default:
                throw new TypeError(
                    `Unknown character type received: '${this.character.type}'`
                );
        }

        // 2. Rebuild Final Scene (always NothingHappensScene)
        const finalScene = new NothingHappensScene(
            new SceneName(this.finalScene.name),
            new SceneDescription(this.finalScene.description),
            this.finalScene.biome
        );

        // 3. Rebuild current scenes
        const currentScenes = this.listCurrentScenes.map(s => {
            const sceneResponse = new SceneJsonResponse(s);
            return sceneResponse.toScene(); 
        });

        // 4. Rebuild completed scenes
        const completedScenes = this.listCompletedScenes.map(s => {
            const sceneResponse = new SceneJsonResponse(s);
            return sceneResponse.toScene(); 
        });


        // 5. Rebuild current enemy (may be null)
        const currentEnemy = this.currentEnemy
            ? new Enemy(
                this.currentEnemy.name,
                this.currentEnemy.healthPoints,
                this.currentEnemy.damageAttack,
                this.currentEnemy.speedAttack,
                this.currentEnemy.moneyReward
            )
            : null;

        // 6. Validate UserActions enum
        const userActions = this.listCurrentUserActions.map(a => {
            if (!Object.values(UserAction).includes(a)) {
                throw new TypeError(`Invalid UserAction: ${a}`);
            }
            return a;
        });

        // 7. Create the final Game object
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

    #toItem(json) {
        if (!json || !json.itemType) {
            throw new TypeError("Invalid item JSON or missing itemType");
        }

        switch (json.itemType) {
            case ItemType.Attribute:
                return new AttributeItem(
                    new ItemName(json.name),
                    new ItemDescription(json.description),
                    json.healthPointsReceived,
                    json.foodPointsReceived
                );
            case ItemType.Attack:
                return new AttackItem(
                    new ItemName(json.name),
                    new ItemDescription(json.description),
                    json.attackDamage,
                    json.speedAttack,
                    json.durability
                );
            default:
                throw new TypeError(`Unknown ItemType: ${json.itemType}`);
        }
    }


}
