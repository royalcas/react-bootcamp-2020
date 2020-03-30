import { State } from 'redux/reducers';
import { createSelector } from 'reselect';

export const dashboardStateSelector = (state: State) => state.dashboard;

export const myActivitiesSelector = createSelector(dashboardStateSelector, state => state.pageData?.myActivities);

export const suggestedSelector = createSelector(dashboardStateSelector, state => state.pageData?.suggestedAcivities);

export const tipSelector = createSelector(dashboardStateSelector, state => state.pageData?.tip);
