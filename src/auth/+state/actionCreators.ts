import { UserProfileInfo } from 'auth/models/userProfileInfo';
import { Action, AnyAction } from 'redux';
import { LoginActions } from './actionTypes';

export const attemptLogin = (): Action<LoginActions> => {
  return {
    type: LoginActions.AttemptLogin,
  };
};

export const setLoginResponse = (loginResponse: UserProfileInfo): AnyAction => {
  return {
    type: LoginActions.SetLoginResponse,
    payload: loginResponse,
  };
};
