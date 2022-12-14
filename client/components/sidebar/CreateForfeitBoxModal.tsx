import React from "react";
import Modal from "../modal/Modal";

type CreateForfeitboxModalProps = {
  showModal: boolean;
  onSubmit: () => void;
  close: () => void;
};

function CreateForfeitboxModal({
  close,
  showModal,
  onSubmit,
}: CreateForfeitboxModalProps) {
  return (
    <Modal
      close={close}
      header={"Create a new ForfeitBox"}
      showModal={showModal}
    >
      <div className="flex flex-col space-y-4">
        <input className="custom-input" placeholder="Enter name"></input>
        <button onClick={onSubmit} className=" hover:bg-green-200 custom-btn">
          Create ForfeitBox
        </button>
      </div>
    </Modal>
  );
}

export default CreateForfeitboxModal;
