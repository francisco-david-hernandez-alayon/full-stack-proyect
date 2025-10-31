import { Item } from "../items/item";
import { Scene } from "./scene";

export class TradeScene extends Scene {
    constructor(name, description, biome, characterItemsOffer = [], characterMoneyOffer = 0, merchantItemsOffer = [], merchantMoneyOffer = 0) {
        super(name, description, biome);

        this.#validateItemList(characterItemsOffer, "characterItemsOffer");
        this.#validateItemList(merchantItemsOffer, "merchantItemsOffer");

        this._characterItemsOffer = [...characterItemsOffer];
        this._characterMoneyOffer = characterMoneyOffer;
        this._merchantItemsOffer = [...merchantItemsOffer];
        this._merchantMoneyOffer = merchantMoneyOffer;
    }

    #validateItemList(list, paramName) {
        if (!Array.isArray(list)) throw new TypeError(`${paramName} must be an array`);
        for (const item of list) {
            if (!(item instanceof Item)) {
                throw new TypeError(`All elements of ${paramName} must be instances of Item or its subclasses`);
            }
        }
    }

    // getter
    get characterItemsOffer() { return [...this._characterItemsOffer]; }
    get characterMoneyOffer() { return this._characterMoneyOffer; }
    get merchantItemsOffer() { return [...this._merchantItemsOffer]; }
    get merchantMoneyOffer() { return this._merchantMoneyOffer; }

    // setter
    setSceneName(newName) { return new TradeScene(newName, this._description, this._biome, this._characterItemsOffer, this._characterMoneyOffer, this._merchantItemsOffer, this._merchantMoneyOffer); }
    setSceneDescription(newDescription) { return new TradeScene(this._name, newDescription, this._biome, this._characterItemsOffer, this._characterMoneyOffer, this._merchantItemsOffer, this._merchantMoneyOffer); }
    setBiome(newBiome) { return new TradeScene(this._name, this._description, newBiome, this._characterItemsOffer, this._characterMoneyOffer, this._merchantItemsOffer, this._merchantMoneyOffer); }

    setCharacterItemsOffer(newItems) {
        return new TradeScene(this._name, this._description, this._biome, newItems, this._characterMoneyOffer, this._merchantItemsOffer, this._merchantMoneyOffer);
    }
    setCharacterMoneyOffer(newMoney) { return new TradeScene(this._name, this._description, this._biome, this._characterItemsOffer, newMoney, this._merchantItemsOffer, this._merchantMoneyOffer); }
    setMerchantItemsOffer(newItems) {
        return new TradeScene(this._name, this._description, this._biome, this._characterItemsOffer, this._characterMoneyOffer, newItems, this._merchantMoneyOffer);
    }
    setMerchantMoneyOffer(newMoney) { return new TradeScene(this._name, this._description, this._biome, this._characterItemsOffer, this._characterMoneyOffer, this._merchantItemsOffer, newMoney); }

    toString() {
        const characterItems = this._characterItemsOffer.map(i => i.toString()).join(", ");
        const merchantItems = this._merchantItemsOffer.map(i => i.toString()).join(", ");
        return `TradeScene: ${this._name} - ${this._biome}\nCharacter Offer: Money=${this._characterMoneyOffer}, Items=[${characterItems}]\nMerchant Offer: Money=${this._merchantMoneyOffer}, Items=[${merchantItems}]`;
    }
}
