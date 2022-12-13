import { signIn, useSession } from "next-auth/react";
import { NextRouter, useRouter } from "next/router";
import React, { useEffect } from "react";

type AuthProps = {
  children: React.ReactNode;
};

function Auth({ children }: AuthProps) {
  const router: NextRouter = useRouter();
  const { data: session, status } = useSession();

  useEffect(() => {
    if (status === "unauthenticated") {
      signIn("keycloak", { callbackUrl: "http://localhost:3000/" });
    } else {
      router.push("/");
    }
  }, [status]);

  if (status === "loading" || status === "unauthenticated") {
    return <div>Loading</div>;
  }
  return <>{children}</>;
}

export default Auth;
