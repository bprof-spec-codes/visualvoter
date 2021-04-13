import React from "react";
import "./VoteResult.scss";
import HOKLogo from "../../assets/img/nikhok_logo.jpg";
import CheckBoxOutlinedIcon from "@material-ui/icons/CheckBoxOutlined";
import ErrorOutlineIcon from "@material-ui/icons/ErrorOutline";

export interface IVoteResult {
  key?: any;
  title: string;
  yesVotes: number;
  noVotes: number;
  absentionVotes: number;
  isClosed: number;
  isFinished: number;
}

const VoteResult: React.FC<IVoteResult> = ({
  key,
  title,
  yesVotes,
  noVotes,
  absentionVotes,
  isClosed,
  isFinished,
}) => {
  return (
    <div className="voteResult">
      <div className="voteResult_container">
        <div className="voteResult_top">
          <div className="top_text">
            <h3>{title}</h3>
          </div>
        </div>

        <div className="voteResult_img">
          <img src={HOKLogo} alt="" loading="lazy" />
        </div>

        <div className="voteResult_result">
          <div className="resultOption">
            <h3>Igen</h3>
            <div style={{ display: "flex", textAlign: "center" }}>
              <span className="option_bar">
                <span
                  className="option_votes"
                  style={{
                    width: `${yesVotes * 10}%`,
                    maxWidth: "100%",
                    background: "#1d2a4d",
                  }}
                ></span>
              </span>
              <p
                style={{ paddingLeft: 20, fontSize: "large", fontWeight: 500 }}
              >
                {yesVotes}
              </p>
            </div>
          </div>

          <div className="resultOption">
            <h3>Nem</h3>
            <div style={{ display: "flex", textAlign: "center" }}>
              <span className="option_bar">
                <span
                  className="option_votes"
                  style={{
                    width: `${noVotes * 100}%`,
                    maxWidth: "100%",
                    background: "#1d2a4d",
                  }}
                ></span>
              </span>
              <p
                style={{ paddingLeft: 20, fontSize: "large", fontWeight: 500 }}
              >
                {noVotes}
              </p>
            </div>
          </div>

          <div className="resultOption">
            <h3>Tartózkodik</h3>
            <div style={{ display: "flex", textAlign: "center" }}>
              <span className="option_bar">
                <span
                  className="option_votes"
                  style={{
                    width: `${absentionVotes * 10}%`,
                    maxWidth: "100%",
                    background: "#1d2a4d",
                  }}
                ></span>
              </span>
              <p
                style={{ paddingLeft: 20, fontSize: "large", fontWeight: 500 }}
              >
                {absentionVotes}
              </p>
            </div>
          </div>
        </div>

        <div className="voteResult_data">
          {isClosed === 1 && (
            <div style={{ display: "flex" }}>
              <ErrorOutlineIcon />

              <p style={{ marginLeft: "5px" }}>Jelenleg nem lehet szavazni</p>
            </div>
          )}

          {isFinished === 1 && (
            <div style={{ display: "flex", marginLeft: "20px" }}>
              <CheckBoxOutlinedIcon />
              <p style={{ marginLeft: "5px" }}>A szavazást már lezárták</p>
            </div>
          )}
        </div>
      </div>
    </div>
  );
};

export default VoteResult;
