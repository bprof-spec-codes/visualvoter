import CloseOutlinedIcon from "@material-ui/icons/CloseOutlined";
import axios from "../../axios";
import React, { useState, useEffect } from "react";
import Modal from "react-modal";
import "./Sidebar.scss";
import { IconButton } from "@material-ui/core";
import { Link } from "react-router-dom";
import { useSelector } from "react-redux";

type ActiveVote = {
  absentionVotes: number;
  isClosed: number;
  isFinished: number;
  noVotes: number;
  requiredRole: string;
  voteID: number;
  voteName: string;
  yesVotes: number;
};

Modal.setAppElement("#root");
function Sidebar() {
  const [modalOpen, setModalOpen] = useState(false);
  const [activeVotes, setActiveVotes] = useState<ActiveVote[]>([]);

  const isLogged = useSelector((state: any) => state.isLogged);

  useEffect(() => {
    axios
      .get("/allvotes/active")
      .then((response) => {
        setActiveVotes(response.data);
        console.log(response.data);
      })
      .catch((error) => {
        console.log(error.message);
      });
  }, []);

  const renderActiveVotes = () => {
    let arr = [];
    for (let i = 0; i < activeVotes.length; i++) {
      arr.push(
        <Link
          to={`/vote/${activeVotes[i].voteID}`}
          style={{ textDecoration: "none" }}
        >
          <div
            onClick={() => setModalOpen(!modalOpen)}
            style={{
              display: "flex",
              justifyContent: "space-between",
              height: "80px",
              width: "100%",
              borderBottom: "1px solid rgba(0,0,0,0.2)",
              alignItems: "center",
              color: "black",
            }}
          >
            <p style={{ fontSize: "large", fontWeight: 500 }}>
              {activeVotes[i].voteName}
            </p>{" "}
            <IconButton>
              <CloseOutlinedIcon />
            </IconButton>{" "}
          </div>
        </Link>
      );
    }
    return arr;
  };

  return (
    <div className="sidebar">
      <div className="sidebar_container">
        <h1>Options</h1>
        {isLogged.user ? (
          <>
            <div className="sidebar_option">
              <Link
                to="/profile"
                style={{
                  fontSize: "20px",
                  fontWeight: 400,
                  marginLeft: "20px",
                  textDecoration: "none",
                  color: "black",
                }}
              >
                <p>Profile</p>
              </Link>
            </div>

            <div className="sidebar_option" onClick={() => setModalOpen(true)}>
              <p>Invites</p>
              <label>{activeVotes?.length}</label>
            </div>

            <div className="sidebar_option">
              <p>News</p>
            </div>
          </>
        ) : (
          <div className="sidebar_option">
            <p>Sign in first</p>
          </div>
        )}
      </div>

      <div className="sidebar_modal">
        <Modal
          isOpen={modalOpen}
          onRequestClose={() => setModalOpen(false)}
          style={{
            overlay: {
              backgroundColor: "rgba(1,1,1,0.6)",
              position: "fixed",
              margin: 0,
            },
            content: {
              width: 500,
              height: "auto",
              borderRadius: 20,
              position: "absolute",
              top: "10%",
              left: "36%",

              display: "flex",
              flexDirection: "column",
              padding: 30,
            },
          }}
        >
          <div
            className="modal_top"
            style={{
              display: "flex",
              justifyContent: "space-between",
              width: "100%",
            }}
          >
            <h1>Invites</h1>
            <div className="modal_close" onClick={() => setModalOpen(false)}>
              <IconButton>
                <CloseOutlinedIcon
                  fontSize="large"
                  style={{ cursor: "pointer" }}
                />
              </IconButton>
            </div>
          </div>
          <div
            className="modal_container"
            style={{ display: "flex", flexDirection: "column" }}
          >
            {renderActiveVotes()}
          </div>
        </Modal>
      </div>
    </div>
  );
}

export default Sidebar;
