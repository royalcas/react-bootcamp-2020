import { Col, Row } from 'antd';
import React from 'react';
import ProfileInfoButton from './ProfileInfoButton';

export const HeaderTemplate = () => {
  return (
    <Row className="page-header" justify="end">
      <Col md={6}>
        <ProfileInfoButton />
      </Col>
    </Row>
  );
};
