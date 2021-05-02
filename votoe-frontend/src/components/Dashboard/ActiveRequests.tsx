import axios from "../../axios";
import React, { useState, useEffect } from "react";
import "./ActiveRequests.scss";
import { useSelector } from "react-redux";
import CloseOutlinedIcon from "@material-ui/icons/CloseOutlined";
import CheckOutlinedIcon from "@material-ui/icons/CheckOutlined";
import { IconButton } from "@material-ui/core";

interface IRequest {
  oneRoleSwitchId: number;
  roleName: string;
  userName: string;
}

function ActiveRequests() {
  const [requests, setRequests] = useState([] as IRequest[]);
  const [isChecked, setIsChecked] = useState<boolean[]>([]);
  const [requestStatus, setRequestStatus] = useState<boolean[]>([]);

  const isLogged = useSelector((state: any) => state.isLogged);

  const headers = {
    Authorization: "Bearer " + isLogged.user?.token,
  };

  useEffect(() => {
    let newIsChecked = [...isChecked];
    let newRequestStatus = [...requestStatus];

    newIsChecked.push(false);
    newRequestStatus.push(false);

    setIsChecked(newIsChecked);
    setRequestStatus(newRequestStatus);

    console.log(isChecked);
    console.log(requestStatus);
  }, [requests]);

  useEffect(() => {
    console.log(isChecked);
    console.log(requestStatus);
  }, [isChecked, requestStatus]);

  useEffect(() => {
    axios
      .get("/Auth/roleRequests", { headers: headers })
      .then((res) => {
        console.log(res);
        setRequests(res.data);
      })
      .catch((err) => {
        console.error(err);
      });
  }, []);

  const requestAccept = (index: number) => {
    let newIsChecked = [...isChecked];
    let newRequestStatus = [...requestStatus];

    newIsChecked[index] = true;
    newRequestStatus[index] = true;

    setIsChecked(newIsChecked);
    setRequestStatus(newRequestStatus);
  };

  const requestReject = (index: number) => {
    let newIsChecked = [...isChecked];
    let newRequestStatus = [...requestStatus];

    newIsChecked[index] = true;
    newRequestStatus[index] = false;

    setIsChecked(newIsChecked);
    setRequestStatus(newRequestStatus);
  };

  return (
    <div className="activeRequests">
      <div className="activeRequests_container">
        <h3>Aktív kérelmek:</h3>

        {requests &&
          requests.map((q, qKey) => (
            <div
              key={qKey}
              className={`request ${
                isChecked[qKey] ? (requestStatus[qKey] ? "right" : "left") : ""
              }`}
            >
              {!isChecked[qKey] && (
                <IconButton>
                  <CheckOutlinedIcon onClick={() => requestAccept(qKey)} />
                </IconButton>
              )}
              <div className="request_content">
                <h5>{q.userName}</h5>
                <p>{q.roleName}</p>
              </div>
              {!isChecked[qKey] && (
                <IconButton>
                  <CloseOutlinedIcon onClick={() => requestReject(qKey)} />
                </IconButton>
              )}
            </div>
          ))}
      </div>
    </div>
  );
}

export default ActiveRequests;
