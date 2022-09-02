import DashboardIcon from '@mui/icons-material/Dashboard';
import GroupIcon from '@mui/icons-material/Group';
import InboxIcon from '@mui/icons-material/MoveToInbox';
import { Toolbar } from '@mui/material';
import Divider from '@mui/material/Divider';
import Drawer from '@mui/material/Drawer';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import React from 'react';
import { useRouter, NextRouter } from 'next/router';

interface Props {
  showSidebar: boolean;
  setShowSidebar: (bool: boolean) => void;
}

const Sidebar = ({ showSidebar, setShowSidebar }: Props) => {
  const router: NextRouter = useRouter();

  return (
    <Drawer
      style={{ width: '200px' }}
      open={showSidebar}
      variant="persistent"
      onClose={() => setShowSidebar(false)}
    >
      <Toolbar />
      <Divider />
      <Divider />
      <List sx={{ width: '100%' }} component="nav">
        <ListItem button key="Feed" onClick={() => router.push('/')}>
          <ListItemIcon>
            <DashboardIcon />
          </ListItemIcon>
          <ListItemText primary="Feed" />
        </ListItem>
        <Divider />
        <ListItem button key="Fineboxes" onClick={() => router.push('/')}>
          <ListItemIcon>
            <InboxIcon />
          </ListItemIcon>
          <ListItemText primary="Services" />
        </ListItem>
        <Divider />
        <ListItem button key="Voff" onClick={() => router.push('/voff')}>
          <ListItemIcon>
            <GroupIcon />
          </ListItemIcon>
          <ListItemText primary="Voff" />
        </ListItem>
        <Divider />
      </List>
    </Drawer>
  );
};

export default Sidebar;
