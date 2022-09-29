import React from 'react';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Typography from '@mui/material/Typography';
import { CardActionArea } from '@mui/material';
import styled from 'styled-components';
import { CenterContnetCol, CenterContnetRow } from '../helping_components/Divs';
import PaymentIcon from '@mui/icons-material/Payment';

const StyledCard = styled(Card)`
  max-width: 15rem;
  min-width: 15rem;
  transition: transform 0.2s;
  :hover {
    transform: scale(1.1);
  }
`;
const StyledPaymentIcon = styled(PaymentIcon)`
  font-size: 100px;
`;

interface Props {
  header: string;
  icon: any;
  text: string;
}

const MenuCard = ({ header, icon, text }: Props) => {
  console.log(icon);

  return (
    <StyledCard onClick={() => console.log('Til siden')}>
      <CardActionArea>
        <CenterContnetRow>
          {/*   <StyledPaymentIcon></StyledPaymentIcon> */}
          {icon}
        </CenterContnetRow>
        <CardContent>
          <CenterContnetRow>
            <CenterContnetCol>
              <Typography gutterBottom variant="h5" component="div">
                {header}
              </Typography>
              <Typography variant="body2" color="text.secondary">
                {text}
              </Typography>
            </CenterContnetCol>
          </CenterContnetRow>
        </CardContent>
      </CardActionArea>
    </StyledCard>
  );
};

export default MenuCard;
