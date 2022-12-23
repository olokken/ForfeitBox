"use client";
import { useSession } from "next-auth/react";
import React, { useEffect } from "react";
import SignInButton from "../../../components/buttons/action_buttons/SignInButton";

type AuthProps = {
  children: React.ReactNode;
};

function Auth({ children }: AuthProps) {
  const { status } = useSession();

  if (status === "loading" || status === "unauthenticated") {
    return (
      <div>
        Du er ikke innlogget mannen
        <SignInButton></SignInButton>
      </div>
    );
  }
  return <>{children}</>;
}

export default Auth;
