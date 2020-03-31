import { Dispatch } from 'react';
import { connect } from 'react-redux';
import { addCurrentUserMedicalRecord, resquestMedicalRecord } from './+state/medicalRecordActionCreators';
import { medicalRecordState } from './+state/medicalRecordSelectors';
import { MedicalHistory } from './MedicalHistory';
import { MedicalRecordItem } from './models/MedicalRecordItem';

const mapDispatchToProps = (dispatch: Dispatch<any>) => ({
  onInit: () => dispatch(resquestMedicalRecord()),
  onNewMedicalRecord: (medicalRecord: MedicalRecordItem) => dispatch(addCurrentUserMedicalRecord(medicalRecord)),
});

export default connect(medicalRecordState, mapDispatchToProps)(MedicalHistory);
