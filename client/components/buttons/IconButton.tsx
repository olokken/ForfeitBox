import React from "react";

type IconButtonProps = {
  children: React.ReactNode;
};

function IconButton({ children }: IconButtonProps) {
  return (
    <button className="hover:bg-blue-500 p-3 dark:hover:bg-white rounded h-full">
      {children}
    </button>
  );
}

export default IconButton;
