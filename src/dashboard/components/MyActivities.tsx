import { myActivitiesSelector } from 'dashboard/+state/dashboardSelectors';
import React from 'react';
import { connect } from 'react-redux';
import { ActivityList } from './Activities';

export const MyActivitiesConnected = connect(myActivitiesSelector)(ActivityList);

export const MyActivities = () => {
  return (
    <>
      <h3>My Activities</h3>
      <MyActivitiesConnected />
    </>
  );
};
