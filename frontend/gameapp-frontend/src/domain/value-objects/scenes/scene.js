import { SceneName } from './scene-name.js'
import { SceneDescription } from './scene-description.js'
import { Biome } from '../../enumerates/biome.js';

// Abstract base class Scene
export class Scene {
    constructor(name, description, biome) {
        if (!(name instanceof SceneName)) throw new TypeError("name must be SceneName");
        if (!(description instanceof SceneDescription)) throw new TypeError("description must be SceneDescription");
        if (!Object.values(Biome).includes(biome)) throw new TypeError("biome must be a valid Biome");

        this._name = name;
        this._description = description;
        this._biome = biome;
    }

    // getters
    get name() { return this._name; }
    get description() { return this._description; }
    get biome() { return this._biome; }
}