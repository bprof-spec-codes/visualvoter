import React, { useState, useEffect } from "react";
import "./VoteHere.scss";
import Vote from "./Vote";
import axios from "../../axios";
import { RouteComponentProps } from "react-router-dom";
import Header from "../Header";

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

type TParams = {
  voteID?: string;
};

const VoteHere = ({ match }: RouteComponentProps<TParams>) => {
  const [vote, setVote] = useState<VoteType>();

  useEffect(() => {
    axios
      .get(`/allvotes/${match.params.voteID}`)
      .then((res) => {
        const response = res.data;
        setVote(response);
        console.log(response);
      })
      .catch((error) => {
        console.log(error);
      });

      console.log(vote)
  },[]);

  return (
    <div className="voteHere">
      <Header />
      <div className="voteHere_container">
        <Vote 
        absentionVotes={vote?.absentionVotes}
        isClosed={vote?.isClosed}
        isFinished={vote?.isFinished}
        noVotes={vote?.noVotes}
        requiredRole={vote?.requiredRole}
        voteID={vote?.voteID}
        voteName={vote?.voteName}
        yesVotes={vote?.yesVotes}
        />
      </div>
    </div>
  );
};

export default VoteHere;
