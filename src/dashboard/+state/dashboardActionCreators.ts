import { Tip } from 'dashboard/model/tip';
import { Action, AnyAction } from 'redux';
import { ThunkAction } from 'redux-thunk';
import { State } from 'redux/reducers';
import { FluxAction } from './../../redux/FluxAction';
import { ActivityApi } from './../api/ActivityApi';
import { TipsApi } from './../api/TipsApi';
import { Activity } from './../model/activity';
import { DashboardActionTypes } from './dashboardActionTypes';

export const fetchDashboard = () => ({
  type: DashboardActionTypes.FetchDashboardInfo,
});

export const fetchMyActivities = () => ({
  type: DashboardActionTypes.FetchMyActivities,
});

export const fetchSuggestedActivities = () => ({
  type: DashboardActionTypes.FetchSuggestedActivities,
});

export const fetchTip = () => ({
  type: DashboardActionTypes.FetchTip,
});

export const setMyActivities = (activities: Activity[]): FluxAction<DashboardActionTypes, Activity[]> => ({
  type: DashboardActionTypes.SetMyActivities,
  payload: activities,
});

export const setSuggestedActivities = (activities: Activity[]): FluxAction<DashboardActionTypes, Activity[]> => ({
  type: DashboardActionTypes.SetSuggestedActivities,
  payload: activities,
});

export const setTip = (tip: Tip): FluxAction<DashboardActionTypes, Tip> => ({
  type: DashboardActionTypes.SetTip,
  payload: tip,
});

export const setError = (): Action<DashboardActionTypes> => ({
  type: DashboardActionTypes.SetError,
});

export const requestDashboardInfo = (): ThunkAction<void, State, AnyAction, Action<DashboardActionTypes>> => {
  console.log('requestDashboardInfo');
  return async dispatch => {
    console.log('requestDashboardInfo2');
    dispatch(fetchDashboard());
    dispatch(requestMyActivities());
    dispatch(requestSubscribedActivities());
    dispatch(requestTip());
  };
};

export const requestMyActivities = (): ThunkAction<void, State, AnyAction, Action<DashboardActionTypes>> => {
  const activityApi = new ActivityApi();
  console.log('requestMyActivities');
  return async dispatch => {
    console.log('requestMyActivities1');
    dispatch(fetchMyActivities());
    try {
      const activities = await activityApi.getSubscribedActivities();
      dispatch(setMyActivities(activities));
    } catch (error) {
      dispatch(setError());
    }
  };
};

export const requestSubscribedActivities = (): ThunkAction<void, State, AnyAction, Action<DashboardActionTypes>> => {
  const activityApi = new ActivityApi();
  return async dispatch => {
    dispatch(fetchSuggestedActivities());
    try {
      const activities = await activityApi.getSuggestedActivities();
      dispatch(setSuggestedActivities(activities));
    } catch (error) {
      dispatch(setError());
    }
  };
};

export const requestTip = (): ThunkAction<void, State, AnyAction, Action<DashboardActionTypes>> => {
  const tipApi = new TipsApi();
  return async dispatch => {
    dispatch(fetchTip());
    try {
      const tip = await tipApi.getMyTip();
      dispatch(setTip(tip));
    } catch (error) {
      dispatch(setError());
    }
  };
};
