import { signIn } from "next-auth/react";
import React from "react";

function SignInButton() {
  return (
    <button
      className="rounded bg-blue-500 hover:bg-blue-700 text-white font-extrabold px-4"
      onClick={() => signIn()}
    >
      Sign In
    </button>
  );
}

export default SignInButton;
