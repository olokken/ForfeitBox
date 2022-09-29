import MenuIcon from '@mui/icons-material/Menu';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import IconButton from '@mui/material/IconButton';
import Toolbar from '@mui/material/Toolbar';
import { DarkModeSwitch } from '../switches/DarkModeSwitch';

interface Props {
  isDarkMode: boolean;
  updateDarkmode: (bool: boolean) => void;
  showSidebar: boolean;
  setShowSidebar: (bool: boolean) => void;
}

const Navbar = ({
  isDarkMode,
  updateDarkmode,
  showSidebar,
  setShowSidebar,
}: Props) => {
  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar position="fixed" sx={{ zIndex: '1301 !important' }}>
        <Toolbar sx={{ justifyContent: "space-between" }}>
          <IconButton
            size="large"
            edge="start"
            color="inherit"
            aria-label="Open or close drawer"
            aria-haspopup="true"
            sx={{ mr: 2 }}
            onClick={() => setShowSidebar(!showSidebar)}
          >
            <MenuIcon />{' '}
          </IconButton>
          <DarkModeSwitch
            inputProps={{ 'aria-label': 'Change theme' }}
            aria-checked={isDarkMode}
            checked={isDarkMode}
            onChange={() => updateDarkmode(!isDarkMode)}
          ></DarkModeSwitch>
        </Toolbar>
      </AppBar>
    </Box>
  );
};

export default Navbar;
