import { Button, Row } from 'antd';
import React, { Fragment, useState } from 'react';
import { AccessTemplate } from 'shared/@layout/AccessTemplate';
import LoginConnected from './LoginConnected';
import './LoginRegister.scss';
import RegisterConnected from './RegisterConnected';
export const LoginRegister = () => {
  const [inLogin, setInLogin] = useState(true);

  const goToRegister = (event: React.MouseEvent<HTMLAnchorElement, MouseEvent>) => {
    event.preventDefault();
    setInLogin(false);
  };

  const goToLogin = (event: React.MouseEvent<HTMLAnchorElement, MouseEvent>) => {
    event.preventDefault();
    setInLogin(true);
  };

  return (
    <AccessTemplate>
      <h1>{inLogin ? 'Login' : 'Register'}</h1>
      {inLogin ? (
        <Fragment>
          <Row>
            <div className="register-call-to-action">
              New user?
              <Button type="link" onClick={goToRegister} href="#">
                Create an account
              </Button>
            </div>
          </Row>
          <LoginConnected></LoginConnected>
        </Fragment>
      ) : (
        <Fragment>
          <Row>
            <div className="register-call-to-action">
              Already have an account?
              <Button type="link" onClick={goToLogin} href="#">
                Log in
              </Button>
            </div>
          </Row>
          <RegisterConnected></RegisterConnected>
        </Fragment>
      )}
    </AccessTemplate>
  );
};
