import { Checkbox, Input, InputNumber } from 'antd';
import { Form, Formik } from 'formik';
import React from 'react';

export const LoginForm = () => {
  return (
    <Formik
      initialValues={{ username: '', password: '' }}
      onSubmit={(values, actions) => console.log({ values, actions })}
      render={() => (
        <Form>
          <Input name="username" placeholder="Username" />
          <InputNumber name="password" type="password" />
          <Checkbox name="newsletter">Newsletter</Checkbox>
        </Form>
      )}
    />
  );
};

export const LoginRegister = () => {
  return (
    <div>
      <h1>Login & Register</h1>
      <LoginForm></LoginForm>
    </div>
  );
};
