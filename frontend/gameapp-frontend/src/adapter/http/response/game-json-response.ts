import { Game } from "../../../domain/entities/game";
import { UserAction } from "../../../domain/enumerates/user-action";
import { WarriorCharacter } from "../../../domain/value-objects/characters/warrior-character";
import { SceneDescription } from "../../../domain/value-objects/scenes/scene-description";
import { SceneName } from "../../../domain/value-objects/scenes/scene-name";
import { CharacterType } from "../../../application/enumerates/character-type";
import { SceneJsonResponse } from "./scene-json-response";
import { ItemJsonResponse } from "./item-json-response";
import { EnemyJsonResponse } from "./enemy-json-response";
import type { Biome } from "../../../domain/enumerates/biome";
import type { GameStatus } from "../../../domain/enumerates/game-status";
import { FinalScene } from "../../../domain/entities/scenes/final-scene";
import type { GameDifficulty } from "../../../domain/enumerates/game-difficulty";
import { ThiefCharacter } from "../../../domain/value-objects/characters/thief-caracter";
import type { Character } from "../../../domain/value-objects/characters/character";

interface CharacterJson {
    type: CharacterType;
    currentHealthPoints: number;
    currentFoodPoints: number;
    currentMoney: number;
    inventoryList?: any[];

    // optional character atributes
    currentHits?: number;

}
interface FinalSceneJson {
    name: string;
    description: string;
    biome: Biome;
}

interface GameJson {
    id?: string;
    difficulty: GameDifficulty;
    character: CharacterJson;
    numberScenesToFinish: number;
    listCompletedScenes?: SceneJsonResponse[];
    listCurrentScenes?: SceneJsonResponse[];
    listCurrentUserActions?: UserAction[];
    finalScene: FinalSceneJson;
    status: GameStatus;
    currentEnemy?: EnemyJsonResponse;
}

export class GameJsonResponse {
    id?: string;
    difficulty: GameDifficulty;
    character: CharacterJson;
    numberScenesToFinish: number;
    listCompletedScenes: SceneJsonResponse[];
    listCurrentScenes: SceneJsonResponse[];
    listCurrentUserActions: UserAction[];
    finalScene: FinalSceneJson;
    status: GameStatus;
    currentEnemy: EnemyJsonResponse | null;

    constructor(GameJson: GameJson) {
        if (!GameJson) throw new TypeError("GameJson response is required");

        this.id = GameJson.id;
        this.difficulty = GameJson.difficulty;
        this.character = GameJson.character;
        this.numberScenesToFinish = GameJson.numberScenesToFinish;
        this.listCompletedScenes = GameJson.listCompletedScenes ?? [];
        this.listCurrentScenes = GameJson.listCurrentScenes ?? [];
        this.listCurrentUserActions = GameJson.listCurrentUserActions ?? [];
        this.finalScene = GameJson.finalScene;
        this.status = GameJson.status;
        this.currentEnemy = GameJson.currentEnemy ?? null;
    }

    toGame(): Game {
        let character: Character;

        switch (this.character.type) {
            case CharacterType.Warrior: {
                const inventory = this.character.inventoryList?.map(i => new ItemJsonResponse(i).toItem()) ?? [];
                character = new WarriorCharacter(
                    this.character.currentHealthPoints,
                    this.character.currentFoodPoints,
                    this.character.currentMoney,
                    inventory,
                    this.character.currentHits ?? 0
                );
                break;
            }
            case CharacterType.Thief: {
                const inventory = this.character.inventoryList?.map(i => new ItemJsonResponse(i).toItem()) ?? [];
                character = new ThiefCharacter(
                    this.character.currentHealthPoints,
                    this.character.currentFoodPoints,
                    this.character.currentMoney,
                    inventory,
                );
                break;
            }
            default:
                throw new TypeError(`Unknown character type received: '${this.character.type}'`);
        }

        const finalScene = new FinalScene(
            new SceneName(this.finalScene.name),
            new SceneDescription(this.finalScene.description),
            this.finalScene.biome
        );

        const currentScenes = this.listCurrentScenes.map(scene => new SceneJsonResponse(scene).toScene());
        const completedScenes = this.listCompletedScenes.map(scene => new SceneJsonResponse(scene).toScene());


        const currentEnemy = this.currentEnemy ? new EnemyJsonResponse(this.currentEnemy).toEnemy() : null;

        const userActions = this.listCurrentUserActions.map(a => {
            if (!Object.values(UserAction).includes(a)) {
                throw new TypeError(`Invalid UserAction: ${a}`);
            }
            return a;
        });

        return new Game(
            this.difficulty,
            character,
            this.numberScenesToFinish,
            finalScene,
            currentScenes,
            userActions,
            completedScenes,
            this.status,
            currentEnemy,
            this.id
        );
    }
}
