import type { ISceneUpdateUseCase } from "../../usecases/scene-use-cases/scene-update-use-case";
import type { ISceneRepository } from "../../repositories/iscene-repository";
import { Scene } from "../../../domain/entities/scenes/scene";

export class SceneUpdateService implements ISceneUpdateUseCase {
    constructor(private sceneRepository: ISceneRepository) {}

    async updateScene(id: string, scene: Scene): Promise<Scene> {
        const updatedScene = await this.sceneRepository.update(id, scene);
        return updatedScene;
    }
}
