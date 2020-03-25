import { Card, Tag } from 'antd';
import moment from 'moment';
import React, { useEffect, useState } from 'react';
import { MedicalHistoryApi } from './api/MedicalHistoryApi';
import { MedicalHistoryModel } from './models/MedicalHistoryModel';
export const MedicalHistory = () => {
  const [userId] = useState('1');
  const [medicalHistory, setMedicalHistory] = useState<MedicalHistoryModel[]>([]);
  useEffect(() => {
    const api = new MedicalHistoryApi();
    api.getMedicalHistoryByUser(userId).then(data => {
      setMedicalHistory(data);
    });
  }, [userId]);
  return (
    <div>
      <h1>Medical History</h1>
      {medicalHistory.map(record => (
        <Card bordered={true} about="test" title={moment(record.appointmentDate).format('LLL')}>
          <div className="main-content">{record.description}</div>
          <div className="diagnosis">
            {record.diagnosedIllnesses.map(illness => (
              <Tag>{illness}</Tag>
            ))}
          </div>
        </Card>
      ))}
    </div>
  );
};
