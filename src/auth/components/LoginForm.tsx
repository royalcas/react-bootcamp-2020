import { LockOutlined, MailOutlined } from '@ant-design/icons';
import { Alert, Button, Form, Input } from 'antd';
import Credentials from 'auth/models/credentials';
import React from 'react';

export type LoginFormProps = {
  onLogin: (credentials: Credentials) => void;
  errorLogin?: boolean;
  attemptingLogin?: boolean;
};

export const LoginForm = ({ onLogin, errorLogin, attemptingLogin }: LoginFormProps) => {
  return (
    <Form name="basic" layout="vertical" onFinish={values => onLogin(values as Credentials)}>
      {errorLogin ? <Alert style={{ marginBottom: 15 }} message="Invalid Credentials" type="error" /> : <></>}
      <Form.Item
        name="email"
        rules={[
          {
            required: true,
            message: 'Email is required',
          },
          {
            type: 'email',
            message: 'Enter a valid email address',
          },
        ]}
        validateTrigger="onBlur"
      >
        <Input size="large" placeholder="Email" prefix={<MailOutlined />} />
      </Form.Item>

      <Form.Item
        name="password"
        rules={[
          {
            required: true,
            message: 'Password is required',
          },
          {
            min: 6,
            message: 'Password should be 6 characters minimum',
          },
        ]}
        validateTrigger="onBlur"
      >
        <Input.Password size="large" placeholder="Password" prefix={<LockOutlined />} />
      </Form.Item>

      <Form.Item>
        <Button type="primary" htmlType="submit" loading={attemptingLogin} shape="round" size="large" block>
          Login
        </Button>
      </Form.Item>
    </Form>
  );
};
