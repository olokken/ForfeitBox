"use client";
import React from "react";
import Searchbar from "../inputfields/Searchbar";
import { GiHamburgerMenu } from "react-icons/Gi";
import { GoSearch } from "react-icons/Go";
import UserDropdown from "./UserDropdown";
import { useLayout } from "../../context/LayoutContext";

function Navbar() {
  const { toggleSidebar } = useLayout();

  return (
    <header>
      <nav className="bg-white sm:px-4 py-2.5 dark:bg-gray-900 flex w-full z-20 top-0 custom-border h-20">
        <div className="container flex flex-wrap items-center justify-between min-w-full">
          <div className="flex justify-between h-full order-1">
            <button onClick={toggleSidebar} className="custom-btn mr-4">
              <GiHamburgerMenu></GiHamburgerMenu>
            </button>
            <span className="self-center text-xl font-semibold dark:text-white">
              Forfeit Box
            </span>
          </div>
          <div className="w-1/3 hidden md:block order-2">
            <Searchbar></Searchbar>
          </div>
          <button className="order-2 md:hidden custom-btn w-1/6 h-full flex items-center">
            <GoSearch></GoSearch>
          </button>
          <div className="order-3 mr-1">
            <UserDropdown></UserDropdown>
          </div>
        </div>
      </nav>
    </header>
  );
}

export default Navbar;
