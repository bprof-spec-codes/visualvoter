import { Button, Radio } from "@material-ui/core";
import SendIcon from "@material-ui/icons/Send";
import React, { useState, useEffect } from "react";
import "./Vote.scss";
import axios from "../../axios";
import { useSelector } from "react-redux";
import "react-notifications-component/dist/theme.css";
import { store } from "react-notifications-component";
import { withStyles } from "@material-ui/core/styles";
import { RadioProps } from "@material-ui/core/Radio";

const StyledRadio = withStyles({
  root: {
    color: "#1d2a4d",
    "&$checked": {
      color: "#1d2a4d",
    },
  },
  checked: {},
})((props: RadioProps) => <Radio color="default" {...props} />);

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
  const [vote, setVote] = useState<string>("stay");

  useEffect(() => {
    console.log(vote);
  }, [vote]);

  const headers = {
    Authorization: "Bearer " + isLogged.user?.token,
  };

  const sendVoteHandler = () => {
    let voteNum = 2;

    if (vote === "no") {
      voteNum = 1;
    } else if (vote === "yes") {
      voteNum = 0;
    }

    axios
      .post("/onevote", { VoteID: voteID, Choice: voteNum }, { headers: headers })
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
            onScreen: true,
          },
        });
      })
      .catch((error) => {
        console.log(error);
        store.addNotification({
          title: "Hiba!",
          message:
            "Erre a szavazásra már adtál le szavazatot vagy nincs jogosultságod szavazni!",
          type: "danger",
          insert: "top",
          container: "top-right",
          animationIn: ["animate__animated", "animate__fadeIn"],
          animationOut: ["animate__animated", "animate__fadeOut"],
          dismiss: {
            duration: 5000,
            onScreen: true,
          },
        });
      });

    console.log(voteID, vote, headers);
  };

  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setVote((event.target as HTMLInputElement).value);
  };

  return (
    <div className="vote">
      <div className="vote_container">
        <div className="container_top">
          <h1>{voteName}</h1>
        </div>
        <div className="choose">
          <div className="choose_firstRow">
            <div className="choose_container">
              <div className="choose_option">
                <StyledRadio
                  checked={vote === "no"}
                  onChange={handleChange}
                  value="no"
                />
                <p>Nem</p>
              </div>
              <span></span>

              <div className="choose_option">
                <StyledRadio
                  checked={vote === "stay"}
                  onChange={handleChange}
                  value="stay"
                />
                <p>Tartózkodom</p>
              </div>
              <span></span>

              <div className="choose_option">
                <StyledRadio
                  checked={vote === "yes"}
                  onChange={handleChange}
                  value="yes"
                />
                <p>Igen</p>
              </div>
            </div>

            {/*
            <Button variant="contained" onClick={() => setVote(1)}>
              Nem
            </Button>
            <Button variant="contained" onClick={() => setVote(2)}>
              Tartózkodom
            </Button>
            <Button variant="contained" onClick={() => setVote(0)}>
              Igen
            </Button>
            */}
          </div>
          <div className="choose_secondRow">
            <Button
              onClick={() => sendVoteHandler()}
              endIcon={<SendIcon />}
              style={{ fontSize: "large", width: "100%", height: "100%" }}
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
