import { MedicalRecordItem } from 'history/models/MedicalRecordItem';
import { FluxAction } from 'redux/FluxAction';
import { PageState } from 'redux/PageState';
import { MedicalRecordActionTypes } from './medicalRecordActionTypes';

export type MedicalRecordState = PageState<MedicalRecordItem[]>;

export const initialState: MedicalRecordState = {
  isLoading: true,
  hasErrors: false,
  pageData: [],
};

export const reducer = (
  state: MedicalRecordState = initialState,
  action: FluxAction<MedicalRecordActionTypes, MedicalRecordItem[]>,
): MedicalRecordState => {
  switch (action.type) {
    case MedicalRecordActionTypes.RequestMedicalRecord:
      return initialState;
    case MedicalRecordActionTypes.SetMedicalRecord:
      return { ...state, isLoading: false, pageData: action.payload };
    case MedicalRecordActionTypes.ErrorMedicalRecord:
      return { ...state, isLoading: false, hasErrors: false };
    default:
      return state;
  }
};

export default reducer;
