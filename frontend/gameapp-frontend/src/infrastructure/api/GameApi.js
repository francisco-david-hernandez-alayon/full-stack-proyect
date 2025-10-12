import axios from 'axios';

const API_URL = process.env.REACT_APP_BACKEND_API_URL;

export const GameApi = {
  async getAll() {
    const res = await axios.get(API_URL);
    return res.data;
  },
  async add(game) {
    const res = await axios.post(API_URL, game);
    return res.data;
  }
};
