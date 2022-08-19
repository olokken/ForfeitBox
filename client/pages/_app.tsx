import { ThemeProvider } from "@mui/material";
import type { AppProps } from "next/app";
import { useState } from "react";
import { darkTheme } from "../themes/DarkTheme";
import { lightTheme } from "../themes/LightTheme";

function MyApp({ Component, pageProps }: AppProps) {
  const [isDarkMode] = useState<boolean>(false);

  return (
    <ThemeProvider theme={isDarkMode ? darkTheme : lightTheme}>
      <Component {...pageProps} />
    </ThemeProvider>
  );
}

export default MyApp;
