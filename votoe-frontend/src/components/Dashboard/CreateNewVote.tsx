import { Button, Checkbox, TextField } from "@material-ui/core";
import axios from "../../axios";
import React, { useState } from "react";
import "./CreateNewVote.scss";
import { useSelector } from "react-redux";
import "react-notifications-component/dist/theme.css";
import { store } from "react-notifications-component";

function CreateNewVote() {
  const isLogged = useSelector((state: any) => state.isLogged);

  const [hokCheckBox, setHokCheckBox] = useState(false);
  const [chancelleryCheckBox, setChancelleryCheckBox] = useState(false);
  const [everyoneCheckBox, setEveryoneCheckBox] = useState(false);
  const [voteName, setVoteName] = useState<string>("");
  const [voteGroup, setVoteGroup] = useState<string>("");
  const [step, setStep] = useState(1);
  const [requiredRole, setRequiredRole] = useState<any>();

  const resetVote = () => {
    setHokCheckBox(false);
    setChancelleryCheckBox(false);
    setEveryoneCheckBox(false);
    setVoteName("");
    setStep(1);
  };

  const headers = {
    Authorization: "Bearer " + isLogged.user?.token,
  };

  const firstCreateHandler = () => {
    let data = [];

    hokCheckBox && data.push("Hök");
    chancelleryCheckBox && data.push("Szenátus");
    everyoneCheckBox && data.push("Hallgató");
    axios
      .post("/auth/createRoleForVote", data , { headers: headers})
      .then((response) => {
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
      VoteGroup: voteGroup,
      RequiredRole: requiredRole,
    };
    axios
      .post("/allvotes", data, { headers: headers })
      .then((response) => {
        store.addNotification({
          title: "Siker!",
          message: "Sikeresen létrehoztál egy szavazást!",
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
      .then(() => {
        resetVote();
      })
      .catch((error) => {
        console.log(error.message);
        store.addNotification({
          title: "Hiba!",
          message: "A szavazás létrehozása sikertelen!",
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
  };

  switch (step) {
    default:
    case 1:
      return (
        <div className="createNewVote">
          <div className="createNewVote_container">
            <div className="container_top">
              <h1>Hozz létre egy szavazást</h1>
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
                  Tovább
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
              <h1>Hozz létre egy szavazást</h1>
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

              <div className="container_textfield">
                <TextField
                  label="Szavazás csoportja(opcionális)"
                  value={voteGroup}
                  onChange={(e) => {
                    setVoteGroup(e.target.value);
                  }}
                  style={{ width: "80%", marginBottom: "20px" }}
                />
              </div>

              <div className="create_button">
                <Button onClick={createHandler} style={{ fontSize: "large" }}>
                  Létrehozás
                </Button>
              </div>
            </div>
          </div>
        </div>
      );
  }
}

export default CreateNewVote;
