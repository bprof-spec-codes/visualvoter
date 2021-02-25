import { SportsRugbySharp } from "@material-ui/icons";
import CloseOutlinedIcon from "@material-ui/icons/CloseOutlined";
import React, { useState } from "react";
import Modal from "react-modal";
import "./Sidebar.css";

Modal.setAppElement("#root");
function Sidebar() {
  const [modalOpen, setModalOpen] = useState(false);

  return (
    <div className="sidebar">
      <div className="sidebar_container">
        <h1>Options</h1>
        <div className="sidebar_option">
          <p>Profile</p>
        </div>

        <div className="sidebar_option" onClick={() => setModalOpen(true)}>
          <p>Invites</p>
          <label>0</label>
        </div>

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
                width:'100%'
            }}
          >
            <h1>Invites</h1>
            <div className="modal_close" onClick={() => setModalOpen(false)}>
              <CloseOutlinedIcon fontSize="large" />
            </div>
          </div>
        </Modal>
      </div>
    </div>
  );
}

export default Sidebar;
