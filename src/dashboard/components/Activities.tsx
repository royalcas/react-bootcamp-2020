import { Card } from 'antd';
import { Activity } from 'dashboard/model/activity';
import React from 'react';
import { DataList } from 'shared/dataList/DataList';

export type ActivityList = {
  pageData: Activity[];
  isLoading: boolean;
};

export const ActivityList = ({ pageData, isLoading }: ActivityList) => {
  return (
    <DataList data={pageData} isLoading={isLoading}>
      {(item: Activity) => {
        return <Card>{item.name}</Card>;
      }}
    </DataList>
  );
};
