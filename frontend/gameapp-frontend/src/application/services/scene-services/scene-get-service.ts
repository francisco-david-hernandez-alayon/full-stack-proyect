import type { ISceneGetUseCase } from "../../usecases/scene-use-cases/scene-get-use-case";
import type { ISceneRepository } from "../../repositories/iscene-repository";
import { Scene } from "../../../domain/entities/scenes/scene";
import type { SceneName } from "../../../domain/value-objects/scenes/scene-name";

export class SceneGetService implements ISceneGetUseCase {
    constructor(private sceneRepository: ISceneRepository) {}

    async getScene(id: string): Promise<Scene> {
        return await this.sceneRepository.fetchById(id);
    }

    async getSceneByName(name: SceneName): Promise<Scene> {
        return await this.sceneRepository.fetchByName(name);
    }

    async getAllScenes(): Promise<Scene[]> {
        return await this.sceneRepository.fetchAll();
    }
}
