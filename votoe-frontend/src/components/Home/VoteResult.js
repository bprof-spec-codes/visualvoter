import React, { useState, useEffect, useMemo } from "react";
import "./VoteResult.scss";
import HOKLogo from "../../assets/img/nikhok_logo.jpg";

function VoteResult({
  key,
  title,
  yesVotes,
  noVotes,
  absentionVotes,
  isClosed,
  isFinished,
}) {
  const [chartData, setChartData] = useState([]);

  useEffect(() => {
    setChartData([yesVotes,noVotes,absentionVotes]);
  }, [])

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
          <div className="resultOption">
              <h3>Igen</h3>
              <span className="option_bar"><span className="option_votes" style={{width:`${yesVotes*100}%`,background:`${yesVotes>noVotes ? '#fab001' : '#1d2a4d'}`}}></span></span>
            </div>

            <div className="resultOption">
              <h3>Nem</h3>
              <span className="option_bar"><span className="option_votes" style={{width:`${noVotes*100+50}%`,background:`${yesVotes<noVotes ? '#fab001' : '#1d2a4d'}`}}></span></span>
            </div>

            <div className="resultOption">
              <h3>Tartózkodik</h3>
              <span className="option_bar"><span className="option_votes"></span></span>
            </div>
        </div>
      </div>
    </div>
  );
}

export default VoteResult;
