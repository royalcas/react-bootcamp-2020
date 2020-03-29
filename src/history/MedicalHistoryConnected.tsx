import { Dispatch } from 'react';
import { connect } from 'react-redux';
import { resquestMedicalRecord } from './+state/medicalRecordActionCreators';
import { medicalRecordState } from './+state/medicalRecordSelectors';
import { MedicalHistory } from './MedicalHistory';

const mapDispatchToProps = (dispatch: Dispatch<any>) => ({
  onInit: () => dispatch(resquestMedicalRecord()),
});

export default connect(medicalRecordState, mapDispatchToProps)(MedicalHistory);
