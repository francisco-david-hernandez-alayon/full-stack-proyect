import type { ISceneCreateUseCase } from "../../usecases/scene-use-cases/scene-create-use-case";
import type { ISceneRepository } from "../../repositories/iscene-repository";
import { Scene } from "../../../domain/entities/scenes/scene";

export class SceneCreateService implements ISceneCreateUseCase {
    constructor(private sceneRepository: ISceneRepository) {}

    async createScene(scene: Scene): Promise<Scene> {
        const savedScene = await this.sceneRepository.save(scene);
        return savedScene;
    }
}
