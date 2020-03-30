import { Button, Col, DatePicker, Form, Input, Row, Select } from 'antd';
import { RegisterFormModel } from 'auth/models/registerFormModel';
import { UserGender, UserProfileInfo } from 'auth/models/userProfileInfo';
import { isNil } from 'lodash';
import React, { useState } from 'react';
import { AvatarField } from 'shared/avatar/AvatarField';

const { Option } = Select;

export type RegisterFormProps = {
  onSubmit: (form: RegisterFormModel) => void;
  userInfo: UserProfileInfo;
  attemptingRegister?: boolean;
};

export const RegisterForm = ({ userInfo, onSubmit, attemptingRegister }: RegisterFormProps) => {
  const editMode = !isNil(userInfo);
  const initialValues = userInfo || { gender: UserGender.Male };
  const [gender, setGender] = useState(initialValues.gender);

  return (
    <Form
      layout="vertical"
      name="basic"
      onFinish={values => onSubmit(values as RegisterFormModel)}
      initialValues={initialValues}
    >
      <Row>
        <Col span={12}>
          {' '}
          <Form.Item
            label="First Name"
            name="firstName"
            rules={[{ required: true, message: 'First Name is required' }]}
            validateTrigger="onBlur"
          >
            <Input />
          </Form.Item>
        </Col>
        <Col span={12}>
          <Form.Item
            label="Last Name"
            name="lastName"
            rules={[{ required: true, message: 'Last Name is required' }]}
            validateTrigger="onBlur"
          >
            <Input />
          </Form.Item>
        </Col>
      </Row>

      <Form.Item
        label="Email"
        name="email"
        rules={[
          { required: true, message: 'Last Name is required' },
          {
            type: 'email',
            message: 'Enter a valid email address',
          },
        ]}
        validateTrigger="onBlur"
      >
        <Input type="email" disabled={editMode} />
      </Form.Item>
      <Row>
        <Col span={12}>
          <Form.Item label="Gender" name="gender" rules={[{ required: true, message: 'Gender is required' }]}>
            <Select defaultValue={gender} onSelect={setGender}>
              <Option value={UserGender.Male}>Male</Option>
              <Option value={UserGender.Female}>Female</Option>
              <Option value={UserGender.Other}>Other</Option>
            </Select>
          </Form.Item>
        </Col>
        <Col span={12}>
          <Form.Item label="Avatar" name="avatarUrl">
            <AvatarField gender={gender} />
          </Form.Item>
        </Col>
      </Row>

      <Form.Item
        label="Birth Date"
        name="birthDate"
        rules={[{ required: true, message: 'Birth Date is required' }]}
        validateTrigger="onBlur"
      >
        <DatePicker />
      </Form.Item>
      {!editMode && (
        <>
          <Form.Item
            label="Password"
            name="password"
            rules={[
              { required: true, message: 'Password is required' },
              {
                min: 6,
                message: 'Password should be 6 characters minimum',
              },
            ]}
            validateTrigger="onBlur"
          >
            <Input.Password />
          </Form.Item>

          <Form.Item
            label="Confirm Password"
            name="passwordConfirm"
            rules={[
              { required: true, message: 'Please confirm your password' },
              ({ getFieldValue }) => ({
                validator(rule, value) {
                  if (!value || getFieldValue('password') === value) {
                    return Promise.resolve();
                  }
                  return Promise.reject('The two passwords that you entered do not match!');
                },
              }),
            ]}
          >
            <Input.Password />
          </Form.Item>
        </>
      )}

      <Form.Item>
        <Button type="primary" htmlType="submit" size="large" shape="round" block loading={attemptingRegister}>
          {!editMode ? 'Register' : 'Save'}
        </Button>
      </Form.Item>
    </Form>
  );
};
