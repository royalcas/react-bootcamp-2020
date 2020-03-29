import { connect } from 'react-redux';
import { authStateSelector } from './+state/authSelectors';
import { register } from './+state/registerActionCreators';
import { RegisterForm } from './components/RegisterForm';
import { RegisterFormModel } from './models/registerFormModel';

const mapDispatchToProps = (dispatch: any) => ({
  onRegister: (registerForm: RegisterFormModel) => dispatch(register(registerForm)),
});

export default connect(authStateSelector, mapDispatchToProps)(RegisterForm);
