import { PlusOutlined } from '@ant-design/icons';
import { Button, Card, notification } from 'antd';
import moment from 'moment';
import React, { useEffect, useState } from 'react';
import { DataList } from 'shared/dataList/DataList';
import { MedicalRecordModalForm } from './components/MedicalRecordModalForm';
import { MedicalRecordItem } from './models/MedicalRecordItem';

export type MedicalHistoryProps = {
  onInit: () => void;
  onNewMedicalRecord: (medicalRecordItem: MedicalRecordItem) => void;
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

export const MedicalHistory = ({ onInit, isLoading, onNewMedicalRecord, pageData }: MedicalHistoryProps) => {
  const [addingNewRecord, setAddingNewRecord] = useState(false);

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
          actions={
            <Button type="primary" onClick={() => setAddingNewRecord(true)} icon={<PlusOutlined />}>
              Add
            </Button>
          }
          emptyMessage="No Medical Record Yet"
          callToActionText="Start Now!"
          callToAction={() => setAddingNewRecord(true)}
        >
          {(item: MedicalRecordItem) => <MedicalHistoryItem key={item.id} item={item}></MedicalHistoryItem>}
        </DataList>
      </div>
      <MedicalRecordModalForm
        opened={addingNewRecord}
        onCancel={() => setAddingNewRecord(false)}
        onSave={medicalRecordItem => {
          setAddingNewRecord(false);
          onNewMedicalRecord(medicalRecordItem);
          notification.info({
            message: `New Record Added`,
            placement: 'bottomRight',
          });
        }}
      ></MedicalRecordModalForm>
    </div>
  );
};
