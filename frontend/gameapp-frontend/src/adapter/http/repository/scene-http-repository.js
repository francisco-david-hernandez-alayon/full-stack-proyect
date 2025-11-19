import { ISceneRepository } from "../../../application/repositories/iscene-repository";

export class SceneHttpRepository extends ISceneRepository {

    #scenesEndpoint; // endpoint privado

    constructor(apiUrl) {
        super();
        if (!apiUrl) throw new TypeError("apiUrl is required");

        const baseUrl = apiUrl.endsWith("/") ? apiUrl.slice(0, -1) : apiUrl;
        this.#scenesEndpoint = `${baseUrl}/scenes`;
    }

    // GET :id
    async fetchById(id) {
        if (!id) throw new TypeError("id is required");

        const res = await fetch(`${this.#scenesEndpoint}/${id}`);

        if (!res.ok) {
            throw new Error(`Error fetching scene ${id}`);
        }

        return await res.json();
    }

    // GET name/:name
    async fetchByName(name) {
        if (!name) throw new TypeError("name is required");

        const res = await fetch(`${this.#scenesEndpoint}/name/${encodeURIComponent(name)}`);

        if (!res.ok) {
            throw new Error(`Error fetching scene by name '${name}'`);
        }

        return await res.json();
    }

    // GET
    async fetchAll() {
        const res = await fetch(this.#scenesEndpoint);

        if (!res.ok) {
            throw new Error("Error fetching scenes");
        }

        return await res.json();
    }

    // POST
    async save(scene) {
        if (!scene) throw new TypeError("scene is required");

        const res = await fetch(this.#scenesEndpoint, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(scene),
        });

        if (!res.ok) {
            throw new Error("Error saving scene");
        }

        return await res.json();
    }

    // DELETE :id
    async delete(id) {
        if (!id) throw new TypeError("id is required");

        const res = await fetch(`${this.#scenesEndpoint}/${id}`, {
            method: "DELETE",
        });

        if (!res.ok) {
            throw new Error(`Error deleting scene ${id}`);
        }

        return await res.json();
    }

    // PUT :id
    async update(id, scene) {
        if (!id) throw new TypeError("id is required");
        if (!scene) throw new TypeError("scene is required");

        const res = await fetch(`${this.#scenesEndpoint}/${id}`, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(scene),
        });

        if (!res.ok) {
            throw new Error(`Error updating scene ${id}`);
        }

        return await res.json();
    }
}
