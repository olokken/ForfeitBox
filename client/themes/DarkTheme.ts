import { createTheme } from "@mui/material/styles";

export const darkTheme = createTheme({
  spacing: 4,
  palette: {
    mode: "dark",
    primary: {
      main: "#303030",
    },
    background: {
      default: "#202020",
      paper: "#202020",
    },
    text: {
      primary: "#ffffff",
      secondary: "#ffffff",
    },
    action: {
      /*       hover: "#008a00",
       */
    },
  },
  components: {
    MuiTableRow: {
      styleOverrides: {
        root: {
          "&.MuiTableRow-hover": {
            "&:hover": {
              backgroundColor: "#383838",
            },
          },
          "&.Mui-selected": {
            "&:active": {
              backgroundColor: "#2b2b2b",
            },
          },
        },
      },
    },
    MuiLink: {
      styleOverrides: {
        root: {
          color: "#a3ff9e",
        },
      },
    },
    MuiInputLabel: {
      styleOverrides: {
        root: {
          color: "#ffffff !important",
        },
      },
    },
    MuiFilledInput: {
      styleOverrides: {
        root: {
          "&::after": {
            borderBottomColor: "#202020 !important",
          },
        },
      },
    },
    MuiTabs: {
      styleOverrides: {
        root: {
          backgroundColor: "#020202 !important",
          fontSize: "20px !important",
          background: "#353839 !important",
        },
        indicator: {
          backgroundColor: "#ffffff !important",
        },
      },
    },
    MuiTab: {
      styleOverrides: {
        root: {
          color: "#757575",
          "&.Mui-selected": {
            color: "#ffffff !important",
          },
        },
      },
    },
    MuiListSubheader: {
      styleOverrides: {
        root: {
          backgroundColor: "#292929",
        },
      },
    },
  },
});
