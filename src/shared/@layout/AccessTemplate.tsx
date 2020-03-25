import { Layout } from 'antd';
import React, { ReactNode, ReactNodeArray } from 'react';

export type AccessTemplateProps = {
  children: ReactNode | ReactNodeArray;
};
const { Content } = Layout;

export const AccessTemplate = ({ children }: AccessTemplateProps) => {
  return (
    <Layout className="landing-page-container">
      <Content className="access-container">{children}</Content>
    </Layout>
  );
};
