import { AuthApi } from 'auth/api/AuthApi';
import { Action, AnyAction } from 'redux';
import { ThunkAction } from 'redux-thunk';
import { State } from './../../redux/reducers';
import { RegisterFormModel } from './../models/registerFormModel';
import { setCurrentUser } from './actionCreators';
import { LoginActions, RegisterActions } from './actionTypes';

export const attemptRegister = (): Action<RegisterActions> => {
  return {
    type: RegisterActions.AttemptRegister,
  };
};

export const errorRegister = (): Action<RegisterActions> => {
  return {
    type: RegisterActions.SetError,
  };
};

export const register = (
  registerForm: RegisterFormModel,
): ThunkAction<void, State, AnyAction, Action<RegisterActions | LoginActions>> => {
  const authApi = new AuthApi();
  return async dispatch => {
    dispatch(attemptRegister());
    try {
      const userProfile = await authApi.register(registerForm);
      dispatch(setCurrentUser(userProfile));
    } catch {
      dispatch(errorRegister());
    }
  };
};
