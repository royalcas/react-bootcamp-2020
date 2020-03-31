import { Form, Modal } from 'antd';
import { MedicalRecordItem } from 'history/models/MedicalRecordItem';
import moment from 'moment';
import React from 'react';
import { MedicalRecordForm } from './MedicalRecordForm';

export type MedicalRecordModalFormProps = {
  opened: boolean;
  onSave: (item: MedicalRecordItem) => void;
  onCancel: () => void;
};

export const MedicalRecordModalForm = ({ opened, onCancel, onSave }: MedicalRecordModalFormProps) => {
  const [form] = Form.useForm();
  return (
    <Modal
      title="New Medical Record Entry"
      visible={opened}
      okText="Add"
      cancelText="Cancel"
      onCancel={onCancel}
      onOk={() => {
        form
          .validateFields()
          .then(values => {
            console.log(values);
            form.resetFields();
            onSave(values as MedicalRecordItem);
          })
          .catch(info => {
            console.log('Validate Failed:', info);
          });
      }}
    >
      <Form form={form} layout="vertical" initialValues={{ date: moment() }}>
        <MedicalRecordForm />
      </Form>
    </Modal>
  );
};
