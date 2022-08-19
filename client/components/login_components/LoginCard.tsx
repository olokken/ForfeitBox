import { Button } from "@mui/material";
import React from "react";
import styled from "styled-components";

const LoginCardContainer = styled.div`
  width: 30rem;
  height: 28rem;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  background: #94b8b8;
  border-radius: 8px;
  margin-top: 10rem;
`;

type Props = {
  login: () => void;
};

function LoginCard({ login }: Props) {
  return (
    <LoginCardContainer>
      <Button onClick={login}>Login</Button>
      <Button>Create new User</Button>
    </LoginCardContainer>
  );
}

export default LoginCard;
