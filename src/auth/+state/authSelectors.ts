import { State } from 'redux/reducers';
import { createSelector } from 'reselect';

export const authStateSelector = (state: State) => state.auth;

export const isLoggedInSelector = createSelector(authStateSelector, authState => authState?.isLoggedIn);

export const currentUserSelector = createSelector(authStateSelector, authState => authState?.userInfo);

export const currentUserIdSelector = createSelector(currentUserSelector, userInfo => userInfo?.id);

export const isLoadingSessionInfoSelector = createSelector(
  authStateSelector,
  authState => authState.loadingSessionInfo,
);
