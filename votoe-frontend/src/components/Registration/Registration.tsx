import { Button, TextField } from "@material-ui/core";
import axios from "../../axios";
import React, { useState } from "react";
import "./Registration.scss";
import { useDispatch } from "react-redux";
import { login } from "../../store/actions";
import Header from "../Header";
import CopyrightIcon from "@material-ui/icons/Copyright";

function Registration() {
  const [email, setEmail] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const [showError, setShowError] = useState(false);

  const dispatch = useDispatch();

  const loginHandler = () => {
    const data = {
      Email: email,
      Password: password,
    };

    axios
      .post("/auth", data)
      .then((response) => {
        const dataForVote = {
          ...data,
          token: response.data.token,
        };
        dispatch(login(dataForVote));
      })
      .catch((error) => {
        console.log(error);
        setShowError(true);
      });
  };

  return (
    <div className="registration">
      <Header />
      <div className="registration_container">
        <div className="registration_content">
          <div className="registration_textfields">
            <TextField
              label="Email"
              variant="standard"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              style={{ width: "80%", marginBottom: 30 }}
            ></TextField>
            <TextField
              label="Password"
              variant="standard"
              type="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              style={{ width: "80%" }}
            ></TextField>
          </div>

          <Button
            onClick={loginHandler}
            style={{
              fontSize: "large",
              padding: 15,
              width: 100,
              marginTop: "50px",
              marginRight: "auto",
              marginLeft: "auto",
            }}
          >
            Send
          </Button>

          <div className="terms">
            <p>
              Votoe.hu 2021 <CopyrightIcon style={{ fontWeight: 100 }} />
            </p>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Registration;
