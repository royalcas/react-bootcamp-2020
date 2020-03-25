import { AnyAction } from 'redux';
import { LoginActions } from './actionTypes';

export type AuthState = {
  isLoggedIn: boolean;
  userInfo: any;
};

export const initialState: AuthState = {
  isLoggedIn: false,
  userInfo: {},
};

export const reducer = (state: AuthState = initialState, action: AnyAction): AuthState => {
  switch (action.type) {
    case LoginActions.SetLoginResponse:
      return { ...state, isLoggedIn: true, userInfo: action.payload };
    case LoginActions.AttemptLogin:
      return { ...state, isLoggedIn: true };
    default:
      return state;
  }
};

export default reducer;
