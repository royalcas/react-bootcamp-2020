import { Button, DatePicker, Form, Input, Select } from 'antd';
import Credentials from 'auth/models/credentials';
import React from 'react';
import { AvatarField } from 'shared/avatar/AvatarField';

const layout = {
  labelCol: { span: 8 },
  wrapperCol: { span: 16 },
};
const tailLayout = {
  wrapperCol: { offset: 8, span: 16 },
};
const { Option } = Select;

export type RegisterFormProps = {
  onLogin: (credentials: Credentials) => void;
};

export const RegisterForm = ({ onLogin }: RegisterFormProps) => {
  const onSubmit: (event: React.FormEvent<HTMLFormElement>) => void = event => {
    event.preventDefault();
    onLogin({ username: '', password: '' });
  };
  const Item = Form.Item as any;
  return (
    <Form {...layout} name="basic" onSubmit={onSubmit}>
      <Item label="Name" rules={[{ required: true, message: 'Please input your name!' }]} required={true}>
        <Input name="name" />
      </Item>

      <Form.Item label="Email">
        <Input name="email" type="email" />
      </Form.Item>

      <Form.Item label="Gender">
        <Select defaultValue="male">
          <Option value="male">Male</Option>
          <Option value="female">Female</Option>
          <Option value="other">Other</Option>
        </Select>
      </Form.Item>

      <Form.Item label="Avatar">
        <AvatarField gender="male" />
      </Form.Item>

      <Form.Item label="Birth Date">
        <DatePicker />
      </Form.Item>

      <Form.Item label="Password">
        <Input.Password name="password" />
      </Form.Item>

      <Form.Item label="Confirm Password">
        <Input.Password name="passwordConfirm" />
      </Form.Item>

      <Form.Item {...tailLayout}>
        <Button type="primary" htmlType="submit">
          Register
        </Button>
      </Form.Item>
    </Form>
  );
};
