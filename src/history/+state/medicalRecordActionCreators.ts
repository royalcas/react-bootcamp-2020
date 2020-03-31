import { currentUserIdSelector } from 'auth/+state/authSelectors';
import { MedicalRecordItem } from 'history/models/MedicalRecordItem';
import { Action, AnyAction } from 'redux';
import { ThunkAction } from 'redux-thunk';
import { State } from 'redux/reducers';
import { FluxAction } from './../../redux/FluxAction';
import { MedicalRecordApi } from './../api/MedicalHistoryApi';
import { MedicalRecordActionTypes } from './medicalRecordActionTypes';

export const setRequestMedicalRecord = (): Action<MedicalRecordActionTypes> => {
  return {
    type: MedicalRecordActionTypes.RequestMedicalRecord,
  };
};

export const setMedicalRecord = (
  medicalRecord: MedicalRecordItem[],
): FluxAction<MedicalRecordActionTypes, MedicalRecordItem[]> => {
  return {
    type: MedicalRecordActionTypes.SetMedicalRecord,
    payload: medicalRecord,
  };
};

export const errorMedicalRecord = (): Action<MedicalRecordActionTypes> => {
  return {
    type: MedicalRecordActionTypes.ErrorMedicalRecord,
  };
};

export const resquestMedicalRecord = (): ThunkAction<void, State, AnyAction, Action<MedicalRecordActionTypes>> => {
  const api = new MedicalRecordApi();
  return async dispatch => {
    dispatch(setRequestMedicalRecord());

    try {
      const medicalRecord = await api.getMedicalRecord();
      dispatch(setMedicalRecord(medicalRecord));
    } catch (error) {
      dispatch(errorMedicalRecord());
    }
  };
};

export const addCurrentUserMedicalRecord = (
  medicalRecordForm: MedicalRecordItem,
): ThunkAction<void, State, AnyAction, Action<MedicalRecordActionTypes>> => {
  const api = new MedicalRecordApi();
  return async (dispatch, getState) => {
    const currentUserId = currentUserIdSelector(getState());

    try {
      await api.addMedicalRecord(medicalRecordForm, currentUserId);
      dispatch(resquestMedicalRecord());
    } catch (error) {
      dispatch(errorMedicalRecord());
    }
  };
};
