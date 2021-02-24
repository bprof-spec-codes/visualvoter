import React from "react";
import "./Sidebar.css";

function Sidebar() {
  return (
    <div className="sidebar">
      <div className="sidebar_container">
        <h1>Options</h1>
        <div className="sidebar_option">
          <p>Profile</p>
        </div>

        <div className="sidebar_option">
          <p>Invites</p>
          <label>0</label>
        </div>

        <div className="sidebar_option">
          <p>News</p>
        </div>
      </div>
    </div>
  );
}

export default Sidebar;
