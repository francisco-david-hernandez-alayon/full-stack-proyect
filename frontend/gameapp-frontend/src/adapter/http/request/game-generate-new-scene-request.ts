import type { GamePutJsonRequest } from "./game-put-json-request";

export class GameGenerateNewSceneRequest {
    idSceneSelected: string;
    id: string;
    game: GamePutJsonRequest;

    constructor(idSceneSelected: string, id: string, game: GamePutJsonRequest) {
        if (!idSceneSelected) throw new TypeError("idSceneSelected instance is required");

        if (!game) throw new TypeError("game instance is required");

        this.idSceneSelected = idSceneSelected;
        this.id = id;
        this.game = game;

    }

    toString(): string {
        return JSON.stringify(this, null, 2);
    }
}
