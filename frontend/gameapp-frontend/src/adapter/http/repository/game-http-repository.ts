import type { IGameRepository } from "../../../application/repositories/igame-repository";
import { Game } from "../../../domain/entities/game";
import { GamePostJsonRequest } from "../request/game-post-json-request";
import { GamePutJsonRequest } from "../request/game-put-json-request";
import { GameJsonResponse } from "../response/game-json-response";

export class GameHttpRepository implements IGameRepository {
    #gamesEndpoint: string;

    constructor() {
        const apiUrl = import.meta.env.VITE_BACKEND_API_URL;
        if (!apiUrl) throw new TypeError("VITE_BACKEND_API_URL is not defined");

        const baseUrl = apiUrl.endsWith("/") ? apiUrl.slice(0, -1) : apiUrl;
        this.#gamesEndpoint = `${baseUrl}/game`;
    }

    async fetchById(id: string): Promise<Game> {
        if (!id) throw new TypeError("id is required");

        const res = await fetch(`${this.#gamesEndpoint}/${id}`);
        if (!res.ok) throw new Error(`Error fetching game ${id}`);

        const json = await res.json();
        return new GameJsonResponse(json).toGame();
    }

    async fetchAll(): Promise<Game[]> {
        const res = await fetch(this.#gamesEndpoint);
        if (!res.ok) throw new Error("Error fetching games");

        const json: any[] = await res.json();
        return json.map(g => new GameJsonResponse(g).toGame());
    }

    async save(game: Game): Promise<Game> {
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

    async delete(id: string): Promise<Game> {
        const res = await fetch(`${this.#gamesEndpoint}/${id}`, { method: "DELETE" });
        if (!res.ok) throw new Error(`Error deleting game ${id}`);

        const json = await res.json();
        return new GameJsonResponse(json).toGame();
    }

    async update(id: string, game: Game): Promise<Game> {
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
