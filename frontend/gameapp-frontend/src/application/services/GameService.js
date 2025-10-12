import { GameApi } from "../../infrastructure/api/GameApi";

export const GameService = {
  async getGames() {
    return await GameApi.getAll();
  },
  async addGame(title) {
    return await GameApi.add({ title });
  }
};
