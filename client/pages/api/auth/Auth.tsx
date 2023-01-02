"use client";
import { useSession } from "next-auth/react";
import React from "react";
import { signIn } from "next-auth/react";

type AuthProps = {
  children: React.ReactNode | React.ReactNode[];
};

function Auth({ children }: AuthProps) {
  const { status } = useSession();

  if (status === "unauthenticated") {
    signIn();
    return <div>Du er ikke innlogget mannen</div>;
  }

  return <>{children}</>;
}

export default Auth;
