import { Button, Checkbox, TextField } from "@material-ui/core";
import axios from "../../axios";
import React, { useState } from "react";
import "./CreateNewVote.scss";
import { useSelector } from "react-redux";

function CreateNewVote() {
  const isLogged = useSelector((state: any) => state.isLogged);

  const [hokCheckBox, setHokCheckBox] = useState(false);
  const [chancelleryCheckBox, setChancelleryCheckBox] = useState(false);
  const [everyoneCheckBox, setEveryoneCheckBox] = useState(false);
  const [voteName, setVoteName] = useState("");
  const [step, setStep] = useState(1);
  const [requiredRole, setRequiredRole] = useState<any>();

  const headers = {
    Authorization: "Bearer " + isLogged.user?.token,
  };

  const firstCreateHandler = () => {
    let data = [];

    hokCheckBox && data.push("Hök");
    chancelleryCheckBox && data.push("Szenátus");
    everyoneCheckBox && data.push("Hallgató");
    axios
      .post("/auth/createRoleForVote", data)
      .then((response) => {
        console.log(response);
        const res = response.data;
        setRequiredRole(res);
        setStep(step + 1);
      })
      .catch((error) => {
        console.log(error.message);
      });
  };

  const createHandler = () => {
    const data = {
      VoteName: voteName,
      RequiredRole: requiredRole,
    };
    axios
      .post("/allvotes", data, { headers: headers })
      .then((response) => {
        console.log(response.data);
      })
      .catch((error) => {
        console.log(error.message);
      });
  };

  switch (step) {
    default:
    case 1:
      return (
        <div className="createNewVote">
          <div className="createNewVote_container">
            <div className="container_top">
              <h1>Create New</h1>
            </div>
            <div className="container_content">
              <div className="checkbox_item">
                <Checkbox
                  checked={hokCheckBox}
                  color="primary"
                  inputProps={{ "aria-label": "secondary checkbox" }}
                  onChange={() => setHokCheckBox(!hokCheckBox)}
                />
                <p>Hök</p>
              </div>

              <div className="checkbox_item">
                <Checkbox
                  checked={chancelleryCheckBox}
                  color="primary"
                  inputProps={{ "aria-label": "secondary checkbox" }}
                  onChange={() => setChancelleryCheckBox(!chancelleryCheckBox)}
                />
                <p>Szenátus</p>
              </div>

              <div className="checkbox_item">
                <Checkbox
                  checked={everyoneCheckBox}
                  color="primary"
                  inputProps={{ "aria-label": "secondary checkbox" }}
                  onChange={() => setEveryoneCheckBox(!everyoneCheckBox)}
                />
                <p>Hallgató</p>
              </div>

              <div className="create_button">
                <Button
                  onClick={firstCreateHandler}
                  style={{
                    fontSize: "large",
                    width: "100%",
                    marginTop: "10vh",
                  }}
                >
                  Next
                </Button>
              </div>
            </div>
          </div>
        </div>
      );
    case 2:
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
                  value={voteName}
                  onChange={(e) => {
                    setVoteName(e.target.value);
                  }}
                  style={{ width: "80%", marginBottom: "20px" }}
                />
              </div>
              <div className="create_button">
                <Button onClick={createHandler} style={{ fontSize: "large" }}>
                  Create
                </Button>
              </div>
            </div>
          </div>
        </div>
      );
  }

  /*
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
              checked={hokCheckBox}
              color="primary"
              inputProps={{ "aria-label": "secondary checkbox" }}
              onChange={() => setHokCheckBox(!hokCheckBox)}
            />
            <p>Hök</p>
          </div>

          <div className="checkbox_item">
            <Checkbox
              checked={chancelleryCheckBox}
              color="primary"
              inputProps={{ "aria-label": "secondary checkbox" }}
              onChange={() => setChancelleryCheckBox(!chancelleryCheckBox)}
            />
            <p>Szenátus</p>
          </div>

          <div className="checkbox_item">
            <Checkbox
              checked={everyoneCheckBox}
              color="primary"
              inputProps={{ "aria-label": "secondary checkbox" }}
              onChange={() => setEveryoneCheckBox(!everyoneCheckBox)}
            />
            <p>Hallgató</p>
          </div>

          <div className="create_button">
            <Button style={{ fontSize: "large" }}>Create New</Button>
          </div>
        </div>
      </div>
    </div>
  );
  */
}

export default CreateNewVote;
