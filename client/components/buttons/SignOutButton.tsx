"use client";
import { signOut } from "next-auth/react";
import React from "react";

function SignOutButton() {
  return (
    <button
      onClick={() => signOut()}
      className="rounded bg-red-500 hover:bg-red-700 text-white font-extrabold px-4"
    >
      Sign Out
    </button>
  );
}

export default SignOutButton;
