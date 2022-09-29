import type { NextPage } from 'next';
import MenuCard from '../components/box_components/MenuCard';
('../components/box_components/MenuCard');
import PaymentIcon from '@mui/icons-material/Payment';
import GroupIcon from '@mui/icons-material/Group';
import { FlexWithGap } from '../components/helping_components/Divs';
import AssessmentIcon from '@mui/icons-material/Assessment';

const testData = [
  {
    text: 'Pay ur fines so u can feel god about urself',
    header: 'Payment',
    icon: <PaymentIcon sx={{ fontSize: '100px' }}></PaymentIcon>,
    route: '/boxname/payment',
  },
  {
    text: 'See all user in the box and explore their fines',
    header: 'Users',
    icon: <GroupIcon sx={{ fontSize: '100px' }}></GroupIcon>,
    route: '/boxname/Users',
  },
  {
    text: 'See statistics on fines and users',
    header: 'Statistics',
    icon: <AssessmentIcon sx={{ fontSize: '100px' }}></AssessmentIcon>,
    route: '/boxname/statistics',
  },
  {
    text: 'See all user in the box and explore their fines',
    header: 'Users',
    icon: <GroupIcon sx={{ fontSize: '100px' }}></GroupIcon>,
    route: '/boxname/users',
  },
  {
    text: 'See all user in the box and explore their fines',
    header: 'Users',
    icon: <GroupIcon sx={{ fontSize: '100px' }}></GroupIcon>,
    route: '/boxname/users',
  },
  {
    text: 'See all user in the box and explore their fines',
    header: 'Something',
    icon: <GroupIcon sx={{ fontSize: '100px' }}></GroupIcon>,
    route: '/boxname/users',
  },
];

const BoxMenu: NextPage = () => {
  return (
    <div>
      <FlexWithGap>
        {testData.map((elem) => {
          return (
            <MenuCard
              route={elem.route}
              icon={elem.icon}
              text={elem.text}
              header={elem.header}
            ></MenuCard>
          );
        })}
      </FlexWithGap>
    </div>
  );
};

export default BoxMenu;
