import { Item } from "../items/item.js";
import { Scene } from "./scene.js";

// ItemScene
export class ItemScene extends Scene {
    constructor(name, description, biome, item, id = null) {
        super(name, description, biome, id);
        if (!(item instanceof Item)) throw new TypeError("item must be Item");
        this._rewardItem = item;
    }

    // getter
    get rewardItem() { return this._rewardItem; }

    // setter
    setSceneName(newName) { return new ItemScene(newName, this._description, this._biome, this._rewardItem, this._id); }
    setSceneDescription(newDescription) { return new ItemScene(this._name, newDescription, this._biome, this._rewardItem, this._id); }
    setBiome(newBiome) { return new ItemScene(this._name, this._description, newBiome, this._rewardItem, this._id); }
    setItem(newItem) { return new ItemScene(this._name, this._description, this._biome, newItem, this._id); }

    toString() {
        return `${this._name} Item Scene(${this._id}): Description=${this._description}, Biome=${this._biome}, Reward Item=${this._rewardItem}`;
    }
}
