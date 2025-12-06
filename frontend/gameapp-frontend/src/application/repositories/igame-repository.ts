import { Game } from '../../domain/entities/game';

export interface IGameRepository {
    fetchById(id: string): Promise<Game>;
    fetchAll(): Promise<Game[]>;
    save(game: Game): Promise<Game>;
    delete(id: string): Promise<Game>;
    update(id: string, game: Game): Promise<Game>;
    generateNewScene(currentSceneSelectedId: string, game: Game): Promise<Game>;
}
