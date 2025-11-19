import { IGameRepository } from "../../domain/repositories/igame-repository";

export class GameHttpRepository extends IGameRepository {

    #gamesEndpoint;

    constructor(apiUrl) {
        super();
        if (!apiUrl) throw new TypeError("apiUrl is required");

        const baseUrl = apiUrl.endsWith("/") ? apiUrl.slice(0, -1) : apiUrl;
        this.#gamesEndpoint = `${baseUrl}/games`;
    }

    // GET :id
    async fetchById(id) {
        if (!id) throw new TypeError("id is required");

        const res = await fetch(`${this.#gamesEndpoint}/${id}`);

        if (!res.ok) {
            throw new Error(`Error fetching game ${id}`);
        }

        return await res.json();
    }

    // GET
    async fetchAll() {
        const res = await fetch(this.#gamesEndpoint);

        if (!res.ok) {
            throw new Error("Error fetching games");
        }

        return await res.json();
    }

    // POST
    async save(game) {
        if (!game) throw new TypeError("game is required");

        const res = await fetch(this.#gamesEndpoint, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(game),
        });

        if (!res.ok) {
            throw new Error("Error saving game");
        }

        return await res.json();
    }

    // DELETE :id
    async delete(id) {
        if (!id) throw new TypeError("id is required");

        const res = await fetch(`${this.#gamesEndpoint}/${id}`, {
            method: "DELETE",
        });

        if (!res.ok) {
            throw new Error(`Error deleting game ${id}`);
        }

        return await res.json();
    }

    // PUT :id
    async update(id, game) {
        if (!id) throw new TypeError("id is required");
        if (!game) throw new TypeError("game is required");

        const res = await fetch(`${this.#gamesEndpoint}/${id}`, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(game),
        });

        if (!res.ok) {
            throw new Error(`Error updating game ${id}`);
        }

        return await res.json();
    }
}
