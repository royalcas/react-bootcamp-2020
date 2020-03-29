import { AnyAction } from 'redux';
import { UserProfileInfo } from './../models/userProfileInfo';
import { LoginActions, RegisterActions } from './actionTypes';

export type AuthState = {
  loadingSessionInfo?: boolean;
  attemptingLogin?: boolean;
  attemptingRegister?: boolean;
  errorLogin?: boolean;
  errorRegister?: boolean;
  isLoggedIn: boolean;
  userInfo: UserProfileInfo;
};

export const initialState: AuthState = {
  isLoggedIn: false,
  userInfo: null as any,
};

export const reducer = (state: AuthState = initialState, action: AnyAction): AuthState => {
  switch (action.type) {
    case LoginActions.SetUserProfile:
      return {
        ...state,
        isLoggedIn: true,
        userInfo: action.payload,
        attemptingLogin: false,
        attemptingRegister: false,
        loadingSessionInfo: false,
      };
    case LoginActions.AttemptLogin:
      return { ...state, isLoggedIn: false, attemptingLogin: true, loadingSessionInfo: false };
    case LoginActions.SetInitSessionInfo:
      return { ...state, isLoggedIn: false, attemptingLogin: true, loadingSessionInfo: true };
    case RegisterActions.AttemptRegister:
      return { ...state, isLoggedIn: false, attemptingRegister: true, loadingSessionInfo: false };
    case RegisterActions.SetError:
      return { ...state, isLoggedIn: false, attemptingRegister: false, errorRegister: true, loadingSessionInfo: false };
    case LoginActions.SetError:
      return { ...state, isLoggedIn: false, attemptingLogin: false, errorLogin: true, loadingSessionInfo: false };
    case LoginActions.Logout:
      return initialState;
    default:
      return state;
  }
};

export default reducer;
