import {
  Button,
  Checkbox,
  FormControl,
  InputLabel,
  Select,
  TextField,
} from "@material-ui/core";
import axios from "../../axios";
import React, { useState } from "react";
import "./CreateNewVote.scss";

function CreateNewVote() {
  const [voteType, setVoteType] = useState("");
  const [voteName, setVoteName] = useState("");

  const createHandler = () => {
    const data = {
      NewVote: {
        IsClosed: 0,
        VoteName: "KIspista hök elnöknek",
      },
      WhoCanVote: [1, 2, 3],
    };
    axios
      .post("/allvotes/create", data)
      .then((response) => {
        console.log(response.data);
      })
      .catch((error) => {
        console.log(error.message);
      });
  };

  return (
    <div className="createNewVote">
      <div className="createNewVote_container">
        <div className="container_top">
          <h1>Create New</h1>
        </div>
        <div className="container_content">
          <div className="container_textfield">
            <TextField
              label="A szavazás neve"
              style={{ width: "80%", marginBottom: "20px" }}
            />
          </div>

          <div className="checkbox_item">
            <Checkbox
              checked={false}
              color="primary"
              inputProps={{ "aria-label": "secondary checkbox" }}
            />
            <p>HÖK</p>
          </div>

          <div className="checkbox_item">
            <Checkbox
              checked={false}
              color="primary"
              inputProps={{ "aria-label": "secondary checkbox" }}
            />
            <p>Kancellária</p>
          </div>

          <div className="checkbox_item">
            <Checkbox
              checked={false}
              color="primary"
              inputProps={{ "aria-label": "secondary checkbox" }}
            />
            <p>Mindenki</p>
          </div>

          <div className="create_button">
            <Button onClick={createHandler} style={{ fontSize: "large" }}>
              Create New
            </Button>
          </div>
        </div>
      </div>
    </div>
  );
}

export default CreateNewVote;
