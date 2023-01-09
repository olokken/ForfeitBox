"use client";
import { useSession } from "next-auth/react";
import React from "react";
import { useLayout } from "../context/LayoutContext";

type PageContainerProps = {
  children: React.ReactNode;
};

function PageContainer({ children }: PageContainerProps) {
  const { isSidebarOpen } = useLayout();

  const { data } = useSession();

  return (
    <main className={`p-2 transition-margin-left ${isSidebarOpen && "ml-72"}`}>
      {children}
    </main>
  );
}

export default PageContainer;
