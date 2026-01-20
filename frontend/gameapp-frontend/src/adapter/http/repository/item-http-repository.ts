import type { IItemRepository } from "../../../application/repositories/iitem-repository";
import { AttackItem } from "../../../domain/entities/items/attack-item";
import { Item } from "../../../domain/entities/items/item";
import type { ItemName } from "../../../domain/value-objects/items/item-name";
import type { ItemType } from "../../../application/enumerates/item-type";
import { ItemJsonResponse } from "../response/item-json-response";
import { CriticalDamage } from "../../../domain/value-objects/enemies/critical-damage";
import type { ItemRarity } from "../../../domain/enumerates/item-rarity";

export class ItemHttpRepository implements IItemRepository {
    #itemsEndpoint: string;

    constructor() {
        const apiUrl = import.meta.env.VITE_BACKEND_API_URL;
        if (!apiUrl) throw new TypeError("VITE_BACKEND_API_URL is not defined");

        const baseUrl = apiUrl.endsWith("/") ? apiUrl.slice(0, -1) : apiUrl;
        this.#itemsEndpoint = `${baseUrl}/item`;
    }

    // GET :id
    async fetchById(id: string): Promise<Item> {
        if (!id) throw new TypeError("id is required");

        const res = await fetch(`${this.#itemsEndpoint}/id/${id}`);
        if (!res.ok) throw new Error(`Error fetching item ${id}`);

        const json = await res.json();
        return new ItemJsonResponse(json).toItem();
    }

    // GET name/:name
    async fetchByName(name: ItemName): Promise<Item> {
        if (!name) throw new TypeError("name is required");

        const res = await fetch(`${this.#itemsEndpoint}/name/${encodeURIComponent(name.name)}`);
        if (!res.ok) throw new Error(`Error fetching item by name '${name}'`);

        const json = await res.json();
        return new ItemJsonResponse(json).toItem();
    }

    // GET
    async fetchAll(): Promise<Item[]> {
        const res = await fetch(this.#itemsEndpoint);
        if (!res.ok) throw new Error("Error fetching items");

        const json: any[] = await res.json();
        return json.map(s => new ItemJsonResponse(s).toItem());
    }


    // GET filter?type=&rarity=
    async fetchAllByFilter(type?: ItemType | undefined, rarity?: ItemRarity | undefined): Promise<Item[]> {

        const params = new URLSearchParams();

        if (type) params.append("type", type);
        if (rarity) params.append("rarity", rarity);

        const res = await fetch(
            `${this.#itemsEndpoint}/filter?${params.toString()}`
        );

        if (!res.ok) {
            throw new Error(
                `Error fetching items by filter type='${type}', rarity='${rarity}'`
            );
        }

        const json: any[] = await res.json();
        return json.map(s => new ItemJsonResponse(s).toItem());
    }



    // POST
    async save(item: Item): Promise<Item> {
        return Promise.resolve(item);
    }

    // DELETE
    async delete(id: string): Promise<Item> {
        return Promise.resolve(new AttackItem(null as any, null as any, null as any, null as any, 0, 0, 0, 0, new CriticalDamage(0, 0), id));
    }

    // PUT / PATCH
    async update(id: string, item: Item): Promise<Item> {
        return Promise.resolve(item);
    }
}
