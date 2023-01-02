"use client";
import React, { useState } from "react";
import { useLayout } from "../../context/LayoutContext";
import Searchbar from "../inputfields/Searchbar";
import CreateForfeitboxModal from "./CreateForfeitBoxModal";

function Sidebar() {
  const { isSidebarOpen } = useLayout();
  const [isCreateModalOpen, setIsCreateModalOpen] = useState<boolean>(false);

  return (
    <React.Fragment>
      <aside
        className={`${
          isSidebarOpen ? "translate-x-0" : "-translate-x-full"
        } transition-all h-[calc(100%-5rem)] p-1 pb-2 border-r left-0 fixed flex flex-col w-72 border-gray-300 dark:border-gray-600`}
      >
        <Searchbar></Searchbar>
        <div className="mt-auto flex flex-col w-full space-y-2">
          <button
            className="custom-btn"
            onClick={() => setIsCreateModalOpen(true)}
          >
            Create New ForfeitBox
          </button>
          <button className="custom-btn">Join ForfeitBox</button>
        </div>
      </aside>
      <CreateForfeitboxModal
        close={() => setIsCreateModalOpen(false)}
        showModal={isCreateModalOpen}
        onSubmit={() => setIsCreateModalOpen(false)}
      ></CreateForfeitboxModal>
    </React.Fragment>
  );
}

export default Sidebar;
