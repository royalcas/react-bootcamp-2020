import AuthReducer, { AuthState } from 'auth/+state/reducers';
import { combineReducers } from 'redux';

export type State = {
  auth: AuthState;
};

export default combineReducers({ auth: AuthReducer });
