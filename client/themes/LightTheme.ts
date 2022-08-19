import { createTheme } from "@mui/material/styles";

export const lightTheme = createTheme({
  spacing: 4,
  palette: {
    mode: "light",
    primary: {
      main: "#ffffff",
    },
    background: {
      paper: "#ffffff",
      default: "#D5DDDF",
    },
    text: {
      primary: "#202020",
      secondary: "#202020",
    },
    action: {
      hover: "#9edebd",
    },
  },
  components: {
    MuiTableRow: {
      styleOverrides: {
        root: {
          backgroundColor: "white",
          "&.MuiTableRow-hover": {
            "&:hover": {
              backgroundColor: "#9edebd",
            },
          },
          "&.Mui-selected": {
            "&:active": {
              backgroundColor: "#77a88f",
            },
          },
        },
      },
    },
    MuiLink: {
      styleOverrides: {
        root: {
          color: "#03008c",
        },
      },
    },
    MuiInputLabel: {
      styleOverrides: {
        root: {
          color: "#000000 !important",
        },
      },
    },
    MuiTabs: {
      styleOverrides: {
        root: {
          backgroundColor: "#6B8E4E !important",
          fontSize: "20px !important",
          background: "#9edebd !important",
        },
        indicator: {
          backgroundColor: "#020202 !important",
        },
      },
    },
    MuiTab: {
      styleOverrides: {
        root: {
          color: "#757575",
          "&.Mui-selected": {
            color: "black !important",
          },
        },
      },
    },
    MuiListSubheader: {
      styleOverrides: {
        root: {
          backgroundColor: "#9edebd",
        },
      },
    },
  },
});
