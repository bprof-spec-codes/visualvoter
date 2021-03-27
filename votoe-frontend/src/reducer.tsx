import { useReducer } from "react";
import axios from "./axios";

import CloseOutlinedIcon from "@material-ui/icons/CloseOutlined";
import AccountBoxOutlinedIcon from "@material-ui/icons/AccountBoxOutlined";
import { Button, TextField, IconButton } from "@material-ui/core";

export interface LoginState {
  user: {
    email: string;
    password: string;
    login: {
      isLoading: boolean;
      error: string;
      isLoggedIn: boolean;
    };
  };
}

export const initialState: LoginState = {
  user: {
    email: "",
    password: "",
    login: {
      isLoading: false,
      error: "",
      isLoggedIn: false,
    },
  },
};

type LoginAction =
  | { type: "login" | "success" | "error" | "logOut" }
  | { type: "field"; fieldName: string; payload: string };

const reducer = (state: LoginState, action: LoginAction) => {
  switch (action.type) {
    case "field":
      return {
        ...state,
        [action.fieldName]: action.payload,
      };

    case "login": {
      return {
        ...state,
        error: "",
        isLoading: true,
      };
    }
    case "success": {
      return {
        ...state,
        isLoggedIn: true,
        isLoading: false,
      };
    }
    case "error": {
      return {
        ...state,
        error: "Incorrect username or password!",
        isLoggedIn: false,
        isLoading: false,
        username: "",
        password: "",
      };
    }
    case "logOut": {
      return {
        ...state,
        isLoggedIn: false,
      };
    }

    default:
      return state;
  }
};

// export default reducer;

export default function LoginUseReducer() {
  const [state, dispatch] = useReducer(reducer, initialState);
  const { user } = state;

  const loginHandler = (e: React.FormEvent) => {
    e.preventDefault();

    const data = {
      Email: user.email,
      Password: user.password,
    };
    axios
      .post("/users/login", data)
      .then((response) => {
        console.log(response);
        dispatch({ type: "login" });
      })
      .catch((error) => {
        console.log(error.message);
      });
  };

  return (
    <div>
      <div
        className="modal_top"
        style={{
          display: "flex",
          justifyContent: "space-between",
          width: "100%",
          marginBottom: 50,
        }}
      >
        <h1>Sign In</h1>
        <div className="modal_close" /*onClick={() => setModalOpen(false)}*/>
          <CloseOutlinedIcon fontSize="large" style={{ cursor: "pointer" }} />
        </div>
      </div>
      <div
        className="modal_form"
        style={{
          width: "100%",
          alignItems: "center",
          display: "flex",
          flexDirection: "column",
        }}
      >
        <div
          style={{
            display: "flex",
            flexDirection: "column",
            width: "100%",
          }}
        >
          <TextField
            label="Email"
            variant="standard"
            helperText="Use your student email (JhonDoe@stud.uni-obuda.hu)"
            value={user.email}
            onChange={(e) => {
              dispatch({
                type: 'field',
                fieldName: 'email',
                payload: e.currentTarget.value,
              })
            }}
            style={{ width: "80%", marginBottom: 30 }}
          ></TextField>
          <TextField
            label="Password"
            variant="standard"
            type="password"
            value={user.password}
            onChange={(e) => {
              dispatch({
                type: 'field',
                fieldName: 'password',
                payload: e.currentTarget.value,
              })
            }}
            style={{ width: "80%" }}
          ></TextField>
          <div className="form_buttons" style={{ marginTop: 30 }}>
            <Button
              onClick={loginHandler}
              style={{ fontSize: "large", padding: 15, width: 100 }}
            >
              {user.login.isLoading ? "Logging in..." : "Send"}
            </Button>
          </div>
        </div>
      </div>
    </div>
  );
}
