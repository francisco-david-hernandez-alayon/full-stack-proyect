import { Scene } from "./scene";
import { SceneName } from "../../value-objects/scenes/scene-name";
import { SceneDescription } from "../../value-objects/scenes/scene-description";
import { Biome } from "../../enumerates/biome";
import { Enemy } from "../enemy";

export class EnemyScene extends Scene {
    protected _enemy: Enemy;

    constructor(
        name: SceneName,
        description: SceneDescription,
        biome: Biome,
        enemy: Enemy,
        id?: string
    ) {
        super(name, description, biome, id);
        this._enemy = enemy;
    }

    get enemy(): Enemy { return this._enemy; }

    setSceneName(newName: SceneName) {
        return new EnemyScene(newName, this._description, this._biome, this._enemy, this._id);
    }
    setSceneDescription(newDescription: SceneDescription) {
        return new EnemyScene(this._name, newDescription, this._biome, this._enemy, this._id);
    }
    setBiome(newBiome: Biome) {
        return new EnemyScene(this._name, this._description, newBiome, this._enemy, this._id);
    }
    setEnemy(newEnemy: Enemy) {
        return new EnemyScene(this._name, this._description, this._biome, newEnemy, this._id);
    }

    toString(): string {
        return `${this._name} Enemy Scene(${this._id}): Description=${this._description}, Biome=${this._biome}, Enemy=${this._enemy}`;
    }
}
