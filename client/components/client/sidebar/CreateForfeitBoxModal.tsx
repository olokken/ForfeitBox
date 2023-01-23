"use client";
import React, { useState } from "react";
import { MinimalBox } from "../../../data/models/Box";
import Modal from "../../server/modal/Modal";

type CreateForfeitboxModalProps = {
  showModal: boolean;
  onSubmit: (name: string) => Promise<MinimalBox>;
  close: () => void;
};

function CreateForfeitboxModal({
  close,
  showModal,
  onSubmit,
}: CreateForfeitboxModalProps) {
  const [name, setName] = useState<string>("");

  return (
    <Modal
      close={close}
      header={"Create a new ForfeitBox"}
      showModal={showModal}
    >
      <div className="flex flex-col space-y-4">
        <input
          onChange={(val) => setName(val.target.value)}
          className="custom-input"
          placeholder="Enter name"
        ></input>
        <button
          onClick={async () => {
            await onSubmit(name);
          }}
          className=" hover:bg-green-200 custom-btn"
        >
          Create ForfeitBox
        </button>
      </div>
    </Modal>
  );
}

export default CreateForfeitboxModal;
