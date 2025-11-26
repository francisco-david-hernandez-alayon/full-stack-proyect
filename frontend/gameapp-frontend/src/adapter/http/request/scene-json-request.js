import { EnemyJsonRequest } from "./enemy-json-request.js";
import { ItemJsonRequest } from "./item-json-request.js";
import { Enemy } from "../../../domain/value-objects/enemies/enemy.js";
import { Item } from "../../../domain/value-objects/items/item.js";
import { Scene } from "../../../domain/entities/scenes/scene.js";
import { EnemyScene } from "../../../domain/entities/scenes/enemy-scene.js";
import { EnterDungeonScene } from "../../../domain/entities/scenes/enter-dungeon-scene.js";
import { ItemScene } from "../../../domain/entities/scenes/item-scene.js";
import { NothingHappensScene } from "../../../domain/entities/scenes/nothing-happens-scene.js";
import { TradeScene } from "../../../domain/entities/scenes/trade-scene.js";
import { ChangeBiomeScene } from "../../../domain/entities/scenes/change-biome-scene.js";
import { SceneType } from "../enumerates/scene-type.js";

export class SceneJsonRequest {
    constructor(scene) {
        if (!scene) throw new TypeError("scene is required");

        if (!(scene instanceof Scene)) {
            throw new TypeError("scene must be an instance of Scene");
        }

        this.id = scene.id;
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

        // OPTIONAL DATA
        if (scene instanceof EnemyScene) {
            if (!(scene.enemy instanceof Enemy)) {
                throw new TypeError("EnemyScene must contain an Enemy");
            }

            this.enemy = new EnemyJsonRequest(scene.enemy);
        }

        if (scene instanceof EnterDungeonScene) {
            if (!Array.isArray(scene.possibleScenes)) {
                throw new TypeError("EnterDungeonScene must have a list of possible scenes");
            }

            this.possibleScenes = scene._possibleScenes.map(s => new SceneJsonRequest(s));
        }

        if (scene instanceof ItemScene) {
            if (!(scene.rewardItem instanceof Item)) {
                throw new TypeError("ItemScene must contain an Item");
            }
            this.rewardItem = new ItemJsonRequest(scene.rewardItem);
        }

        if (scene instanceof TradeScene) {

            this.#validateListItems(scene.characterItemsOffer, "characterItemsOffer");
            this.characterItemsOffer = scene.characterItemsOffer.map(item =>
                item instanceof Item ? new ItemJsonRequest(item) : null
            );

            if (typeof scene.characterMoneyOffer !== "number" || !Number.isInteger(scene.characterMoneyOffer)) {
                throw new TypeError("characterMoneyOffer must be a number");
            }
            this.characterMoneyOffer = scene.characterMoneyOffer ?? null;

            this.#validateListItems(scene.merchantItemsOffer, "merchantItemsOffer");
            this.merchantItemsOffer = scene.merchantItemsOffer.map(item =>
                item instanceof Item ? new ItemJsonRequest(item) : null
            );

            if (typeof scene.merchantMoneyOffer !== "number" || !Number.isInteger(scene.merchantMoneyOffer)) {
                throw new TypeError("merchantMoneyOffer must be a number");
            }
            this.merchantMoneyOffer = scene.merchantMoneyOffer ?? null;
        }
    }

    #validateListItems(listItems, name) {
        if (!Array.isArray(listItems)) {
            throw new TypeError(name + "must be an array");
        }

        for (const item of listItems) {
            if (!(item instanceof Item)) {
                throw new TypeError(name + "must contain only Item instances");
            }
        }
    }

    toString() {
        return JSON.stringify(this, null, 2);
    }
}
