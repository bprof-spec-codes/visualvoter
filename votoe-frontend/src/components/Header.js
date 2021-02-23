import React from "react";
import "./Header.css";
import HomeIcon from "@material-ui/icons/Home";
import HowToVoteIcon from "@material-ui/icons/HowToVote";
import AddBoxIcon from "@material-ui/icons/AddBox";
import logo from '../assets/img/wv4y1e5r.png';

function Header() {
  return (
    <div className="header">
      <div className="header_left">
        <img src={logo} alt="logo" />
      </div>

      <div className="header_middle">
          <div className="header_option">
        <HomeIcon />
        </div>
        <div className="header_option">
        <HowToVoteIcon />
        </div>
        <div className="header_option">
        <AddBoxIcon />
        </div>
      </div>

      <div className="header_right">
        <p>Username</p>
      </div>
    </div>
  );
}

export default Header;
