import { EnemyScene } from "../../../domain/entities/scenes/enemy-scene";
import { ItemScene } from "../../../domain/entities/scenes/item-scene";
import { NothingHappensScene } from "../../../domain/entities/scenes/nothing-happens-scene.js";
import { ChangeBiomeScene } from "../../../domain/entities/scenes/change-biome-scene.js";
import { SceneDescription } from "../../../domain/value-objects/scenes/scene-description";
import { SceneName } from "../../../domain/value-objects/scenes/scene-name";
import { TradeScene } from "../../../domain/entities/scenes/trade-scene";
import { SceneType } from "../enumerates/scene-type";
import { EnemyJsonResponse } from "./enemy-json-response";
import { ItemJsonResponse } from "./item-json-response";

export class SceneJsonResponse {
    constructor(sceneJson) {
        if (!sceneJson) throw new TypeError("sceneJson response is required");

        this.id = sceneJson.id;
        this.name = sceneJson.name;
        this.description = sceneJson.description;
        this.biome = sceneJson.biome;
        this.sceneType = sceneJson.sceneType;

        // EnemyScene
        this.enemy = sceneJson.enemy ? new EnemyJsonResponse(sceneJson.enemy).toEnemy() : null;

        // ItemScene
        this.rewardItem = sceneJson.rewardItem
            ? new ItemJsonResponse(sceneJson.rewardItem).toItem()
            : null;

        // TradeScene
        this.merchantItemsOffer = sceneJson.merchantItemsOffer
            ? sceneJson.merchantItemsOffer.map(i => new ItemJsonResponse(i).toItem())
            : [];

        this.merchantMoneyToSpent = sceneJson.merchantMoneyToSpent ?? 0;

        this.profitMerchantMargin = sceneJson.profitMerchantMargin ?? 0;

    }

    toScene() {
        const name = new SceneName(this.name);
        const desc = new SceneDescription(this.description);

        switch (this.sceneType) {

            case SceneType.NothingHappens:
                return new NothingHappensScene(
                    name,
                    desc,
                    this.biome,
                    this.id
                );

            case SceneType.ChangeBiome:
                return new ChangeBiomeScene(
                    name,
                    desc,
                    this.biome,
                    this.id
                );

            case SceneType.Enemy:
                return new EnemyScene(
                    name,
                    desc,
                    this.biome,
                    this.enemy,
                    this.id
                );

            case SceneType.Item:
                return new ItemScene(
                    name,
                    desc,
                    this.biome,
                    this.rewardItem,
                    this.id
                );

            case SceneType.Trade:
                return new TradeScene(
                    name,
                    desc,
                    this.biome,
                    this.merchantMoneyToSpent,
                    this.merchantItemsOffer,
                    this.profitMerchantMargin,
                    this.id
                );


            default:
                throw new TypeError(`Unknown SceneType '${this.sceneType}'`);
        }
    }
}
