import React, { useState, useReducer } from 'react';
import axios from "./axios";

import { Button, TextField } from "@material-ui/core";

export const initialState: LoginState = {
  username: '',
  password: '',
  isLoading: false,
  error: '',
  isLoggedIn: false,
  variant: 'login',

  modalOpen: false,
};

interface LoginState {
  username: string;
  password: string;
  isLoading: boolean;
  error: string;
  isLoggedIn: boolean;
  variant: 'login' | 'forgetPassword';

  modalOpen:boolean;
}

type LoginAction =
  | { type: 'login' | 'success' | 'error' | 'logOut' }
  | { type: 'field'; fieldName: string; payload: string };

function reducer(state: LoginState, action: LoginAction) {
  switch (action.type) {
    case 'field': {
      return {
        ...state,
        [action.fieldName]: action.payload,
      };
    }
    case 'login': {
      return {
        ...state,
        isloggedIn: true,
        isLoading: true,
      };
    }
    case 'success': {
      return {
        ...state,
        isLoggedIn: true,
        isLoading: false,
      };
    }
    case 'error': {
      return {
        ...state,
        error: 'Incorrect username or password!',
        isLoggedIn: false,
        isLoading: false,
        username: '',
        password: '',
      };
    }
    case 'logOut': {
      return {
        ...state,
        isLoggedIn: false,
      };
    }
    default:
      return state;
  }
}


export default function LoginUseReducer() {
  const [state, dispatch] = useReducer(reducer, initialState);
  const { username, password, isLoading, error, isLoggedIn } = state;

  const [modal,setModal]=useState(initialState.modalOpen);

  const loginHandler = (e: React.FormEvent) => {
    e.preventDefault();

    const data = {
      Email: username,
      Password: password,
    };
    axios
      .put("/auth", data)
      .then((response) => {
        console.log(response);
        dispatch({ type: "login" });
      })
      .catch((error) => {
        console.log(error.message);
      });
      setModal(modal)
      console.log(initialState.isLoggedIn)
  };

  return (
    <div>
      <TextField
        label="Email"
        variant="standard"
        helperText="Use your student email (JhonDoe@stud.uni-obuda.hu)"
        value={username}
        onChange={(e) => {
          dispatch({
            type: "field",
            fieldName: "username",
            payload: e.currentTarget.value,
          });
        }}
        style={{ width: "80%", marginBottom: 30 }}
      ></TextField>
      <TextField
        label="Password"
        variant="standard"
        type="password"
        value={password}
        onChange={(e) => {
          dispatch({
            type: "field",
            fieldName: "password",
            payload: e.currentTarget.value,
          });
        }}
        style={{ width: "80%" }}
      ></TextField>
      <div className="form_buttons" style={{ marginTop: 30 }}> 
        <Button
          onClick={loginHandler}
          style={{ fontSize: "large", padding: 15, width: 100 }}
        >
          Send
        </Button>
      </div>
    </div>
  );
}
