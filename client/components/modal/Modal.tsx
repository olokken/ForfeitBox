import React from "react";
import { AiOutlineClose } from "react-icons/Ai";

type ModalProps = {
  children: React.ReactNode | React.ReactNode[];
  showModal: boolean;
  header: string;
  close: () => void;
};

function Modal({ children, showModal, header, close }: ModalProps) {
  if (!showModal) {
    return <></>;
  }

  return (
    <div
      id="defaultModal"
      aria-hidden="true"
      className="fixed flex content-center justify-center mt-20 m-auto z-50 w-full p-4 overflow-x-hidden overflow-y-auto md:inset-0 h-modal md:h-full"
    >
      <div className="relative w-full h-full max-w-2xl md:h-auto">
        <div className="relative bg-white rounded-lg shadow dark:bg-gray-700">
          <div className="flex items-start justify-between p-4 border-b rounded-t dark:border-gray-600">
            <h3 className="text-xl font-semibold text-gray-900 dark:text-white">
              {header}
            </h3>
            <button onClick={close} className="custom-btn">
              <AiOutlineClose></AiOutlineClose>
            </button>
          </div>
          <div className="p-2">{children}</div>
        </div>
      </div>
    </div>
  );
}

export default Modal;
