import React, { useState } from "react";
import { useSelector } from "react-redux";
import "./Profile.scss";
import Avatar from "react-avatar";
import OeLogo from "../../assets/img/oeLogo.png";
import Header from "../Header";
import {
    Button,
  FormControl,
  FormHelperText,
  MenuItem,
  Select,
} from "@material-ui/core";
import axios from "../../axios";
import { store } from "react-notifications-component";

function Profile() {
  const [role, setRole] = useState("");

  const isLogged = useSelector((state: any) => state.isLogged);

  const headers = {
    Authorization: "Bearer " + isLogged.user?.token,
  };

  const sendRequest=()=>{
    axios.get(`/Auth/requestNewRole?roleName=${role}`, { headers: headers })
    .then(response=>{
      store.addNotification({
        title: "Siker!",
        message: "Sikeresen leadtad a kérelmed az új role-ra!",
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
        message: "Hiba történt, kérjük keresd fel a supportot!",
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
    })
  }

  const handleChange = (event: React.ChangeEvent<{ value: unknown }>) => {
    setRole(event.target.value as string);
  };

  return (
    <div className="profile">
      <Header />
      <div className="profile_container">
        <div className="profile_left">
          <Avatar
            round={true}
            src={OeLogo}
            size="500"
            name={isLogged.user?.Email}
          />
          <h2>{isLogged.user?.Email}</h2>
        </div>

        <div className="profile_right">
          {isLogged.user?.Email ? (
            <h1>Szia {isLogged.user.Email}!</h1>
          ) : (
            <h1>Kérjük jelentkezz be!</h1>
          )}

          <h3>Ha nem megfelelő a jelenlegi role-od igényelj másikat!</h3>
          <FormControl style={{marginTop:"15px"}}>
            <Select
              labelId="demo-simple-select-helper-label"
              id="demo-simple-select-helper"
              value={role}
              onChange={handleChange}
            >
              <MenuItem value="Hallgató">Hallgató</MenuItem>
              <MenuItem value="Hök">Hök</MenuItem>
              <MenuItem value="Szenátus">Szenátus</MenuItem>
            </Select>
            <FormHelperText>
              Válasz egy role-t és ha adminjaink megerősítik megkapod!
            </FormHelperText>
            <Button onClick={sendRequest}>Küldés</Button>
          </FormControl>
        </div>
      </div>
    </div>
  );
}

export default Profile;
