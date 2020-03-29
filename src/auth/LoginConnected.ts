import { connect } from 'react-redux';
import { login } from './+state/actionCreators';
import { authStateSelector } from './+state/authSelectors';
import { LoginForm } from './components/LoginForm';
import { Credentials } from './models/credentials';

const mapDispatchToProps = (dispatch: any) => ({
  onLogin: (credentials: Credentials) => dispatch(login(credentials)),
});

export default connect(authStateSelector, mapDispatchToProps)(LoginForm);
