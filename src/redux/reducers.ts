import AuthReducer, { AuthState } from 'auth/+state/authReducer';
import { combineReducers } from 'redux';
import DashboardReducer, { DashboardState } from './../dashboard/+state/dashboardReducer';
import MedicalRecordReducer, { MedicalRecordState } from './../history/+state/medicalRecordReducer';

export type State = {
  auth: AuthState;
  medicalRecord: MedicalRecordState;
  dashboard: DashboardState;
};

export default combineReducers({ auth: AuthReducer, medicalRecord: MedicalRecordReducer, dashboard: DashboardReducer });
