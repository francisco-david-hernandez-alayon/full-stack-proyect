import { Scene } from "./scene";
import { SceneName } from "../../value-objects/scenes/scene-name";
import { SceneDescription } from "../../value-objects/scenes/scene-description";
import { Biome } from "../../enumerates/biome";
import { Item } from "../items/item";

export class TradeScene extends Scene {
    protected _merchantMoneyToSpent: number;
    protected _merchantItemsOffer: Item[];
    protected _profitMerchantMargin: number;

    constructor(
        name: SceneName,
        description: SceneDescription,
        biome: Biome,
        merchantMoneyToSpent: number,
        merchantItemsOffer: Item[],
        profitMerchantMargin: number,
        id?: string
    ) {
        super(name, description, biome, id);
        this._merchantMoneyToSpent = merchantMoneyToSpent;
        this._merchantItemsOffer = [...merchantItemsOffer];
        this._profitMerchantMargin = profitMerchantMargin;
    }

    get merchantMoneyToSpent(): number { return this._merchantMoneyToSpent; }
    get merchantItemsOffer(): Item[] { return [...this._merchantItemsOffer]; }
    get profitMerchantMargin(): number { return this._profitMerchantMargin; }

    setSceneName(newName: SceneName) {
        return new TradeScene(newName, this._description, this._biome, this._merchantMoneyToSpent, this._merchantItemsOffer, this._profitMerchantMargin, this._id);
    }
    setSceneDescription(newDescription: SceneDescription) {
        return new TradeScene(this._name, newDescription, this._biome, this._merchantMoneyToSpent, this._merchantItemsOffer, this._profitMerchantMargin, this._id);
    }
    setBiome(newBiome: Biome) {
        return new TradeScene(this._name, this._description, newBiome, this._merchantMoneyToSpent, this._merchantItemsOffer, this._profitMerchantMargin, this._id);
    }
    setMerchantMoneyToSpent(newMoney: number) {
        return new TradeScene(this._name, this._description, this._biome, newMoney, this._merchantItemsOffer, this._profitMerchantMargin, this._id);
    }
    setMerchantItemsOffer(newItems: Item[]) {
        return new TradeScene(this._name, this._description, this._biome, this._merchantMoneyToSpent, newItems, this._profitMerchantMargin, this._id);
    }
    setProfitMerchantMargin(newMargin: number) {
        return new TradeScene(this._name, this._description, this._biome, this._merchantMoneyToSpent, this._merchantItemsOffer, newMargin, this._id);
    }

    toString(): string {
        const merchantItems = this._merchantItemsOffer.map(i => i.toString()).join(", ");
        return `TradeScene(${this._id}): ${this._name} - ${this._biome}\n` +
               `Merchant Money To Spent: ${this._merchantMoneyToSpent}\n` +
               `Profit Merchant Margin: ${this._profitMerchantMargin}\n` +
               `Merchant Items: [${merchantItems}]`;
    }
}
