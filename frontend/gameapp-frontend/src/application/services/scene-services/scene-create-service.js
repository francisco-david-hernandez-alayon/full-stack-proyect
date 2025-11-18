import { ISceneCreateUseCase } from "../../usecases/scene-use-cases/scene-create-use-case";
import { ISceneRepository } from "../../repositories/iscene-repository";

export class SceneCreateService extends ISceneCreateUseCase {
    constructor(sceneRepository) {
        super();
        if (!(sceneRepository instanceof ISceneRepository)) {
            throw new TypeError("sceneRepository must be an instance of ISceneRepository");
        }
        this.sceneRepository = sceneRepository;
    }

    async createScene(scene) {
        if (!scene) throw new TypeError("scene is required");

        const savedScene = await this.sceneRepository.save(scene);
        return savedScene;
    }
}
