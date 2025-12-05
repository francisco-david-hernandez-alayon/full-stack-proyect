import { v4 as uuidv4, validate as uuidValidate } from 'uuid';
import { UserAction } from '../enumerates/user-action';
import { Character } from '../value-objects/characters/character';
import { Enemy } from './enemy';
import { NothingHappensScene } from './scenes/nothing-happens-scene';
import { Scene } from './scenes/scene';

export class Game {
    private _id: string;
    private _character: Character;
    private _numberScenesToFinish: number;
    private _finalScene: NothingHappensScene;
    private _listCurrentScenes: Scene[];
    private _listCurrentUserActions: UserAction[];
    private _listCompletedScenes: Scene[];
    private _currentEnemy: Enemy | null;

    constructor(
        character: Character,
        numberScenesToFinish: number,
        finalScene: NothingHappensScene,
        listCurrentScenes: Scene[] = [],
        listCurrentUserActions: UserAction[] = [],
        listCompletedScenes: Scene[] = [],
        currentEnemy: Enemy | null = null,
        id?: string
    ) {
        if (id) {
            if (!uuidValidate(id)) {
                throw new TypeError(`Invalid UUID: ${id}`);
            }
            this._id = id;
        } else {
            this._id = uuidv4();
        }

        this._character = character;
        this._numberScenesToFinish = numberScenesToFinish;
        this._finalScene = finalScene;
        this._listCurrentScenes = [...listCurrentScenes];
        this._listCompletedScenes = [...listCompletedScenes];
        this._listCurrentUserActions = [...listCurrentUserActions];
        this._currentEnemy = currentEnemy;
    }

    // Getters
    get id(): string { return this._id; }
    get character(): Character { return this._character; }
    get numberScenesToFinish(): number { return this._numberScenesToFinish; }
    get completedScenes(): Scene[] { return [...this._listCompletedScenes]; }
    get finalScene(): NothingHappensScene { return this._finalScene; }
    get currentScenes(): Scene[] { return [...this._listCurrentScenes]; }
    get currentUserActions(): UserAction[] { return [...this._listCurrentUserActions]; }
    get currentEnemy(): Enemy | null { return this._currentEnemy; }

    // Setters / inmutables
    setCharacter(newCharacter: Character): Game {
        return new Game(newCharacter, this._numberScenesToFinish, this._finalScene, this._listCurrentScenes, this._listCurrentUserActions, this._listCompletedScenes, this._currentEnemy, this._id);
    }

    setNumberScenesToFinish(newNumber: number): Game {
        return new Game(this._character, newNumber, this._finalScene, this._listCurrentScenes, this._listCurrentUserActions, this._listCompletedScenes, this._currentEnemy, this._id);
    }

    addCompletedScene(newScene: Scene): Game {
        return new Game(this._character, this._numberScenesToFinish, this._finalScene, this._listCurrentScenes, this._listCurrentUserActions, [...this._listCompletedScenes, newScene], this._currentEnemy, this._id);
    }

    removeLastCompletedScene(): Game {
        if (this._listCompletedScenes.length === 0) return this;
        return new Game(this._character, this._numberScenesToFinish, this._finalScene, this._listCurrentScenes, this._listCurrentUserActions, this._listCompletedScenes.slice(0, -1), this._currentEnemy, this._id);
    }

    setFinalScene(newFinalScene: NothingHappensScene): Game {
        return new Game(this._character, this._numberScenesToFinish, newFinalScene, this._listCurrentScenes, this._listCurrentUserActions, this._listCompletedScenes, this._currentEnemy, this._id);
    }

    setCurrentScenes(newList: Scene[]): Game {
        return new Game(this._character, this._numberScenesToFinish, this._finalScene, newList, this._listCurrentUserActions, this._listCompletedScenes, this._currentEnemy, this._id);
    }

    setCurrentUserActions(newListCurrentUserActions: UserAction[]): Game {
        return new Game(this._character, this._numberScenesToFinish, this._finalScene, this._listCurrentScenes, newListCurrentUserActions, this._listCompletedScenes, this._currentEnemy, this._id);
    }

    setCurrentEnemy(newCurrentEnemy: Enemy | null): Game {
        return new Game(this._character, this._numberScenesToFinish, this._finalScene, this._listCurrentScenes, this._listCurrentUserActions, this._listCompletedScenes, newCurrentEnemy, this._id);
    }

    updateGame(
        newCharacter: Character,
        newNumberScenesToFinish: number,
        newCompletedScenes: Scene[],
        newFinalScene: NothingHappensScene,
        newListCurrentUserActions: UserAction[],
        newListCurrentScenes: Scene[],
        newCurrentEnemy: Enemy | null
    ): Game {
        return new Game(newCharacter, newNumberScenesToFinish, newFinalScene, newListCurrentScenes, newListCurrentUserActions, newCompletedScenes, newCurrentEnemy, this._id);
    }

    toString(): string {
        const completedStr = this._listCompletedScenes.map(s => s.name.toString()).join(", ");
        const currentScenesStr = this._listCurrentScenes.map(s => s.name.toString()).join(", ");
        const currentUserActionsStr = this._listCurrentUserActions.join(", ");
        return `Game ${this._id}: Character=${this._character.name.toString()}, NumberScenesToFinish=${this._numberScenesToFinish}, ` +
            `CompletedScenes=[${completedStr}], FinalScene=${this._finalScene?.name.toString()}, CurrentScenes=[${currentScenesStr}], CurrentUserActions=[${currentUserActionsStr}], CurrentEnemy=${this._currentEnemy}`;
    }
}
