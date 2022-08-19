import Keycloak from 'keycloak-js';

export const ACCESS_TOKEN_KEY = 'token';
const REFRESH_TOKEN_KEY = 'refresh_token';

export const setTokens = (token: string, refreshToken: string) => {
  localStorage.setItem(ACCESS_TOKEN_KEY, token);
  localStorage.setItem(REFRESH_TOKEN_KEY, refreshToken);
};

export const clearTokens = () => {
  localStorage.removeItem(ACCESS_TOKEN_KEY);
  localStorage.removeItem(REFRESH_TOKEN_KEY);
};

const keycloakConfig: Keycloak.KeycloakConfig = {
  url: process.env.REACT_APP_KEYCLOACK_URL!,
  realm: process.env.REACT_APP_KEYCLOACK_REALM!,
  clientId: process.env.REACT_APP_KEYCLOACK_CLIENT_ID!
};

export const keycloak = new Keycloak(keycloakConfig);

export const isAuthenticated = () => {
  return !!keycloak.token;
};

export const getAccessToken = () => {
  return keycloak.token;
};

export const updateToken = (callback: () => void) => {
  return keycloak.updateToken(60).then(callback).catch(keycloak.login);
};

export const initializeKeycloak = (
  callback: (isAuthenticated: boolean) => void
) => {
  const token = localStorage.getItem(ACCESS_TOKEN_KEY) ?? '';
  const refreshToken = localStorage.getItem(REFRESH_TOKEN_KEY) ?? '';

  keycloak
    .init({
      onLoad: 'login-required',
      flow: 'standard',
      pkceMethod: 'S256',
      useNonce: true,
      token: token,
      refreshToken: refreshToken,
      checkLoginIframe: false
    })
    .then(callback)
    .catch(console.error);
};