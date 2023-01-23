"use client";
import React, { useState } from "react";
import { useLayout } from "../../../context/LayoutContext";
import { MinimalBox } from "../../../data/models/Box";
import CreateForfeitboxModal from "./CreateForfeitboxModal";
import JoinForfeitboxModal from "./JoinForfeitboxModal";

async function joinBox(code: string) {
  console.log("a no lo siento");
}

async function createBox(name: string): Promise<MinimalBox> {
  console.log("a no lo siento");
  return {} as MinimalBox;
}

type SidebarProps = {
  searchbar: React.ReactElement;
  boxCards: React.ReactElement[];
};

function Sidebar({ searchbar, boxCards }: SidebarProps) {
  const { isSidebarOpen } = useLayout();
  const [isCreateModalOpen, setIsCreateModalOpen] = useState<boolean>(false);
  const [isJoinModalOpen, setIsJoinModalOpen] = useState<boolean>(false);

  return (
    <React.Fragment>
      <aside
        className={`${
          isSidebarOpen ? "translate-x-0" : "-translate-x-full"
        } transition-all h-[calc(100%-5rem)] p-1 pb-2 border-r left-0 fixed flex flex-col w-72 border-gray-300 dark:border-gray-600 justify-between`}
      >
        <div className="h-[calc(100%-8rem)]">
          {searchbar}
          <ul className="overflow-auto space-y-1 mt-1 h-[calc(100%-4.5rem)]">
            {boxCards}
          </ul>
        </div>
        <div className="flex flex-col w-full space-y-2">
          <button
            className="custom-btn"
            onClick={() => setIsCreateModalOpen(true)}
          >
            Create New ForfeitBox
          </button>
          <button
            className="custom-btn"
            onClick={() => setIsJoinModalOpen(true)}
          >
            Join ForfeitBox
          </button>
        </div>
      </aside>
      <CreateForfeitboxModal
        close={() => setIsCreateModalOpen(false)}
        showModal={isCreateModalOpen}
        onSubmit={createBox}
      ></CreateForfeitboxModal>
      <JoinForfeitboxModal
        close={() => setIsJoinModalOpen(false)}
        showModal={isJoinModalOpen}
        onSubmit={joinBox}
      ></JoinForfeitboxModal>
    </React.Fragment>
  );
}

export default Sidebar;
