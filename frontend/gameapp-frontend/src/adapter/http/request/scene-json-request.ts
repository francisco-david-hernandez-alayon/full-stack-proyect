import { EnemyJsonRequest } from "./enemy-json-request";
import { ItemJsonRequest } from "./item-json-request";
import { Scene } from "../../../domain/entities/scenes/scene";
import { EnemyScene } from "../../../domain/entities/scenes/enemy-scene";
import { ItemScene } from "../../../domain/entities/scenes/item-scene";
import { NothingHappensScene } from "../../../domain/entities/scenes/nothing-happens-scene";
import { TradeScene } from "../../../domain/entities/scenes/trade-scene";
import { ChangeBiomeScene } from "../../../domain/entities/scenes/change-biome-scene";
import { SceneType } from "../enumerates/scene-type";


export class SceneJsonRequest {
    id: string;
    name: string;
    description: string;
    biome: string;
    sceneType: SceneType;

    // Optional properties depending on scene type
    enemy?: EnemyJsonRequest;
    rewardItem?: ItemJsonRequest;
    merchantItemsOffer?: ItemJsonRequest[];
    merchantMoneyToSpent?: number;
    profitMerchantMargin?: number;

    constructor(scene: Scene) {
        this.id = scene.id;
        this.name = scene.name.name;
        this.description = scene.description.description;
        this.biome = scene.biome;

        if (scene instanceof EnemyScene) {
            this.sceneType = SceneType.Enemy;
            if (!scene.enemy) throw new TypeError("EnemyScene must have an enemy");
            this.enemy = new EnemyJsonRequest(scene.enemy);

        } else if (scene instanceof ItemScene) {
            this.sceneType = SceneType.Item;
            if (!scene.rewardItem) throw new TypeError("ItemScene must have a rewardItem");
            this.rewardItem = new ItemJsonRequest(scene.rewardItem);

        } else if (scene instanceof NothingHappensScene) {
            this.sceneType = SceneType.NothingHappens;

        } else if (scene instanceof TradeScene) {
            this.sceneType = SceneType.Trade;
            this.merchantItemsOffer = scene.merchantItemsOffer.map(i => new ItemJsonRequest(i));
            this.merchantMoneyToSpent = scene.merchantMoneyToSpent ?? 0;
            this.profitMerchantMargin = scene.profitMerchantMargin ?? 0;


        } else if (scene instanceof ChangeBiomeScene) {
            this.sceneType = SceneType.ChangeBiome;
        } else {
            this.sceneType = SceneType.None;
        }
    }

    toString(): string {
        return JSON.stringify(this, null, 2);
    }
}
