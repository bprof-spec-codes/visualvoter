import { Button, Icon } from "@material-ui/core";
import DeleteIcon from "@material-ui/icons/Delete";
import SendIcon from "@material-ui/icons/Send";
import React, { useState, useEffect } from "react";
import "./Vote.scss";
import axios from "../../axios";

interface VoteDetails {
  absentionVotes: number | undefined;
  isClosed: number | undefined;
  isFinished: number | undefined;
  noVotes: number | undefined;
  requiredRole: string | undefined;
  voteID: number | undefined;
  voteName: string | undefined;
  yesVotes: number | undefined;
}

/*
type VoteType = {
  VoteID: number;
  Choice: number;
};
*/

const Vote: React.FC<VoteDetails> = ({
  absentionVotes,
  isClosed,
  isFinished,
  noVotes,
  requiredRole,
  voteID,
  voteName,
  yesVotes,
}) => {
  const [vote, setVote] = useState<number>(2);

  useEffect(() => {
    console.log(vote);
  }, [vote]);

  const sendVoteHandler = () => {
    axios
      .post("/onevote", { VoteID: voteID, Choice: vote })
      .then((response) => {
        console.log(response);
      })
      .catch((error) => console.log(error));
  };

  return (
    <div className="vote">
      <div className="vote_container">
        <div className="container_top">
          <h1>{voteName}</h1>
        </div>
        <div className="choose">
          <div className="choose_firstRow">
            <Button variant="contained" onClick={() => setVote(1)}>
              Nem
            </Button>
            <Button variant="contained" onClick={() => setVote(2)}>
              Tartózkodom
            </Button>
            <Button variant="contained" onClick={() => setVote(0)}>
              Igen
            </Button>
          </div>
          <div className="choose_secondRow">
            <Button
              variant="contained"
              onClick={() => sendVoteHandler()}
              startIcon={<DeleteIcon />}
            >
              Küldés
            </Button>
            <Button
              variant="contained"
              onClick={() => sendVoteHandler()}
              endIcon={<SendIcon />}
            >
              Küldés
            </Button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Vote;
