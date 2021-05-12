import axios from "../../axios";
import React, { useState, useEffect } from "react";
import "./ActiveRequests.scss";
import { useSelector } from "react-redux";
import CloseOutlinedIcon from "@material-ui/icons/CloseOutlined";
import CheckOutlinedIcon from "@material-ui/icons/CheckOutlined";
import { IconButton } from "@material-ui/core";

interface IRequest {
  oneRoleSwitchID: number;
  roleName: string;
  userName: string;
}

function ActiveRequests() {
  const [requests, setRequests] = useState([] as IRequest[]);
  const [isChecked, setIsChecked] = useState<boolean[]>([]);
  const [requestStatus, setRequestStatus] = useState<boolean[]>([]);

  const isLogged = useSelector((state: any) => state.isLogged);

  useEffect(() => {
    let newIsChecked = [...isChecked];
    let newRequestStatus = [...requestStatus];

    newIsChecked.push(false);
    newRequestStatus.push(false);

    setIsChecked(newIsChecked);
    setRequestStatus(newRequestStatus);
  }, [requests]);

  useEffect(() => {
    axios
      .get("/Auth/roleRequests", { headers: headers })
      .then((res) => {
        setRequests(res.data);
      })
      .catch((err) => {
        console.error(err);
      });
  }, []);

  const headers = {
    Authorization: "Bearer " + isLogged.user?.token,
  };

  const requestAccept = (index: number) => {
    axios
      .post(`/Auth/requestNewRole?roleSwitchID=${requests[index].oneRoleSwitchID}&choice=${requestStatus[index] ? 0 : 1}`, {}, { headers: headers })
      .then((res) => {
        let newIsChecked = [...isChecked];
        let newRequestStatus = [...requestStatus];

        newIsChecked[index] = true;
        newRequestStatus[index] = true;

        setIsChecked(newIsChecked);
        setRequestStatus(newRequestStatus);
      })
      .catch((err) => {
        console.log(err.message);
      });
  };

  const requestReject = (index: number) => {
    axios
      .post(`/Auth/requestNewRole?roleSwitchID=${requests[index].oneRoleSwitchID}&choice=${requestStatus[index] ? 0 : 1}`, {}, { headers: headers })
      .then((res) => {
        let newIsChecked = [...isChecked];
        let newRequestStatus = [...requestStatus];

        newIsChecked[index] = true;
        newRequestStatus[index] = false;

        setIsChecked(newIsChecked);
        setRequestStatus(newRequestStatus);
      })
      .catch((err) => {
        console.log(err.message);
      });
  };

  return (
    <div className="activeRequests">
      <div className="activeRequests_container">
        <h3>Aktív kérelmek:</h3>

        {requests &&
          requests.map((q, qKey) => (
            <div key={qKey} className="request">
              {!isChecked[qKey] ? (
                <>
                  <IconButton>
                    <CheckOutlinedIcon onClick={() => requestAccept(qKey)} />
                  </IconButton>

                  <div className="request_content">
                    <h5>{q.userName}</h5>
                    <p>{q.roleName}</p>
                  </div>

                  <IconButton>
                    <CloseOutlinedIcon onClick={() => requestReject(qKey)} />
                  </IconButton>
                </>
              ) : (
                <div className="request_content">
                  <p>A kérelem elbírálásra került!</p>
                </div>
              )}
            </div>
          ))}
      </div>
    </div>
  );
}

export default ActiveRequests;
