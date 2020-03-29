import { LoadingOutlined } from '@ant-design/icons';
import { Card, Row, Skeleton, Spin } from 'antd';
import React from 'react';

export const SkeletonLoading = () => {
  return (
    <Card>
      <Skeleton />
    </Card>
  );
};

export const FullScreenLoading = () => {
  const antIcon = <LoadingOutlined style={{ fontSize: 100 }} spin />;

  return (
    <Row style={{ width: '100%', height: '100vh' }} align="middle" justify="center">
      <Spin indicator={antIcon} />
    </Row>
  );
};
