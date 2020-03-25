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
  const onSubmit: (event: React.FormEvent<HTMLFormElement>) => void = event => {
    event.preventDefault();
    debugger;
    onLogin({ username: '', password: '' });
  };
  return (
    <Form {...layout} name="basic" onSubmit={onSubmit}>
      <Form.Item label="Username">
        <Input name="username" />
      </Form.Item>

      <Form.Item label="Password">
        <Input.Password name="password" />
      </Form.Item>

      <Form.Item {...tailLayout}>
        <Button type="primary" htmlType="submit">
          Login
        </Button>
      </Form.Item>
    </Form>
  );
};
