import { NextRouter, useRouter } from "next/router";
import React from "react";
import styled from "styled-components";
import LoginCard from "../components/login_components/LoginCard";

const LoginContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
`;

function LoginPage() {
  const router: NextRouter = useRouter();

  const login = () => {
    router.push("/");
  };

  return (
    <LoginContainer>
      <LoginCard login={login}></LoginCard>
    </LoginContainer>
  );
}

export default LoginPage;
