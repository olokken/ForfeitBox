import React from "react";
import Modal from "../modal/Modal";

type JoinForfeitboxModalProps = {
  showModal: boolean;
  onSubmit: () => void;
  close: () => void;
};

function JoinForfeitboxModal({
  close,
  showModal,
  onSubmit,
}: JoinForfeitboxModalProps) {
  return (
    <Modal close={close} header={"Join a ForfeitBox"} showModal={showModal}>
      <div className="flex flex-col space-y-4">
        <input className="custom-input" placeholder="Enter code"></input>
        <button onClick={onSubmit} className=" hover:bg-green-200 custom-btn">
          Join ForfeitBox
        </button>
      </div>
    </Modal>
  );
}

export default JoinForfeitboxModal;
