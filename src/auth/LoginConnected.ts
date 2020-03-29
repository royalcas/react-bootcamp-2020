import { connect } from 'react-redux';
import { attemptLogin } from './+state/actionCreators';
import { authStateSelector } from './+state/authSelectors';
import { LoginForm } from './components/LoginForm';
import { Credentials } from './models/credentials';

const mapDispatchToProps = (dispatch: any) => ({
  onLogin: (credentials: Credentials) => dispatch(attemptLogin()),
});

export default connect(authStateSelector, mapDispatchToProps)(LoginForm);
