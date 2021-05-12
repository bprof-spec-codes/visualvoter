import React from "react";
import Header from "../Header";
import Right from "../Home/Right.";
import ActiveRequests from "./ActiveRequests";
import CreateNewVote from "./CreateNewVote";
import "./Dashboard.scss";

function Dashboard() {
  return (
    <div className="dashboard">
      <Header />
      <div className="dashboard_container">
        <div className="dashboard_left">
          <ActiveRequests />
        </div>
        <div className="dashboard_middle">
          <CreateNewVote />
        </div>
          <Right />
      </div>
    </div>
  );
}

export default Dashboard;
