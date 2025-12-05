import type { IEnemyRepository } from "../../../application/repositories/ienemy-repository";
import { Enemy } from "../../../domain/entities/enemy";
import type { EnemyName } from "../../../domain/value-objects/enemies/enemy-name";
import { EnemyJsonResponse } from "../response/enemy-json-response";

export class EnemyHttpRepository implements IEnemyRepository {
    #enemysEndpoint: string;

    constructor() {
        const apiUrl = import.meta.env.VITE_BACKEND_API_URL;
        if (!apiUrl) throw new TypeError("VITE_BACKEND_API_URL is not defined");

        const baseUrl = apiUrl.endsWith("/") ? apiUrl.slice(0, -1) : apiUrl;
        this.#enemysEndpoint = `${baseUrl}/enemy`;
    }

    // GET :id
    async fetchById(id: string): Promise<Enemy> {
        if (!id) throw new TypeError("id is required");

        const res = await fetch(`${this.#enemysEndpoint}/${id}`);
        if (!res.ok) throw new Error(`Error fetching enemy ${id}`);

        const json = await res.json();
        return new EnemyJsonResponse(json).toEnemy();
    }

    // GET name/:name
    async fetchByName(enemyName: EnemyName): Promise<Enemy> {
        if (!enemyName) throw new TypeError("enemyName is required");

        const res = await fetch(`${this.#enemysEndpoint}/name/${encodeURIComponent(enemyName.name)}`);
        if (!res.ok) throw new Error(`Error fetching enemy by name '${enemyName.name}'`);

        const json = await res.json();
        return new EnemyJsonResponse(json).toEnemy();
    }

    // GET
    async fetchAll(): Promise<Enemy[]> {
        const res = await fetch(this.#enemysEndpoint);
        if (!res.ok) throw new Error("Error fetching enemies");

        const json: any[] = await res.json();
        return json.map(s => new EnemyJsonResponse(s).toEnemy());
    }

    // POST
    async save(enemy: Enemy): Promise<Enemy> {
        return Promise.resolve(enemy);
    }

    // DELETE
    async delete(id: string): Promise<Enemy> {
        return Promise.resolve(new Enemy(null as any, 0, 0, 0, 0, id));
    }

    // PUT / PATCH
    async update(id: string, enemy: Enemy): Promise<Enemy> {
        return Promise.resolve(enemy);
    }
}
