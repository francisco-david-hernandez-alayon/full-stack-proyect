import { IGameRepository } from "../../../application/repositories/igame-repository";
import { Game } from "../../../domain/entities/game";
import { GamePostJsonRequest } from "../request/game-post-json-request";
import { GamePutJsonRequest } from "../request/game-put-json-request";
import { GameJsonResponse } from "../response/game-json-response";

export class GameHttpRepository extends IGameRepository {

    #gamesEndpoint;

    constructor() {
        super();
        const apiUrl = import.meta.env.VITE_BACKEND_API_URL;
        if (!apiUrl) throw new TypeError("REACT_APP_BACKEND_API_URL is not defined");

        const baseUrl = apiUrl.endsWith("/") ? apiUrl.slice(0, -1) : apiUrl;
        this.#gamesEndpoint = `${baseUrl}/game`;
    }

    // GET :id
    async fetchById(id) {
        if (!id) throw new TypeError("id is required");

        const res = await fetch(`${this.#gamesEndpoint}/${id}`);
        if (!res.ok) throw new Error(`Error fetching game ${id}`);

        const json = await res.json();
        return new GameJsonResponse(json).toGame();
    }

    // GET
    async fetchAll() {
        const res = await fetch(this.#gamesEndpoint);
        if (!res.ok) throw new Error("Error fetching games");

        const json = await res.json();
        return json.map(g => new GameJsonResponse(g).toGame());
    }

    // POST
    async save(game) {
        // validate game
        if (!(game instanceof Game)) {
            throw new TypeError("game must be an instance of Game");
        }

        // create body request
        const bodyDto = new GamePostJsonRequest(game);

        const res = await fetch(this.#gamesEndpoint, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(bodyDto),
        });

        if (!res.ok) throw new Error("Error saving game");

        const json = await res.json();
        return new GameJsonResponse(json).toGame();
    }

    // DELETE :id
    async delete(id) {
        if (!id) throw new TypeError("id is required");

        const res = await fetch(`${this.#gamesEndpoint}/${id}`, { method: "DELETE" });
        if (!res.ok) throw new Error(`Error deleting game ${id}`);

        const json = await res.json();
        return new GameJsonResponse(json).toGame();
    }

    // PUT :id
    async update(id, game) {
        if (!id) throw new TypeError("id is required");
        if (!game) throw new TypeError("game is required");

        // create body request
        const bodyDto = new GamePutJsonRequest(game);

        const res = await fetch(`${this.#gamesEndpoint}/${id}`, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(bodyDto),
        });

        if (!res.ok) throw new Error(`Error updating game ${id}`);

        const json = await res.json();
        return new GameJsonResponse(json).toGame();
    }
}
