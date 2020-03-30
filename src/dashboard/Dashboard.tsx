import { Col, Row } from 'antd';
import React, { useEffect } from 'react';
import { useDispatch } from 'react-redux';
import { requestDashboardInfo } from './+state/dashboardActionCreators';
import { ActivitySuggestions } from './components/ActivitySuggestion';
import { MyActivities } from './components/MyActivities';
import { TipOfTheDay } from './components/Tip';

export const Dashboard = () => {
  const dispatch = useDispatch();

  useEffect(() => {
    console.log();
    dispatch(requestDashboardInfo());
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);
  return (
    <div>
      <h1>Dashboard</h1>
      <Row style={{ marginBottom: 15 }}>
        <Col md={18} span={24}>
          <TipOfTheDay />
          <MyActivities />
        </Col>
        <Col md={6} span={24}>
          <ActivitySuggestions />
        </Col>
      </Row>
    </div>
  );
};
