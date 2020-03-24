import { State } from 'redux/reducers';
import { createSelector } from 'reselect';
export const authStateSelector = (state: State) => state.auth;
export const isLoggedInSelector = createSelector(authStateSelector, authState => authState.isLoggedIn);
