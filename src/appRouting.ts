import { DesktopOutlined, PieChartOutlined } from '@ant-design/icons';
import { AntdIconProps } from '@ant-design/icons/lib/components/AntdIcon';
import ProfileFormConnected from 'auth/ProfileFormConnected';
import MedicalHistoryConnected from 'history/MedicalHistoryConnected';
import { ReactNode } from 'react';
import { LoginRegister } from './auth/LoginRegister';
import { Dashboard } from './dashboard/Dashboard';

export type AppRoute = {
  path: string;
  component: ReactNode | any;
  text: string;
  icon?: React.ForwardRefExoticComponent<AntdIconProps & React.RefAttributes<HTMLSpanElement>> | any;
  showInMainMenu?: boolean;
  exact?: boolean;
  routes?: AppRoute[];
};

export const routes: AppRoute[] = [
  {
    path: '/',
    exact: true,
    text: 'Dashboard',
    showInMainMenu: true,
    icon: PieChartOutlined,
    component: Dashboard,
  },
  {
    path: '/login',
    text: 'Login',
    component: LoginRegister,
  },
  {
    path: '/medical-history',
    text: 'Medical History',
    showInMainMenu: true,
    icon: DesktopOutlined,
    component: MedicalHistoryConnected,
  },
  {
    path: '/profile',
    text: 'Profile',
    showInMainMenu: false,
    component: ProfileFormConnected,
  },
];

export default routes;
