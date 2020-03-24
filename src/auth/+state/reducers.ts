import { AnyAction } from 'redux';

export type AuthState = {
  isLoggedIn: boolean;
  userInfo: any;
};

export const initialState: AuthState = {
  isLoggedIn: false,
  userInfo: {},
};

export const reducer = (state: AuthState = initialState, action: AnyAction) => {};

export default reducer;
