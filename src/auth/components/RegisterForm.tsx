import { Button, DatePicker, Form, Input, Select } from 'antd';
import { RegisterFormModel } from 'auth/models/registerFormModel';
import { UserGender } from 'auth/models/userProfileInfo';
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
  onRegister: (form: RegisterFormModel) => void;
};

export const RegisterForm = ({ onRegister }: RegisterFormProps) => {
  return (
    <Form {...layout} name="basic" onFinish={values => onRegister(values as RegisterFormModel)}>
      <Form.Item
        label="First Name"
        name="firstName"
        rules={[{ required: true, message: 'Please input your name!' }]}
        required={true}
      >
        <Input />
      </Form.Item>

      <Form.Item label="Email" name="email">
        <Input type="email" />
      </Form.Item>

      <Form.Item label="Gender" name="gender">
        <Select defaultValue={UserGender.Male}>
          <Option value={UserGender.Male}>Male</Option>
          <Option value={UserGender.Female}>Female</Option>
          <Option value={UserGender.Other}>Other</Option>
        </Select>
      </Form.Item>

      <Form.Item label="Avatar" name="avatarUrl">
        <AvatarField gender="male" />
      </Form.Item>

      <Form.Item label="Birth Date" name="birthDate">
        <DatePicker />
      </Form.Item>

      <Form.Item label="Password" name="password">
        <Input.Password />
      </Form.Item>

      <Form.Item label="Confirm Password" name="passwordConfirm">
        <Input.Password />
      </Form.Item>

      <Form.Item {...tailLayout}>
        <Button type="primary" htmlType="submit">
          Register
        </Button>
      </Form.Item>
    </Form>
  );
};
