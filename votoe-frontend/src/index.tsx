import React from "react";
import ReactDOM from "react-dom";
import "./index.scss";
import App from "./App";
// import { StateProvider } from './StateProvider';
import reducer, {initialState} from './reducer';

ReactDOM.render(
  <React.StrictMode>

      <App />

  </React.StrictMode>,
  document.getElementById("root")
);
