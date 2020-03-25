import { connect } from 'react-redux';
import { attemptLogin } from './+state/actionCreators';
import { authStateSelector } from './+state/authSelectors';
import { RegisterForm } from './components/RegisterForm';
import { Credentials } from './models/credentials';
const mapDispatchToProps = (dispatch: any) => ({
  onLogin: (credentials: Credentials) => dispatch(attemptLogin()),
});

export default connect(authStateSelector, mapDispatchToProps)(RegisterForm);
