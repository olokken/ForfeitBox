import React from "react";
import SignOutButton from "../buttons/action_buttons/SignOutButton";
import Searchbar from "../inputfields/Searchbar";
import { GiHamburgerMenu } from "react-icons/Gi";
import { CgProfile } from "react-icons/Cg";
import IconButton from "../buttons/IconButton";

function Navbar() {
  return (
    <nav className="bg-white sm:px-4 py-2.5 dark:bg-gray-900 flex w-full z-20 top-0 left-0 border-b border-gray-200 dark:border-gray-600">
      <div className="container flex flex-wrap items-center justify-between">
        <div className="flex justify-between">
          <IconButton>
            <GiHamburgerMenu></GiHamburgerMenu>
          </IconButton>
          <span className="self-center text-xl font-semibold dark:text-white ml-2">
            Forfeit Box
          </span>
        </div>
        <Searchbar></Searchbar>
        <IconButton>
          <CgProfile className="w-full h-full"></CgProfile>
        </IconButton>
      </div>
    </nav>
  );
}

export default Navbar;
