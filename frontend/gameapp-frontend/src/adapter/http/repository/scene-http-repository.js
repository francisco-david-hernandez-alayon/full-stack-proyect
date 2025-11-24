import { ISceneRepository } from "../../../application/repositories/iscene-repository";
import { SceneJsonResponse } from "./mappers/scene-json-response";

export class SceneHttpRepository extends ISceneRepository {

    #scenesEndpoint;

    constructor(apiUrl) {
        super();
        if (!apiUrl) throw new TypeError("apiUrl is required");

        const baseUrl = apiUrl.endsWith("/") ? apiUrl.slice(0, -1) : apiUrl;
        this.#scenesEndpoint = `${baseUrl}/scene`;
    }

    // GET :id
    async fetchById(id) {
        if (!id) throw new TypeError("id is required");

        const res = await fetch(`${this.#scenesEndpoint}/${id}`);
        if (!res.ok) throw new Error(`Error fetching scene ${id}`);

        const json = await res.json();
        return new SceneJsonResponse(json);
    }

    // GET name/:name
    async fetchByName(name) {
        if (!name) throw new TypeError("name is required");

        const res = await fetch(`${this.#scenesEndpoint}/name/${encodeURIComponent(name)}`);
        if (!res.ok) throw new Error(`Error fetching scene by name '${name}'`);

        const json = await res.json();
        return new SceneJsonResponse(json);
    }

    // GET
    async fetchAll() {
        const res = await fetch(this.#scenesEndpoint);
        if (!res.ok) throw new Error("Error fetching scenes");

        const json = await res.json();
        return json.map(s => new SceneJsonResponse(s));
    }

    // // POST
    // async save(scene) {
    //     if (!scene) throw new TypeError("scene is required");

    //     const res = await fetch(this.#scenesEndpoint, {
    //         method: "POST",
    //         headers: { "Content-Type": "application/json" },
    //         body: JSON.stringify(scene),
    //     });

    //     if (!res.ok) throw new Error("Error saving scene");

    //     const json = await res.json();
    //     return new SceneJsonResponse(json);
    // }

    // // DELETE :id
    // async delete(id) {
    //     if (!id) throw new TypeError("id is required");

    //     const res = await fetch(`${this.#scenesEndpoint}/${id}`, {
    //         method: "DELETE",
    //     });

    //     if (!res.ok) throw new Error(`Error deleting scene ${id}`);

    //     const json = await res.json();
    //     return new SceneJsonResponse(json);
    // }

    // // PUT :id
    // async update(id, scene) {
    //     if (!id) throw new TypeError("id is required");
    //     if (!scene) throw new TypeError("scene is required");

    //     const res = await fetch(`${this.#scenesEndpoint}/${id}`, {
    //         method: "PUT",
    //         headers: { "Content-Type": "application/json" },
    //         body: JSON.stringify(scene),
    //     });

    //     if (!res.ok) throw new Error(`Error updating scene ${id}`);

    //     const json = await res.json();
    //     return new SceneJsonResponse(json);
    // }
}
