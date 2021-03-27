import React, { useState, useEffect } from "react";
import "./VoteHere.scss";
import Vote from "./Vote";
import axios from "../../axios";

type VoteType = {
  absentionVotes: number;
  isClosed: number;
  isFinished: number;
  noVotes: number;
  requiredRole: string;
  voteID: number;
  voteName: string;
  yesVotes: number;
};

interface VoteProps {
  match: any;
}

const VoteHere: React.FC<VoteProps> = ({ match }) => {
  const [vote, setVote] = useState<VoteType>();

  useEffect(() => {
    axios
      .get(`/vote/${match.voteID}`)
      .then((res) => {
        const response = res.data;
        setVote(response);
        console.log(response);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  return (
    <div className="voteHere">
      <div className="voteHere_container">
        <Vote />
      </div>
    </div>
  );
};

export default VoteHere;
