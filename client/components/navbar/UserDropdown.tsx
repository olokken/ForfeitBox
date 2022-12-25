"use client";
import React, { useState } from "react";
import { AiOutlineArrowDown } from "react-icons/Ai";

function UserDropdown() {
  const [showDropdown, setShowDropdown] = useState<boolean>(false);

  const onClickDropdown = () => {
    const myDiv = document.getElementById("menu")!;
    if (showDropdown) {
      myDiv.classList.add("hidden");
    } else {
      myDiv.classList.remove("hidden");
    }
    setShowDropdown(!showDropdown);
  };
  return (
    <div className="relative inline-block text-left">
      <div>
        <button
          type="button"
          className="custom-btn flex focus:ring-2 focus:ring-blue-500 focus:ring-offset-gray-100;"
          id="menu-button"
          aria-expanded="true"
          aria-haspopup="true"
          onClick={onClickDropdown}
        >
          Options
          <AiOutlineArrowDown className="-mr-1 ml-2 h-5 w-5"></AiOutlineArrowDown>
        </button>
      </div>
      <div
        id="menu"
        className="hidden absolute right-0 z-10 mt-2 w-56 origin-top-right rounded-md bg-white shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none"
        role="menu"
        aria-orientation="vertical"
        aria-labelledby="menu-button"
      >
        <div className="py-1" role="none">
          <a
            href="#"
            className="dropdown-items"
            role="menuitem"
            id="menu-item-0"
          >
            Account settings
          </a>
          <a
            href="#"
            className="dropdown-items"
            role="menuitem"
            id="menu-item-1"
          >
            Change Theme
          </a>
          <form method="POST" action="#" role="none">
            <button
              type="submit"
              className="dropdown-items"
              role="menuitem"
              id="menu-item-3"
            >
              Sign out
            </button>
          </form>
        </div>
      </div>
    </div>
  );
}

export default UserDropdown;
