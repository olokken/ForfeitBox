"use client";
import { SessionProvider } from "next-auth/react";
import React from "react";
import Auth from "../pages/api/auth/Auth";

type ProviderProps = {
  children: React.ReactNode;
};

function Providers({ children }: ProviderProps) {
  return (
    <SessionProvider>
      <Auth>{children}</Auth>
    </SessionProvider>
  );
}

export default Providers;
