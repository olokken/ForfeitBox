import { Toolbar } from '@mui/material';
import { styled } from '@mui/material/styles';
import React, { Fragment, useState } from 'react';
import Navbar from './navbar_components/Navbar';
import Sidebar from './sidebar_components/Sidebar';

interface Props {
  isDarkMode: boolean;
  updateDarkmode: (bool: boolean) => void;
  children: React.ReactElement;
}

/**
 * Container for elements that shows on any page
 * @returns Layout
 */

const Layout = ({ isDarkMode, updateDarkmode, children }: Props) => {
  const [showSidebar, setShowSidebar] = useState<boolean>(true);
  const SlideContent = styled('main', {
    shouldForwardProp: (prop) => prop !== 'showSidebar',
  })<{
    showSidebar?: boolean;
  }>(({ theme, showSidebar }) => ({
    flexGrow: 1,
    padding: theme.spacing(3),
    transition: theme.transitions.create('margin', {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.leavingScreen,
    }),
    marginLeft: `220px`,
    ...(!showSidebar && {
      transition: theme.transitions.create('margin', {
        easing: theme.transitions.easing.easeOut,
        duration: theme.transitions.duration.enteringScreen,
      }),
      marginLeft: 0,
    }),
  }));
  return (
    <Fragment>
      <Navbar
        isDarkMode={isDarkMode}
        updateDarkmode={updateDarkmode}
        showSidebar={showSidebar}
        setShowSidebar={setShowSidebar}
      ></Navbar>
      <Sidebar
        showSidebar={showSidebar}
        setShowSidebar={setShowSidebar}
      ></Sidebar>
      <SlideContent showSidebar={showSidebar}>
        <Toolbar />
        {children}
      </SlideContent>
    </Fragment>
  );
};

export default Layout;
