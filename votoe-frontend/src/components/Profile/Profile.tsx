import React, { useState, useEffect } from "react";
import { useSelector } from "react-redux";
import "./Profile.scss";
import Avatar from "react-avatar";
import HokLogo from "../../assets/img/nikhok_logo.jpg";
import Header from "../Header";
import {
    Button,
  FormControl,
  FormHelperText,
  InputLabel,
  MenuItem,
  Select,
} from "@material-ui/core";

function Profile() {
  const [role, setRole] = useState("");

  const isLogged = useSelector((state: any) => state.isLogged);
  useEffect(() => {
    console.log(isLogged);
  }, []);

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
            src={HokLogo}
            size="500"
            name={isLogged.user?.Email}
          />
          <h2>{isLogged.user?.Email} Igen</h2>
        </div>

        <div className="profile_right">
          {isLogged.user?.Email ? (
            <h1>{isLogged.user.Email}</h1>
          ) : (
            <h1>Kérjük jelentkezz be!</h1>
          )}

          <h3>Ha nem megfelelő a jelenlegi role-od igényelj másikat!</h3>
          <FormControl>
            <InputLabel id="demo-simple-select-helper-label">{role}</InputLabel>
            <Select
              labelId="demo-simple-select-helper-label"
              id="demo-simple-select-helper"
              value={role}
              onChange={handleChange}
            >
              <MenuItem value="hallgato">Hallgató</MenuItem>
              <MenuItem value="tanár">Tanár</MenuItem>
            </Select>
            <FormHelperText>
              Válasz egy role-t és ha adminjaink megerősítik megkapod!
            </FormHelperText>
            <Button>Küldés</Button>
          </FormControl>
        </div>
      </div>
    </div>
  );
}

export default Profile;
