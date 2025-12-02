import { Item } from "../items/item.js";
import { Scene } from "./scene.js";

export class TradeScene extends Scene {
    constructor(name, description, biome, merchantMoneyToSpent, merchantItemsOffer, profitMerchantMargin, id = null) {
        super(name, description, biome, id);

        this.#validateItemList(merchantItemsOffer, "merchantItemsOffer");

        if (!Number.isInteger(merchantMoneyToSpent) || merchantMoneyToSpent < 0)
            throw new TypeError("merchantMoneyToSpent must be an integer >= 0");

        if (!Number.isInteger(profitMerchantMargin) || profitMerchantMargin < 0)
            throw new TypeError("profitMerchantMargin must be an integer >= 0");

        this._merchantMoneyToSpent = merchantMoneyToSpent;
        this._merchantItemsOffer = [...merchantItemsOffer];
        this._profitMerchantMargin = profitMerchantMargin;
    }

    #validateItemList(list, paramName) {
        if (!Array.isArray(list))
            throw new TypeError(`${paramName} must be an array`);
        for (const item of list) {
            if (!(item instanceof Item))
                throw new TypeError(`All elements of ${paramName} must be instances of Item`);
        }
    }

    // GETTERS
    get merchantMoneyToSpent() { return this._merchantMoneyToSpent; }
    get merchantItemsOffer() { return [...this._merchantItemsOffer]; }
    get profitMerchantMargin() { return this._profitMerchantMargin; }

    // SETTERS (devuelven nueva instancia)
    setSceneName(newName) {
        return new TradeScene(newName, this._description, this._biome, this._merchantMoneyToSpent, this._merchantItemsOffer, this._profitMerchantMargin, this._id);
    }

    setSceneDescription(newDescription) {
        return new TradeScene(this._name, newDescription, this._biome, this._merchantMoneyToSpent, this._merchantItemsOffer, this._profitMerchantMargin, this._id
        );
    }

    setBiome(newBiome) {
        return new TradeScene(this._name, this._description, newBiome, this._merchantMoneyToSpent, this._merchantItemsOffer, this._profitMerchantMargin, this._id);
    }

    setMerchantMoneyToSpent(newMoney) {
        return new TradeScene(this._name, this._description, this._biome, newMoney, this._merchantItemsOffer, this._profitMerchantMargin, this._id);
    }

    setMerchantItemsOffer(newItems) {
        return new TradeScene(this._name, this._description, this._biome, this._merchantMoneyToSpent, newItems, this._profitMerchantMargin, this._id);
    }

    setProfitMerchantMargin(newMargin) {
        return new TradeScene(this._name, this._description, this._biome, this._merchantMoneyToSpent, this._merchantItemsOffer, newMargin, this._id);
    }

    toString() {
        const merchantItems = this._merchantItemsOffer.map(i => i.toString()).join(", ");
        return (
            `TradeScene(${this._id}): ${this._name} - ${this._biome}\n` +
            `Merchant Money To Spent: ${this._merchantMoneyToSpent}\n` +
            `Profit Merchant Margin: ${this._profitMerchantMargin}\n` +
            `Merchant Items: [${merchantItems}]`
        );
    }
}
