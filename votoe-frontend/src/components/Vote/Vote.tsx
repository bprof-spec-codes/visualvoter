import { Button } from "@material-ui/core";
import DeleteIcon from "@material-ui/icons/Delete";
import SendIcon from "@material-ui/icons/Send";
import React, { useState, useEffect } from "react";
import "./Vote.scss";
import axios from "../../axios";
import { useSelector } from "react-redux";
import 'react-notifications-component/dist/theme.css';
import { store } from 'react-notifications-component';

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
  const isLogged = useSelector((state: any) => state.isLogged);
  const [vote, setVote] = useState<number>(2);

  useEffect(() => {
    console.log(vote);
  }, [vote]);

  const headers={
    'Authorization': 'Bearer ' + (isLogged.user?.token)
  }

  const sendVoteHandler = () => {
    axios
      .post("/onevote", { VoteID: voteID, Choice: vote },{ headers: headers })
      .then((response) => {
        console.log(response);
        store.addNotification({
          title: "Siker!",
          message: "Sikeresen leadtad a szavazatod!",
          type: "success",
          insert: "top",
          container: "top-right",
          animationIn: ["animate__animated", "animate__fadeIn"],
          animationOut: ["animate__animated", "animate__fadeOut"],
          dismiss: {
          duration: 5000,
          onScreen: true
        }
        });
      })
      .catch((error) => {
        console.log(error);
        store.addNotification({
          title: "Hiba!",
          message: "Erre a szavazásra már adtál le szavazatot vagy nincs jogosultságod szavazni!",
          type: "danger",
          insert: "top",
          container: "top-right",
          animationIn: ["animate__animated", "animate__fadeIn"],
          animationOut: ["animate__animated", "animate__fadeOut"],
          dismiss: {
          duration: 5000,
          onScreen: true
        }
        });
      });

      console.log(voteID,vote,headers);
  };

  return (
    <div className="vote">
      <div className="vote_container">
        <div className="container_top">
          <h1>{voteName}</h1>
        </div>
        <div className="choose">
          <h1>{vote}</h1>
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
