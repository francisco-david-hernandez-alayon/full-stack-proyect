import { ISceneGetUseCase } from "../../usecases/scene-use-cases/scene-get-use-case";
import { ISceneRepository } from "../../repositories/iscene-repository";

export class SceneGetService extends ISceneGetUseCase {
    constructor(sceneRepository) {
        super();
        if (!(sceneRepository instanceof ISceneRepository)) {
            throw new TypeError("sceneRepository must be an instance of ISceneRepository");
        }
        this.sceneRepository = sceneRepository;
    }

    async getScene(id) {
        if (!id) throw new TypeError("id is required");
        return await this.sceneRepository.fetchById(id);
    }

    async getSceneByName(name) {
        if (!name) throw new TypeError("name is required");
        return await this.sceneRepository.fetchByName(name);
    }

    async getAllScenes() {
        return await this.sceneRepository.fetchAll();
    }
}
