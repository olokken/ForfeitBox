"use client";
import { SessionProvider } from "next-auth/react";
import React from "react";
import { LayoutProvider } from "../context/LayoutContext";
import Auth from "../pages/api/auth/Auth";

type ProviderProps = {
  children: React.ReactNode | React.ReactNode[];
};

function Providers({ children }: ProviderProps) {
  return (
    <SessionProvider>
      <Auth>
        <LayoutProvider>{children}</LayoutProvider>
      </Auth>
    </SessionProvider>
  );
}

export default Providers;
