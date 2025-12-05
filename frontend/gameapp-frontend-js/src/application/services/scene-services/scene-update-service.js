import { ISceneUpdateUseCase } from "../../usecases/scene-use-cases/scene-update-use-case";
import { ISceneRepository } from "../../repositories/iscene-repository";

export class SceneUpdateService extends ISceneUpdateUseCase {
    constructor(sceneRepository) {
        super();
        if (!(sceneRepository instanceof ISceneRepository)) {
            throw new TypeError("sceneRepository must be an instance of ISceneRepository");
        }
        this.sceneRepository = sceneRepository;
    }

    async updateScene(id, scene) {
        if (!id) throw new TypeError("id is required");
        if (!scene) throw new TypeError("scene is required");

        const updatedScene = await this.sceneRepository.update(id, scene);
        return updatedScene;
    }
}
