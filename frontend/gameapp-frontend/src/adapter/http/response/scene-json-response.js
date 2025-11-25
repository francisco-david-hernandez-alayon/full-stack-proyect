import { Enemy } from "../../../domain/value-objects/enemies/enemy";
import { Item } from "../../../domain/value-objects/items/item";
import { AttackItem } from "../../../domain/value-objects/items/attack-item";
import { AttributeItem } from "../../../domain/value-objects/items/attribute-item";
import { ItemType } from "../enumerates/item-type";
import { ItemDescription } from "../../../domain/value-objects/items/item-description";
import { ItemName } from "../../../domain/value-objects/items/item-name";
import { EnemyScene } from "../../../domain/value-objects/scenes/enemy-scene";
import { EnterDungeonScene } from "../../../domain/value-objects/scenes/enter-dungeon-scene";
import { ItemScene } from "../../../domain/value-objects/scenes/item-scene";
import { NothingHappensScene } from "../../../domain/value-objects/scenes/nothing-happens-scene";
import { SceneDescription } from "../../../domain/value-objects/scenes/scene-description";
import { SceneName } from "../../../domain/value-objects/scenes/scene-name";
import { TradeScene } from "../../../domain/value-objects/scenes/trade-scene";
import { SceneType } from "../enumerates/scene-type";
import { EnemyName } from "../../../domain/value-objects/enemies/enemy-name";

export class SceneJsonResponse {
    constructor(json) {
        if (!json) throw new TypeError("json response is required");

        this.id = json.id;
        this.name = json.name;
        this.description = json.description;
        this.biome = json.biome;
        this.sceneType = json.sceneType;

        // EnemyScene
        this.enemy = json.enemy ? this.#mapEnemy(json.enemy) : null;

        // EnterDungeonScene
        this.possibleScenes = json.possibleScenes
            ? json.possibleScenes.map(s => new SceneJsonResponse(s))
            : null;

        // ItemScene
        this.rewardItem = json.rewardItem
            ? this.#mapItem(json.rewardItem)
            : null;

        // TradeScene
        this.characterItemsOffer = json.characterItemsOffer?.map(i =>
            this.#mapItem(i)
        ) ?? null;

        this.characterMoneyOffer = json.characterMoneyOffer ?? null;

        this.merchantItemsOffer = json.merchantItemsOffer?.map(i =>
            this.#mapItem(i)
        ) ?? null;

        this.merchantMoneyOffer = json.merchantMoneyOffer ?? null;
    }

    #mapEnemy(enemy) {
        return {
            name: enemy.name,
            healthPoints: enemy.healthPoints,
            damageAttack: enemy.damageAttack,
            speedAttack: enemy.speedAttack,
            moneyReward: enemy.moneyReward,
        };
    }

    #mapItem(item) {
        return {
            name: item.name,
            description: item.description,
            itemType: item.itemType,

            healthPointsReceived: item.healthPointsReceived ?? null,
            foodPointsReceived: item.foodPointsReceived ?? null,
            attackDamage: item.attackDamage ?? null,
            speedAttack: item.speedAttack ?? null,
            durability: item.durability ?? null,
        };
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

    toScene() {
        const name = new SceneName(this.name);
        const desc = new SceneDescription(this.description);

        switch (this.sceneType) {
            case SceneType.NothingHappens:
                return new NothingHappensScene(name, desc, this.biome, this.id);

            case SceneType.Enemy:
                const enemy = this.enemy
                    ? new Enemy(
                        new EnemyName(this.enemy.name),
                        this.enemy.healthPoints,
                        this.enemy.damageAttack,
                        this.enemy.speedAttack,
                        this.enemy.moneyReward
                    )
                    : null;
                return new EnemyScene(name, desc, this.biome, enemy, this.id);

            case SceneType.Item:
                const reward = this.rewardItem ? this.#toItem(this.rewardItem) : null;
                return new ItemScene(name, desc, this.biome, reward, this.id);

            case SceneType.EnterDungeon:
                const children = (this.possibleScenes ?? []).map(s => {
                                    const sceneResponse = new SceneJsonResponse(s);
                                    return sceneResponse.toScene();
                                });
                return new EnterDungeonScene(name, desc, this.biome, children, this.id);

            case SceneType.Trade:
                return new TradeScene(
                    name,
                    desc,
                    this.biome,
                    (this.characterItemsOffer ?? []).map(i => this.#toItem(i)),
                    this.characterMoneyOffer,
                    (this.merchantItemsOffer ?? []).map(i => this.#toItem(i)),
                    this.merchantMoneyOffer,
                    this.id
                );

            default:
                throw new TypeError(`Unknown SceneType '${this.sceneType}'`);
        }
    }
}
