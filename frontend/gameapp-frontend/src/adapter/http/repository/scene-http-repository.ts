import { SceneType } from "../../../application/enumerates/scene-type";
import type { ISceneRepository } from "../../../application/repositories/iscene-repository";
import type { FinalScene } from "../../../domain/entities/scenes/final-scene";
import { NothingHappensScene } from "../../../domain/entities/scenes/nothing-happens-scene";
import { Scene } from "../../../domain/entities/scenes/scene";
import type { SceneName } from "../../../domain/value-objects/scenes/scene-name";
import { SceneJsonResponse } from "../response/scene-json-response";

export class SceneHttpRepository implements ISceneRepository {
    #scenesEndpoint: string;

    constructor() {
        const apiUrl = import.meta.env.VITE_BACKEND_API_URL;
        if (!apiUrl) throw new TypeError("VITE_BACKEND_API_URL is not defined");

        const baseUrl = apiUrl.endsWith("/") ? apiUrl.slice(0, -1) : apiUrl;
        this.#scenesEndpoint = `${baseUrl}/scene`;
    }

    // GET :id
    async fetchById(id: string): Promise<Scene> {
        if (!id) throw new TypeError("id is required");

        const res = await fetch(`${this.#scenesEndpoint}/id/${id}`);
        if (!res.ok) throw new Error(`Error fetching scene ${id}`);

        const json = await res.json();
        return new SceneJsonResponse(json).toScene();
    }

    // GET name/:name
    async fetchByName(name: SceneName): Promise<Scene> {
        if (!name) throw new TypeError("name is required");

        const res = await fetch(`${this.#scenesEndpoint}/name/${encodeURIComponent(name.name)}`);
        if (!res.ok) throw new Error(`Error fetching scene by name '${name}'`);

        const json = await res.json();
        return new SceneJsonResponse(json).toScene();
    }

    // GET all
    async fetchAll(): Promise<Scene[]> {
        const res = await fetch(this.#scenesEndpoint);
        if (!res.ok) throw new Error("Error fetching scenes");

        const json: any[] = await res.json();
        return json.map(s => new SceneJsonResponse(s).toScene());
    }

    // GET all final scenes
    async fetchAllFinalScenes(): Promise<FinalScene[]> {
        const res = await fetch(`${this.#scenesEndpoint}/final-scenes`);
        if (!res.ok) throw new Error("Error fetching final scenes");

        const json: any[] = await res.json();

        return json
            .filter(s => s.sceneType === SceneType.Final)  // all scenes must be final scenes
            .map(s => {
                const scene = new SceneJsonResponse(s).toScene();
                return scene as FinalScene;
            });
    }


    // POST
    async save(scene: Scene): Promise<Scene> {
        return Promise.resolve(scene);
    }

    // DELETE
    async delete(id: string): Promise<Scene> {
        return Promise.resolve(new NothingHappensScene(null as any, null as any, null as any, id));
    }

    // PUT / PATCH 
    async update(id: string, scene: Scene): Promise<Scene> {
        return Promise.resolve(scene);
    }
}
