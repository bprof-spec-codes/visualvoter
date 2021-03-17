import React from "react";
import "./VoteResult.css";

function VoteResult({key,title}) {
  return (
    <div className="voteResult">
      <div className="voteResult_container">
        <div className="voteResult_top">
          <h3>{title}</h3>
          <label>date</label>
        </div>
        <div className="voteResult_result">
          <h1>Diagramm will be here</h1>
        </div>
      </div>
    </div>
  );
}

export default VoteResult;
