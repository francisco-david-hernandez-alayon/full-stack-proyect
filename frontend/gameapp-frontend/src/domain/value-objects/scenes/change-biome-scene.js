import { Scene } from "./scene";

// ChangeBiomeScene
export class ChangeBiomeScene extends Scene {
    constructor(name, description, biome, biomeToChange) {
        super(name, description, biome);
        if (!Object.values(Biome).includes(biomeToChange)) throw new TypeError("biomeToChange must be a valid Biome");
        this._biomeToChange = biomeToChange;
    }

    // getter
    get biomeToChange() { return this._biomeToChange; }

    // setter
    setSceneName(newName) { return new ChangeBiomeScene(newName, this._description, this._biome, this._biomeToChange); }
    setSceneDescription(newDescription) { return new ChangeBiomeScene(this._name, newDescription, this._biome, this._biomeToChange); }
    setBiome(newBiome) { return new ChangeBiomeScene(this._name, this._description, newBiome, this._biomeToChange); }


    setBiomeToChange(newBiomeToChange) {
        return new ChangeBiomeScene(this._name, this._description, this._biome, newBiomeToChange);
    }

    toString() {
        return `ChangeBiomeScene: ${this._name} - Description=${this._description}, CurrentBiome=${this._biome}, NewBiome=${this._biomeToChange}`;
    }
}