"use client";
import React, { useState } from "react";
import Modal from "../../server/modal/Modal";

type JoinForfeitboxModalProps = {
  showModal: boolean;
  onSubmit: (code: string) => Promise<void>;
  close: () => void;
};

function JoinForfeitboxModal({
  close,
  showModal,
  onSubmit,
}: JoinForfeitboxModalProps) {
  const [code, setCode] = useState<string>("");
  return (
    <Modal close={close} header={"Join a ForfeitBox"} showModal={showModal}>
      <div className="flex flex-col space-y-4">
        <input className="custom-input" placeholder="Enter code"></input>
        <button
          onClick={async () => {
            await onSubmit(code);
          }}
          className=" hover:bg-green-200 custom-btn"
        >
          Join ForfeitBox
        </button>
      </div>
    </Modal>
  );
}

export default JoinForfeitboxModal;
