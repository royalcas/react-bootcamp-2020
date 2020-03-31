import { DatePicker, Form, Input } from 'antd';
import React from 'react';

const { TextArea } = Input;

export const MedicalRecordForm = () => {
  return (
    <>
      <Form.Item
        label="Date"
        name="date"
        rules={[{ required: true, message: 'Date required' }]}
        validateTrigger="onBlur"
      >
        <DatePicker showTime />
      </Form.Item>
      <Form.Item
        label="Details"
        name="details"
        rules={[{ required: true, message: 'Details required' }]}
        validateTrigger="onBlur"
      >
        <TextArea placeholder="Details" autoSize={{ minRows: 3, maxRows: 20 }} />
      </Form.Item>
      <Form.Item
        label="Treatment"
        name="treatment"
        rules={[{ required: true, message: 'Treatment required' }]}
        validateTrigger="onBlur"
      >
        <TextArea placeholder="Treatment" autoSize={{ minRows: 3, maxRows: 20 }} />
      </Form.Item>
    </>
  );
};
