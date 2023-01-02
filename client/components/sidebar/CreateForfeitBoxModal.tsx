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
      feite ekle gris
      <button onClick={onSubmit} className="custom-btn">
        Create ForfeitBox
      </button>
    </Modal>
  );
}

export default CreateForfeitboxModal;
