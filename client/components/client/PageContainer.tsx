"use client";
import React from "react";
import { useLayout } from "../../context/LayoutContext";

type PageContainerProps = {
  children: React.ReactNode;
};

function PageContainer({ children }: PageContainerProps) {
  const { isSidebarOpen } = useLayout();

  return (
    <main className={`p-2 transition-margin-left ${isSidebarOpen && "ml-72"}`}>
      {children}
    </main>
  );
}

export default PageContainer;
