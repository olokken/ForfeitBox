import type { NextPage } from 'next';
import MenuCard from '../components/box_components/MenuCard';
('../components/box_components/MenuCard');
import PaymentIcon from '@mui/icons-material/Payment';
import GroupIcon from '@mui/icons-material/Group';
import { FlexWithGap } from '../components/helping_components/Divs';
import AssessmentIcon from '@mui/icons-material/Assessment';

const testData = [
  {
    text: 'Pay ur fines so u can ffel god about urself',
    header: 'Payment',
    icon: <PaymentIcon sx={{ fontSize: '100px' }}></PaymentIcon>,
  },
  {
    text: 'See all user in the box and explore their fines',
    header: 'Users',
    icon: <GroupIcon sx={{ fontSize: '100px' }}></GroupIcon>,
  },
  {
    text: 'See statistics on fines and users',
    header: 'Statistics',
    icon: <AssessmentIcon sx={{ fontSize: '100px' }}></AssessmentIcon>,
  },
  {
    text: 'See all user in the box and explore their fines',
    header: 'Users',
    icon: <GroupIcon sx={{ fontSize: '100px' }}></GroupIcon>,
  },
  {
    text: 'See all user in the box and explore their fines',
    header: 'Users',
    icon: <GroupIcon sx={{ fontSize: '100px' }}></GroupIcon>,
  },
  {
    text: 'See all user in the box and explore their fines',
    header: 'Users',
    icon: <GroupIcon sx={{ fontSize: '100px' }}></GroupIcon>,
  },
];

const BoxMenu: NextPage = () => {
  return (
    <div>
      <FlexWithGap>
        {testData.map((elem) => {
          return (
            <MenuCard
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
