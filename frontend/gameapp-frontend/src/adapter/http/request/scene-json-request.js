import { EnemyJsonRequest } from "./enemy-json-request.js";
import { ItemJsonRequest } from "./item-json-request.js";
import { Enemy } from "../../../domain/value-objects/enemies/enemy.js";
import { Item } from "../../../domain/value-objects/items/item.js";
import { Scene } from "../../../domain/entities/scene.js";
import { EnemyScene } from "../../../domain/value-objects/scenes/enemy-scene.js";
import { EnterDungeonScene } from "../../../domain/value-objects/scenes/enter-dungeon-scene.js";
import { ItemScene } from "../../../domain/value-objects/scenes/item-scene.js";
import { NothingHappensScene } from "../../../domain/value-objects/scenes/nothing-happens-scene.js";
import { TradeScene } from "../../../domain/value-objects/scenes/trade-scene.js";
import { ChangeBiomeScene } from "../../../domain/value-objects/scenes/change-biome-scene.js";
import { SceneType } from "../enumerates/scene-type.js";

export class SceneJsonRequest {
    constructor(scene) {
        if (!scene) throw new TypeError("scene is required");

        if (!(scene instanceof Scene)) {
            throw new TypeError("scene must be an instance of Scene");
        }

        this.id = scene._id;
        this.name = scene.name.name;
        this.description = scene.description.description;
        this.biome = scene.biome;
        if (scene instanceof EnemyScene) {
            this.sceneType = SceneType.Enemy;
        } else if (scene instanceof EnterDungeonScene) {
            this.sceneType = SceneType.EnterDungeon;
        } else if (scene instanceof ItemScene) {
            this.sceneType = SceneType.Item;
        } else if (scene instanceof NothingHappensScene) {
            this.sceneType = SceneType.NothingHappens;
        } else if (scene instanceof TradeScene) {
            this.sceneType = SceneType.Trade;
        } else if (scene instanceof ChangeBiomeScene) {
            this.sceneType = SceneType.ChangeBiome;
        } else {
            this.sceneType = SceneType.None;
        }

        this.enemy = scene._enemy instanceof Enemy ? new EnemyJsonRequest(scene._enemy) : null;
        this.possibleScenes = scene._possibleScenes ?? null;
        this.rewardItem = scene._rewardItem instanceof Item ? new ItemJsonRequest(scene._rewardItem) : null;

        this.characterItemsOffer = scene._characterItemsOffer?.map(item =>
            item instanceof Item ? new ItemJsonRequest(item) : null
        ) ?? null;

        this.characterMoneyOffer = scene._characterMoneyOffer ?? null;

        this.merchantItemsOffer = scene._merchantItemsOffer?.map(item =>
            item instanceof Item ? new ItemJsonRequest(item) : null
        ) ?? null;

        this.merchantMoneyOffer = scene._merchantMoneyOffer ?? null;
    }

    toString() {
        return JSON.stringify(this, null, 2);
    }
}
