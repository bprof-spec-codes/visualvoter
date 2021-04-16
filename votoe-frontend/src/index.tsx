import React from "react";
import ReactDOM from "react-dom";
import "./index.scss";
import App from "./App";

import {createStore } from 'redux';
import allReducers from './store/reducers';
import { Provider } from 'react-redux';
import ReactNotification from 'react-notifications-component';

const store=createStore(allReducers);

ReactDOM.render(
  <React.StrictMode>
    <Provider store={store}>
    <ReactNotification />
    <App />
    </Provider>
  </React.StrictMode>,
  document.getElementById("root")
);
