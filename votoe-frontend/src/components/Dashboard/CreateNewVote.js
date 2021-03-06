import {
    Button,
  FormControl,
  InputLabel,
  MenuItem,
  Select,
  TextField
} from "@material-ui/core";
import React, { useState } from "react";
import "./CreateNewVote.css";

function CreateNewVote() {
  const [voteType, setVoteType] = useState("");

  const createHandler=()=>{

  }

  return (
    <div className="createNewVote">
      <div className="createNewVote_container">
        <div className="container_top">
          <h1>Create New</h1>
        </div>
        <div className="container_content">
          <TextField label="Name" />
          <FormControl>
            <InputLabel>Ch</InputLabel>
            <Select
              native
              value={voteType}
              onChange={(e) => {
                setVoteType(e.target.value);
              }}
            >
              <option value=""></option>
              <option value="hokelnok">HÖK</option>
              <option value="hokelnok">Kancellária</option>
            </Select>
          </FormControl>
          <Button onClick={createHandler}>Create New</Button>
        </div>
      </div>
    </div>
  );
}

export default CreateNewVote;
