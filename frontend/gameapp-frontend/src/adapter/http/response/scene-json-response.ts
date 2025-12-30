import type { Enemy } from "../../../domain/entities/enemy";
import type { Item } from "../../../domain/entities/items/item";
import { EnemyScene } from "../../../domain/entities/scenes/enemy-scene";
import { ItemScene } from "../../../domain/entities/scenes/item-scene";
import { NothingHappensScene } from "../../../domain/entities/scenes/nothing-happens-scene";
import { ChangeBiomeScene } from "../../../domain/entities/scenes/change-biome-scene";
import { TradeScene } from "../../../domain/entities/scenes/trade-scene";
import { SceneDescription } from "../../../domain/value-objects/scenes/scene-description";
import { SceneName } from "../../../domain/value-objects/scenes/scene-name";
import { SceneType } from "../../../application/enumerates/scene-type";
import { EnemyJsonResponse } from "./enemy-json-response";
import { ItemJsonResponse } from "./item-json-response";
import type { Biome } from "../../../domain/enumerates/biome";
import { FinalScene } from "../../../domain/entities/scenes/final-scene";

export class SceneJsonResponse {
    id: string;
    name: string;
    description: string;
    biome: Biome;
    sceneType: SceneType;

    enemy: Enemy | null;
    rewardItem: Item | null;
    merchantItemsOffer: Item[];
    merchantMoneyToSpent: number;
    profitMerchantMargin: number;

    constructor(sceneJson: any) {
        if (!sceneJson) throw new TypeError("sceneJson response is required");

        this.id = sceneJson.id;
        this.name = sceneJson.name;
        this.description = sceneJson.description;
        this.biome = sceneJson.biome;
        this.sceneType = sceneJson.sceneType;

        this.enemy = sceneJson.enemy ? new EnemyJsonResponse(sceneJson.enemy).toEnemy() : null;
        this.rewardItem = sceneJson.rewardItem ? new ItemJsonResponse(sceneJson.rewardItem).toItem() : null;

        this.merchantItemsOffer = sceneJson.merchantItemsOffer
            ? sceneJson.merchantItemsOffer.map((i: any) => new ItemJsonResponse(i).toItem())
            : [];

        this.merchantMoneyToSpent = sceneJson.merchantMoneyToSpent ?? 0;
        this.profitMerchantMargin = sceneJson.profitMerchantMargin ?? 0;
    }

    toScene() {
        const name = new SceneName(this.name);
        const desc = new SceneDescription(this.description);

        switch (this.sceneType) {
            case SceneType.Final:
                return new FinalScene(name, desc, this.biome, this.id);
            case SceneType.NothingHappens:
                return new NothingHappensScene(name, desc, this.biome, this.id);
            case SceneType.ChangeBiome:
                return new ChangeBiomeScene(name, desc, this.biome, this.id);
            case SceneType.Enemy:
                if (!this.enemy) {
                    throw new TypeError(
                        `SceneType 'Enemy' requires a non-null 'enemy' attribute`
                    );
                }
                return new EnemyScene(name, desc, this.biome, this.enemy, this.id);

            case SceneType.Item:
                if (!this.rewardItem) {
                    throw new TypeError(
                        `SceneType 'Item' requires a non-null 'rewardItem' attribute`
                    );
                }
                return new ItemScene(name, desc, this.biome, this.rewardItem, this.id);
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
