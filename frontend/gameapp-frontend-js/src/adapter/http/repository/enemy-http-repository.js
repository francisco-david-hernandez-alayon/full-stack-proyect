import { IEnemyRepository } from "../../../application/repositories/ienemy-repository";
import { EnemyJsonResponse } from "../response/enemy-json-response";

export class EnemyHttpRepository extends IEnemyRepository {

    #enemysEndpoint;

    constructor() {
        super();
        const apiUrl = import.meta.env.VITE_BACKEND_API_URL;
        if (!apiUrl) throw new TypeError("REACT_APP_BACKEND_API_URL is not defined");

        const baseUrl = apiUrl.endsWith("/") ? apiUrl.slice(0, -1) : apiUrl;
        this.#enemysEndpoint = `${baseUrl}/enemy`;
    }

    // GET :id
    async fetchById(id) {
        if (!id) throw new TypeError("id is required");

        const res = await fetch(`${this.#enemysEndpoint}/${id}`);
        if (!res.ok) throw new Error(`Error fetching enemy ${id}`);

        const json = await res.json();
        return new EnemyJsonResponse(json).toEnemy();
    }

    // GET name/:name
    async fetchByName(name) {
        if (!name) throw new TypeError("name is required");

        const res = await fetch(`${this.#enemysEndpoint}/name/${encodeURIComponent(name)}`);
        if (!res.ok) throw new Error(`Error fetching enemy by name '${name}'`);

        const json = await res.json();
        return new EnemyJsonResponse(json).toEnemy();
    }

    // GET
    async fetchAll() {
        const res = await fetch(this.#enemysEndpoint);
        if (!res.ok) throw new Error("Error fetching enemys");

        const json = await res.json();
        return json.map(s => new EnemyJsonResponse(s).toEnemy());
    }

}
