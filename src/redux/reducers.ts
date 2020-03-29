import AuthReducer, { AuthState } from 'auth/+state/authReducer';
import { combineReducers } from 'redux';

export type State = {
  auth: AuthState;
};

export default combineReducers({ auth: AuthReducer });
