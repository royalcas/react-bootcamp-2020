import { AnyAction } from 'redux';
import { LoginActions, RegisterActions } from './actionTypes';

export type AuthState = {
  attemptingLogin?: boolean;
  attemptingRegister?: boolean;
  errorLogin?: boolean;
  errorRegister?: boolean;
  isLoggedIn: boolean;
  userInfo: any;
};

export const initialState: AuthState = {
  isLoggedIn: false,
  userInfo: {},
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
      };
    case LoginActions.AttemptLogin:
      return { ...state, isLoggedIn: false, attemptingLogin: true };
    case RegisterActions.AttemptRegister:
      return { ...state, isLoggedIn: false, attemptingRegister: true };
    case RegisterActions.SetError:
      return { ...state, isLoggedIn: false, errorRegister: true };
    case LoginActions.SetError:
      return { ...state, isLoggedIn: false, errorLogin: true };
    default:
      return state;
  }
};

export default reducer;
