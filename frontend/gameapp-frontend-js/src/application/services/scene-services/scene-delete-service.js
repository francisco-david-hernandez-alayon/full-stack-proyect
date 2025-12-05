import { ISceneDeleteUseCase } from "../../usecases/scene-use-cases/scene-delete-use-case";
import { ISceneRepository } from "../../repositories/iscene-repository";

export class SceneDeleteService extends ISceneDeleteUseCase {
    constructor(sceneRepository) {
        super();
        if (!(sceneRepository instanceof ISceneRepository)) {
            throw new TypeError("sceneRepository must be an instance of ISceneRepository");
        }
        this.sceneRepository = sceneRepository;
    }

    async deleteScene(id) {
        if (!id) throw new TypeError("id is required");

        const deletedScene = await this.sceneRepository.delete(id);
        return deletedScene;
    }
}
