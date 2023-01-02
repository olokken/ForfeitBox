"use client";
import React, { useContext, useState, useCallback } from "react";

type LayoutProviderProps = {
  children: React.ReactNode | React.ReactNode[];
};
type LayoutContextType = {
  isSidebarOpen: boolean;
  isDarkmode: boolean;
  toggleSidebar: () => void;
  toggleDarkmode: () => void;
};
const LayoutContext = React.createContext<LayoutContextType>({
  isSidebarOpen: false,
  isDarkmode: false,
} as LayoutContextType);

//This is not working idk why
export function useLayout(): LayoutContextType {
  return useContext(LayoutContext);
}

export const LayoutProvider = ({ children }: LayoutProviderProps) => {
  const [isSidebarOpen, setIsSidebarOpen] = useState<boolean>(false);
  const [isDarkmode, setIsDarkmode] = useState<boolean>(false);

  const toggleSidebar = useCallback(() => {
    setIsSidebarOpen(!isSidebarOpen);
  }, [isSidebarOpen]);

  const toggleDarkmode = useCallback(() => {
    setIsDarkmode(!isDarkmode);
  }, [isDarkmode]);

  return (
    <LayoutContext.Provider
      value={{ isSidebarOpen, isDarkmode, toggleDarkmode, toggleSidebar }}
    >
      {children}
    </LayoutContext.Provider>
  );
};

export default LayoutContext;
