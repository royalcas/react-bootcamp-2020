import { Alert } from 'antd';
import { tipSelector } from 'dashboard/+state/dashboardSelectors';
import { Tip } from 'dashboard/model/tip';
import React from 'react';
import { connect } from 'react-redux';

export type TipDisplayProps = {
  pageData: Tip;
  isLoading: boolean;
};

export const TipDisplay = ({ pageData, isLoading }: TipDisplayProps) => {
  if (isLoading) return null;
  return <Alert message={pageData.title} description={pageData.description} type="info" showIcon />;
};

export const TipDisplayConnected = connect(tipSelector)(TipDisplay);

export const TipOfTheDay = () => {
  return (
    <>
      <h3>Tip of de Day</h3>
      <TipDisplayConnected />
    </>
  );
};
