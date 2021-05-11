import { Button, TextField } from "@material-ui/core";
import axios from "../../axios";
import React, { useState } from "react";
import "./Registration.scss";
import { useDispatch } from "react-redux";
import { login } from "../../store/actions";

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
        console.log(response);

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
      <div className="registration_container">
        <div className="registration_content">
          <TextField
            label="Email"
            variant="standard"
            // helperText="Use your student email (tesztx@stud.uni-obuda.hu)"
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

          <Button
            onClick={loginHandler}
            style={{ fontSize: "large", padding: 15, width: 100 }}
          >
            Send
          </Button>
        </div>
      </div>
    </div>
  );
}

export default Registration;
