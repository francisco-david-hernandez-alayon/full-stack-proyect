import { v4 as uuidv4, validate as uuidValidate } from 'uuid';
import { SceneName } from '../../value-objects/scenes/scene-name';
import { SceneDescription } from '../../value-objects/scenes/scene-description';
import { Biome } from '../../enumerates/biome';

// Abstract base class Scene
export abstract class Scene {
    protected _id: string;
    protected _name: SceneName;
    protected _description: SceneDescription;
    protected _biome: Biome;

    constructor(
        name: SceneName,
        description: SceneDescription,
        biome: Biome,
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
        this._name = name;
        this._description = description;
        this._biome = biome;
    }

    // getters
    get id(): string { return this._id; }
    get name(): SceneName { return this._name; }
    get description(): SceneDescription { return this._description; }
    get biome(): Biome { return this._biome; }
}
