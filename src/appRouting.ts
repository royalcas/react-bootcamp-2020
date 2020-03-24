import { DesktopOutlined, PieChartOutlined } from '@ant-design/icons';
import { AntdIconProps } from '@ant-design/icons/lib/components/AntdIcon';
import { ReactNode } from 'react';
import { LoginRegister } from './auth/LoginRegister';
import { Dashboard } from './dashboard/Dashboard';
import { MedicalHistory } from './history/MedicalHistory';

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
    component: MedicalHistory,
  },
];

export default routes;
