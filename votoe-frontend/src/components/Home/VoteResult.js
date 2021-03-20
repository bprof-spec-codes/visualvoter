import React from "react";
import "./VoteResult.scss";
import HOKLogo from "../../assets/img/nikhok_logo.jpg";

function VoteResult({ key, title, yesVotes, noVotes, absentionVotes, isClosed, isFinished}) {
  return (
    <div className="voteResult">
      <div className="voteResult_container">
        <div className="voteResult_top">
          <div className="top_text">
            <h3>{title}</h3>
          </div>
        </div>

        <div className="voteResult_img">
          <img src={HOKLogo} alt="" />
        </div>

        <div className="voteResult_result">
          
        </div>
      </div>
    </div>
  );
}

export default VoteResult;
