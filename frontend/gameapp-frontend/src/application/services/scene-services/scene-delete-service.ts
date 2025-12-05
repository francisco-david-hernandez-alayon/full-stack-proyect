import type { ISceneDeleteUseCase } from "../../usecases/scene-use-cases/scene-delete-use-case";
import type { ISceneRepository } from "../../repositories/iscene-repository";
import { Scene } from "../../../domain/entities/scenes/scene";

export class SceneDeleteService implements ISceneDeleteUseCase {
    constructor(private sceneRepository: ISceneRepository) {}

    async deleteScene(id: string): Promise<Scene> {
        const deletedScene = await this.sceneRepository.delete(id);
        return deletedScene;
    }
}
