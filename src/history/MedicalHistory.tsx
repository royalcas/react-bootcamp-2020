import { Card } from 'antd';
import moment from 'moment';
import React, { useEffect, useState } from 'react';
import { MedicalRecordApi } from './api/MedicalHistoryApi';
import { MedicalRecordItem } from './models/MedicalRecordItem';

export const MedicalHistory = () => {
  const [userId] = useState('1');
  const [medicalHistory, setMedicalHistory] = useState<MedicalRecordItem[]>([]);
  useEffect(() => {
    const api = new MedicalRecordApi();
    api.getMedicalRecord().then(data => {
      setMedicalHistory(data);
    });
  }, [userId]);
  return (
    <div>
      <h1>Medical History</h1>
      {medicalHistory.map(record => (
        <Card bordered={true} about="test" title={moment(record.date).format('LLL')}>
          <div className="main-content">{record.details}</div>
        </Card>
      ))}
    </div>
  );
};
