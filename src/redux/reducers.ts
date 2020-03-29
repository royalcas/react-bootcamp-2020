import AuthReducer, { AuthState } from 'auth/+state/authReducer';
import { combineReducers } from 'redux';
import MedicalRecordReducer, { MedicalRecordState } from './../history/+state/medicalRecordReducer';

export type State = {
  auth: AuthState;
  medicalRecord: MedicalRecordState;
};

export default combineReducers({ auth: AuthReducer, medicalRecord: MedicalRecordReducer });
