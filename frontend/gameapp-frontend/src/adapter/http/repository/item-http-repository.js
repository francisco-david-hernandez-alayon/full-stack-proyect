import { IItemRepository } from "../../../application/repositories/iitem-repository";
import { ItemJsonResponse } from "../response/item-json-response";

export class ItemHttpRepository extends IItemRepository {

    #itemsEndpoint;

    constructor() {
        super();
        const apiUrl = import.meta.env.VITE_BACKEND_API_URL;
        if (!apiUrl) throw new TypeError("REACT_APP_BACKEND_API_URL is not defined");

        const baseUrl = apiUrl.endsWith("/") ? apiUrl.slice(0, -1) : apiUrl;
        this.#itemsEndpoint = `${baseUrl}/item`;
    }

    // GET :id
    async fetchById(id) {
        if (!id) throw new TypeError("id is required");

        const res = await fetch(`${this.#itemsEndpoint}/${id}`);
        if (!res.ok) throw new Error(`Error fetching item ${id}`);

        const json = await res.json();
        return new ItemJsonResponse(json).toItem();
    }

    // GET name/:name
    async fetchByName(name) {
        if (!name) throw new TypeError("name is required");

        const res = await fetch(`${this.#itemsEndpoint}/name/${encodeURIComponent(name)}`);
        if (!res.ok) throw new Error(`Error fetching item by name '${name}'`);

        const json = await res.json();
        return new ItemJsonResponse(json).toItem();
    }

    // GET
    async fetchAll() {
        const res = await fetch(this.#itemsEndpoint);
        if (!res.ok) throw new Error("Error fetching items");

        const json = await res.json();
        return json.map(s => new ItemJsonResponse(s).toItem());
    }

}
