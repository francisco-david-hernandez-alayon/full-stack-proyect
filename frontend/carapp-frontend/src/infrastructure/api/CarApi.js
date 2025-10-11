import axios from 'axios';

const API_URL = process.env.REACT_APP_BACKEND_API_URL;

export const CarApi = {
  async getAll() {
    const res = await axios.get(API_URL);
    return res.data;
  },
  async add(car) {
    const res = await axios.post(API_URL, car);
    return res.data;
  }
};
