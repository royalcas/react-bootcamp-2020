import { Alert, Button, Form, Input } from 'antd';
import Credentials from 'auth/models/credentials';
import React from 'react';

export type LoginFormProps = {
  onLogin: (credentials: Credentials) => void;
  errorLogin?: boolean;
};

export const LoginForm = ({ onLogin, errorLogin }: LoginFormProps) => {
  return (
    <Form name="basic" layout="vertical" onFinish={values => onLogin(values as Credentials)}>
      {errorLogin ? <Alert style={{ marginBottom: 15 }} message="Invalid Credentials" type="error" /> : <></>}
      <Form.Item
        label="Email"
        name="username"
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
        <Input type="email" placeholder="youremail@domain.com" />
      </Form.Item>

      <Form.Item
        label="Password"
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
        <Input.Password placeholder="****" />
      </Form.Item>

      <Form.Item>
        <Button type="primary" htmlType="submit">
          Login
        </Button>
      </Form.Item>
    </Form>
  );
};
