import { CarApi } from "../../infrastructure/api/CarApi";

export const CarService = {
  async getCars() {
    return await CarApi.getAll();
  },
  async addCar(brand, model) {
    return await CarApi.add({ brand, model });
  }
};
