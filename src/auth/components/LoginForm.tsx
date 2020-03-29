import { Button, Form, Input } from 'antd';
import Credentials from 'auth/models/credentials';
import React from 'react';

const layout = {
  labelCol: { span: 8 },
  wrapperCol: { span: 16 },
};
const tailLayout = {
  wrapperCol: { offset: 8, span: 16 },
};

export type LoginFormProps = {
  onLogin: (credentials: Credentials) => void;
};

export const LoginForm = ({ onLogin }: LoginFormProps) => {
  return (
    <Form {...layout} name="basic" onFinish={values => onLogin(values as Credentials)}>
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

      <Form.Item {...tailLayout}>
        <Button type="primary" htmlType="submit">
          Login
        </Button>
      </Form.Item>
    </Form>
  );
};
