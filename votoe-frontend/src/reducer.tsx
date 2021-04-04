import React, { useState, useEffect, useReducer } from 'react';
import axios from "./axios";

import { Button, TextField } from "@material-ui/core";
import { Link, useHistory } from "react-router-dom";

export const initialState: LoginState = {
  username: '',
  password: '',
  isLoading: false,
  error: '',
  isLoggedIn: false,
  variant: 'login',

  modalOpen: false,
  responseData: null,

  user: null,
};

interface LoginState {
  username: string;
  password: string;
  isLoading: boolean;
  error: string;
  isLoggedIn: boolean;
  variant: 'login' | 'forgetPassword';

  modalOpen: boolean;
  responseData: any;

 user:any
}

type LoginAction =
/*
  | { type: 'login' | 'success' | 'error' | 'logOut' }
  | { type: 'field'; fieldName: string; payload: string };
*/
  { type: 'setUsername', payload: string }
| { type: 'setPassword', payload: string }
| { type: 'login', payload: string }
| { type: 'success', payload: string }
| { type: 'error', payload: string }
| { type: 'logOut', payload: string}
| { type: 'field'; fieldName: string; payload: string };

function reducer(state: LoginState, action: LoginAction) {
  switch (action.type) {
    /*
    case 'field': {
      return {
        ...state,

        responseData: action.type,

        [action.fieldName]: action.payload,
      };
    }
    */
    case 'setUsername': 
      return {
        ...state,
        username: action.payload
      };
    case 'setPassword': 
      return {
        ...state,
        password: action.payload
      };


    case 'login': {
      return {
        ...state,

        user: action.payload,
        // username: action.payload,
      };
    }
    case 'success': {
      return {
        ...state,
        isLoggedIn: true,
        isLoading: false,
      };
    }
    /* 
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
    */

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
  const { username, password, isLoading, error, isLoggedIn, modalOpen, responseData, user } = state;

  const history=useHistory();


  useEffect(() => {
    console.log(initialState,state);
  },[username,password, user])

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
        dispatch({ type: "login",payload: "Login succesfully" });
      }).then(data=>{
        history.push("/");
      })
      .catch((error) => {
        console.log(error.message);
      });
  };

  const handleUsernameChange: React.ChangeEventHandler<HTMLInputElement> =
    (event) => {
      dispatch({
        type: 'setUsername',
        payload: event.target.value
      });
    };

  const handlePasswordChange: React.ChangeEventHandler<HTMLInputElement> =
    (event) => {
      dispatch({
        type: 'setPassword',
        payload: event.target.value
      });
    }

  return (
    <div>
      <TextField
        label="Email"
        variant="standard"
        helperText="Use your student email (JhonDoe@stud.uni-obuda.hu)"
        value={username}
        onChange={handleUsernameChange}

        /*
        onChange={(e) => {
          dispatch({
            type: "field",
            fieldName: "username",
            payload: e.currentTarget.value,
          });
        }}
        */

        style={{ width: "80%", marginBottom: 30 }}
      ></TextField>
      <TextField
        label="Password"
        variant="standard"
        type="password"
        value={password}

        onChange={handlePasswordChange}

        /*
        onChange={(e) => {
          dispatch({
            type: "field",
            fieldName: "password",
            payload: e.currentTarget.value,
          });
        }}
        */

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
