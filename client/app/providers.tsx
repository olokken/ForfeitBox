"use client";
import { SessionProvider } from "next-auth/react";
import React from "react";
import { LayoutProvider } from "../context/LayoutContext";

type ProviderProps = {
  children: React.ReactNode | React.ReactNode[];
};

function Providers({ children }: ProviderProps) {
  return (
    <SessionProvider>
      <LayoutProvider>{children}</LayoutProvider>
    </SessionProvider>
  );
}

export default Providers;
