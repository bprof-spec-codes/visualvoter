import axios from "axios";

const instance = axios.create({
  baseURL: "https://api.votoe.hu",
});

export default instance;
