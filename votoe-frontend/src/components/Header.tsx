import React, { useState, useEffect, useMemo } from "react";
import "./Header.scss";
import HomeOutlinedIcon from "@material-ui/icons/HomeOutlined";
import HowToVoteOutlinedIcon from "@material-ui/icons/HowToVoteOutlined";
import logo from "../assets/img/votoeLogo02.png";
import Modal from "react-modal";
import CloseOutlinedIcon from "@material-ui/icons/CloseOutlined";
import AccountBoxOutlinedIcon from "@material-ui/icons/AccountBoxOutlined";
import { Button, IconButton, TextField } from "@material-ui/core";
import { Link, useHistory } from "react-router-dom";
import axios from "../axios";

import { useSelector, useDispatch } from "react-redux";
import { increment, decrement, login } from "../store/actions";

Modal.setAppElement("#root");
function Header() {
  const counter = useSelector((state: any) => state.counter);
  const isLogged = useSelector((state: any) => state.isLogged);
  const dispatch = useDispatch();

  const [modalOpen, setModalOpen] = useState(false);
  const [email, setEmail] = useState<string>();
  const [password, setPassword] = useState<string>();

  const loginHandler = () => {
    const data = {
      Email: email,
      Password: password,
    };

    axios
      .put("/auth", data)
      .then((response) => {
        console.log(response);
        dispatch(login(data))
        console.log(isLogged)
      })
      .catch((error) => {
        console.log(error);
      })
      /*
      .finally(()=>{
      
          setModalOpen(!modalOpen);
        
      });
      */
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
          <div
            className="header_option header_option--active"
            style={{ marginLeft: "20%" }}
          >
            <IconButton>
              <Link to="/" style={{ textDecoration: "none", color: "black" }}>
                <HomeOutlinedIcon fontSize="large" />
              </Link>
            </IconButton>
          </div>

          <>
            <div className="header_option">
              <IconButton>
                <Link
                  to="/vote"
                  style={{ textDecoration: "none", color: "black" }}
                >
                  <HowToVoteOutlinedIcon fontSize="large" />
                </Link>
              </IconButton>
            </div>
            <div className="header_option" style={{ marginRight: "20%" }}>
              <IconButton>
                <Link
                  to="/dashboard"
                  style={{ textDecoration: "none", color: "black" }}
                >
                  <AccountBoxOutlinedIcon fontSize="large" />
                </Link>
              </IconButton>
            </div>
          </>
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
                margin: 0,
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
                <div
                  className="modal_close"
                  onClick={() => setModalOpen(false)}
                >
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
                  <div className="form_buttons" style={{ marginTop: 30 }}>
                    <Button
                      onClick={loginHandler}
                      style={{ fontSize: "large", padding: 15, width: 100 }}
                    >
                      Send
                    </Button>
                  </div>

                  <div></div>
                </div>
              </div>
            </div>
          </Modal>
        </div>

        {/*
        {user ? (
          <div className="header_right">
            <p>Sign Out</p>
          </div>
        ) : (
          */}
        {/* <Link to="/Login"> */}
        <div className="header_right" onClick={() => setModalOpen(true)}>
          <p>Sign In</p>
        </div>
        {/* </Link> */}
      </div>
    </div>
  );
}

export default Header;
