import { AuthApi } from 'auth/api/AuthApi';
import Credentials from 'auth/models/credentials';
import { UserProfileInfo } from 'auth/models/userProfileInfo';
import { Action, AnyAction } from 'redux';
import { ThunkAction } from 'redux-thunk';
import { State } from './../../redux/reducers';
import { LoginActions } from './actionTypes';

export const attemptLogin = (): Action<LoginActions> => {
  return {
    type: LoginActions.AttemptLogin,
  };
};

export const setLogout = (): Action<LoginActions> => {
  return {
    type: LoginActions.Logout,
  };
};

export const setInitSessionInfo = (): Action<LoginActions> => {
  return {
    type: LoginActions.SetInitSessionInfo,
  };
};

export const setCurrentUser = (userProfile: UserProfileInfo): AnyAction => {
  return {
    type: LoginActions.SetUserProfile,
    payload: userProfile,
  };
};

export const errorLogin = (): Action<LoginActions> => {
  return {
    type: LoginActions.SetError,
  };
};

export const login = (credentials: Credentials): ThunkAction<void, State, AnyAction, Action<LoginActions>> => {
  const authApi = new AuthApi();
  return async (dispatch, getState: () => State) => {
    dispatch(attemptLogin());
    try {
      const userProfile = await authApi.login(credentials);
      dispatch(setCurrentUser(userProfile));
    } catch (error) {
      dispatch(errorLogin());
    }
  };
};

export const loadLoginInfo = (): ThunkAction<void, State, AnyAction, Action<LoginActions>> => {
  const authApi = new AuthApi();
  return async dispatch => {
    if (!authApi.isLoggedIn()) {
      return;
    }
    dispatch(setInitSessionInfo());
    try {
      const userProfile = await authApi.getCurrentUserProfileInfo();
      dispatch(setCurrentUser(userProfile));
    } catch (error) {
      dispatch(errorLogin());
    }
  };
};

export const logout = (): ThunkAction<void, State, AnyAction, Action<LoginActions>> => {
  const authApi = new AuthApi();
  return async dispatch => {
    authApi.logout();

    dispatch(setLogout());
  };
};
