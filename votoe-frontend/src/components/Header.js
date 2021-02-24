import React from "react";
import "./Header.css";
import HomeOutlinedIcon from "@material-ui/icons/HomeOutlined";
import HowToVoteIcon from "@material-ui/icons/HowToVote";
import HowToVoteOutlinedIcon from "@material-ui/icons/HowToVoteOutlined";
import logo from "../assets/img/wv4y1e5r.png";

function Header() {
  return (
    <div className="header">
      <div className="header_container">
        <div className="header_left">
          <img src={logo} alt="logo" />
        </div>

        <div className="header_middle">
          <div className="header_option">
            <HomeOutlinedIcon fontSize="large" />
          </div>
          <div className="header_option">
            <HowToVoteOutlinedIcon fontSize="large" />
          </div>
          <div className="header_option">
            <HowToVoteOutlinedIcon fontSize="large" />
          </div>
        </div>

        <div className="header_right">
          <p>Username</p>
        </div>
      </div>
    </div>
  );
}

export default Header;
