import React, { useState, useEffect, useMemo } from "react";
import "./Header.scss";
import HomeOutlinedIcon from "@material-ui/icons/HomeOutlined";
import HowToVoteOutlinedIcon from "@material-ui/icons/HowToVoteOutlined";
import logo from "../assets/img/votoeLogo02.png";
import Modal from "react-modal";
import CloseOutlinedIcon from "@material-ui/icons/CloseOutlined";
import AccountBoxOutlinedIcon from "@material-ui/icons/AccountBoxOutlined";
import { IconButton } from "@material-ui/core";
import { Link, useHistory } from "react-router-dom";
import LoginUseReducer, { initialState } from "../reducer";

Modal.setAppElement("#root");
function Header() {
  const [modalOpen, setModalOpen] = useState(initialState.modalOpen);
  const [userName, setUsername]=useState<string>();

  useEffect(()=>{
    setUsername(initialState.username);
    console.log(initialState.username);
  },[initialState.username])
  
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
          {initialState.username && 
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
        }
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
                ></div>

                {LoginUseReducer()}
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
        <div className="header_right"  onClick={() => setModalOpen(true)} >
          <p>Sign In</p>
        </div>
        {/* </Link> */}
      </div>
    </div>
  );
}

export default Header;
