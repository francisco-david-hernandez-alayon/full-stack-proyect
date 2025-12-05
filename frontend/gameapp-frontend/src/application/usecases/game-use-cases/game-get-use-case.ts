import { Game } from '../../../domain/entities/game';

export interface IGameGetUseCase {
  getGame(id: string): Promise<Game>;
  getAllGames(): Promise<Game[]>;
}
