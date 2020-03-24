import { Layout, Menu } from 'antd';
import { AppRoute } from 'appRouting';
import React, { ReactNode, ReactNodeArray, useState } from 'react';
import { Link } from 'react-router-dom';
const { Header, Content, Footer, Sider } = Layout;

export type MainPageTemplateProps = {
  children: ReactNode | ReactNodeArray;
  menu: AppRoute[];
};

export const MainPageTemplate = ({ children, menu }: MainPageTemplateProps) => {
  const [isCollapsed, setIsCollapsed] = useState(false);
  return (
    <div className="pageContainer">
      <Layout style={{ minHeight: '100vh' }}>
        <Sider collapsible collapsed={isCollapsed} onCollapse={setIsCollapsed}>
          <div className="logo" />
          <Menu theme="dark" defaultSelectedKeys={['1']} mode="inline">
            {menu
              .filter(item => item.showInMainMenu)
              .map((item, i) => (
                <Menu.Item key={i}>
                  <item.icon />
                  <span>{item.text}</span>
                  <Link to={item.path} />
                </Menu.Item>
              ))}
          </Menu>
        </Sider>
        <Layout className="site-layout">
          <Content style={{ margin: '10px 16px' }}>{children}</Content>
          <Footer style={{ textAlign: 'center' }}>React Bootcamp 2020</Footer>
        </Layout>
      </Layout>
    </div>
  );
};
