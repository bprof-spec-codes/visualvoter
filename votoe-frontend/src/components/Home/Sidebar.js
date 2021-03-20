import CloseOutlinedIcon from "@material-ui/icons/CloseOutlined";
import axios from "../../axios";
import React, { useState, useEffect } from "react";
import Modal from "react-modal";
// import { useStateValue } from "../../StateProvider";
import "./Sidebar.scss";
import { IconButton } from "@material-ui/core";

Modal.setAppElement("#root");
function Sidebar() {
  // const [{ user }, dispatch] = useStateValue();
  const [modalOpen, setModalOpen] = useState(false);
  const [activeVotes, setActiveVotes] = useState();

  useEffect(() => {
    axios
      .get("/allvotes/active")
      .then((response) => {
        const res = response.data;
        setActiveVotes(res);
        console.log(activeVotes);
      })
      .catch((error) => {
        console.log(error.message);
      });
  }, []);

  return (
    <div className="sidebar">
      <div className="sidebar_container">
        <h1>Options</h1>
        {
          <>
            <div className="sidebar_option">
              <p>Profile</p>
            </div>

            <div className="sidebar_option" onClick={() => setModalOpen(true)}>
              <p>Invites</p>
              <label>{activeVotes?.length}</label>
            </div>
          </>
        }

        <div className="sidebar_option">
          <p>News</p>
        </div>
      </div>

      <div className="sidebar_modal">
        <Modal
          isOpen={modalOpen}
          onRequestClose={() => setModalOpen(false)}
          style={{
            overlay: {
              backgroundColor: "rgba(1,1,1,0.6)",
              position: "fixed",
              marign: 0,
            },
            content: {
              width: 500,
              height: "auto",
              borderRadius: 20,
              position: "absolute",
              top: "10%",
              left: "36%",

              display: "flex",
              justifyContent: "space-between",
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
          <div className="modal_container">
            {activeVotes &&
              activeVotes.map((q, qKey) => {
                <p>{q.voteName}</p>;
              })}
          </div>
        </Modal>
      </div>
    </div>
  );
}

export default Sidebar;
