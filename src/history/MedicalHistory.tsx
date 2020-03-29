import { Card } from 'antd';
import moment from 'moment';
import React, { useEffect } from 'react';
import { DataList } from 'shared/dataList/DataList';
import { MedicalRecordItem } from './models/MedicalRecordItem';

export type MedicalHistoryProps = {
  onInit: () => void;
  isLoading: boolean;
  hasErrors: boolean;
  pageData: MedicalRecordItem[];
};

export const MedicalHistoryItem = ({ item }: { item: MedicalRecordItem }) => {
  return (
    <Card bordered={true} about="test" title={moment(item.date).format('LLL')}>
      <div className="main-content">{item.details}</div>
    </Card>
  );
};

export const MedicalHistory = ({ onInit, isLoading, hasErrors, pageData }: MedicalHistoryProps) => {
  useEffect(() => {
    onInit();
  }, [onInit]);

  return (
    <div>
      <h1>Medical Record</h1>
      <div className="medical-record-container">
        <DataList
          isLoading={isLoading}
          data={pageData}
          emptyMessage="No Medical Record Yet"
          callToActionText="Start Now!"
        >
          {(item: MedicalRecordItem) => <MedicalHistoryItem key={item.id} item={item}></MedicalHistoryItem>}
        </DataList>
      </div>
    </div>
  );
};
