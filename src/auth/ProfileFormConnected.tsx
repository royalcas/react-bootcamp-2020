import React from 'react';
import { connect } from 'react-redux';
import { authStateSelector } from './+state/authSelectors';
import { register } from './+state/registerActionCreators';
import { RegisterForm } from './components/RegisterForm';
import { RegisterFormModel } from './models/registerFormModel';

const mapDispatchToProps = (dispatch: any) => ({
  onSubmit: (registerForm: RegisterFormModel) => dispatch(register(registerForm)),
});

export const ProfileFormConnectedOnly = connect(authStateSelector, mapDispatchToProps)(RegisterForm);

export const ProfileFormConnectedPage = () => {
  return (
    <>
      <h1>Profile</h1>
      <ProfileFormConnectedOnly />{' '}
    </>
  );
};

export default ProfileFormConnectedPage;
