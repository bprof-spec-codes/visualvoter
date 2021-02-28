import React, { useState } from "react";
import "./Header.css";
import HomeOutlinedIcon from "@material-ui/icons/HomeOutlined";
import HowToVoteIcon from "@material-ui/icons/HowToVote";
import HowToVoteOutlinedIcon from "@material-ui/icons/HowToVoteOutlined";
import logo from "../assets/img/wv4y1e5r.png";
import Modal from "react-modal";
import CloseOutlinedIcon from "@material-ui/icons/CloseOutlined";
import { Button, TextField } from "@material-ui/core";
import axios from "../axios";
import { Link, useHistory } from "react-router-dom";

Modal.setAppElement("#root");
function Header() {
  const history = useHistory();

  const [modalOpen, setModalOpen] = useState(false);
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const loginHandler = (e) => {
    e.preventDefault();

    const data = {
      email: email,
      password: password,
    };
    axios
      .post("/posts", data)
      .then((response) => {
        if (response) {
          history.push("/");
        }
        //console.log(response);
      })
      .catch((error) => {
        //console.log(error.message);
      });
  };

  return (
    <div className="header">
      <div className="header_container">
        <div className="header_left">
          <Link to="/">
            <img style={{ width: 200 }} src={logo} alt="logo" />
          </Link>
        </div>

        <div className="header_middle">
          <div className="header_option header_option--active">
            <HomeOutlinedIcon fontSize="large" />
          </div>
          <div className="header_option">
            <HowToVoteOutlinedIcon fontSize="large" />
          </div>
          <div className="header_option">
            <HowToVoteOutlinedIcon fontSize="large" />
          </div>
        </div>

        <div className="header_modal">
          <Modal
            isOpen={modalOpen}
            onRequestClose={() => setModalOpen(false)}
            shouldCloseOnOverlayClick={false}
            style={{
              overlay: {
                backgroundColor: "rgba(1,1,1,0.6)",
                position: "fixed",
                marign: 0,
              },
              content: {
                width: 500,
                height: 350,
                borderRadius: 20,
                position: "absolute",
                top: "28%",
                left: "36%",

                display: "flex",
                flexDirection: "column",
                padding: 30,
                alignItems: "center",
              },
            }}
          >
            <div
              className="modal_top"
              style={{
                display: "flex",
                justifyContent: "space-between",
                width: "100%",
                marginBottom: 50,
              }}
            >
              <h1>Log In</h1>
              <div className="modal_close" onClick={() => setModalOpen(false)}>
                <CloseOutlinedIcon
                  fontSize="large"
                  style={{ cursor: "pointer" }}
                />
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
                  value={email}
                  onChange={(e) => {
                    setEmail(e.target.value);
                  }}
                  style={{ width: "80%", marginBottom: 30 }}
                ></TextField>
                <TextField
                  label="Password"
                  variant="standard"
                  type="password"
                  value={password}
                  onChange={(e) => {
                    setPassword(e.target.value);
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
            </div>
          </Modal>
        </div>

        <div className="header_right" onClick={() => setModalOpen(true)}>
          <p>Log In</p>
        </div>
      </div>
    </div>
  );
}

export default Header;
