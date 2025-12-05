import { Scene } from "./scene";
import { SceneName } from "../../value-objects/scenes/scene-name";
import { SceneDescription } from "../../value-objects/scenes/scene-description";
import { Biome } from "../../enumerates/biome";
import { Item } from "../items/item";

export class ItemScene extends Scene {
    protected _rewardItem: Item;

    constructor(
        name: SceneName,
        description: SceneDescription,
        biome: Biome,
        item: Item,
        id?: string
    ) {
        super(name, description, biome, id);
        this._rewardItem = item;
    }

    get rewardItem(): Item { return this._rewardItem; }

    setSceneName(newName: SceneName) {
        return new ItemScene(newName, this._description, this._biome, this._rewardItem, this._id);
    }
    setSceneDescription(newDescription: SceneDescription) {
        return new ItemScene(this._name, newDescription, this._biome, this._rewardItem, this._id);
    }
    setBiome(newBiome: Biome) {
        return new ItemScene(this._name, this._description, newBiome, this._rewardItem, this._id);
    }
    setItem(newItem: Item) {
        return new ItemScene(this._name, this._description, this._biome, newItem, this._id);
    }

    toString(): string {
        return `${this._name} Item Scene(${this._id}): Description=${this._description}, Biome=${this._biome}, Reward Item=${this._rewardItem}`;
    }
}
