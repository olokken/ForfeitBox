import { ThemeProvider } from '@mui/material';
import type { AppProps } from 'next/app';
import { useState } from 'react';
import { darkTheme } from '../themes/DarkTheme';
import { lightTheme } from '../themes/LightTheme';
import { SessionProvider } from 'next-auth/react';
import Auth from './api/auth/Auth';
import Layout from '../components/Layout';

function MyApp({ Component, pageProps }: AppProps) {
  const [isDarkMode, setIsDarkMode] = useState<boolean>(true);

  return (
    <SessionProvider session={pageProps.session}>
      <Auth>
        <ThemeProvider theme={isDarkMode ? darkTheme : lightTheme}>
          <Layout
            isDarkMode={isDarkMode}
            updateDarkmode={(bol: boolean) => {
              setIsDarkMode(bol);
            }}
          >
            <Component {...pageProps} />
          </Layout>
        </ThemeProvider>
      </Auth>
    </SessionProvider>
  );
}

export default MyApp;
