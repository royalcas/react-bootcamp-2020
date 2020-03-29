import Credentials from 'auth/models/credentials';
import { LoginResponse } from 'auth/models/loginResponse';
import { UserProfileInfo } from 'auth/models/userProfileInfo';
import { AuthTokenManager } from 'shared/api/authTokenManager';
import { Http } from 'shared/api/http';
import { RegisterFormModel } from './../models/registerFormModel';

export class AuthApi {
  private readonly _http: Http;
  private readonly _authTokenManager: AuthTokenManager;

  constructor() {
    this._http = new Http();
    this._authTokenManager = new AuthTokenManager();
  }

  async login(credentials: Credentials) {
    const loginResponse = await this._http.post<LoginResponse>('account/login', credentials);
    this._authTokenManager.setToken(loginResponse.token);
    return await this.getCurrentUserProfileInfo();
  }

  async getCurrentUserProfileInfo(): Promise<UserProfileInfo> {
    return await this._http.get<UserProfileInfo>('account/profile');
  }

  async register(registerForm: RegisterFormModel) {
    const registerResponse = await this._http.post<LoginResponse>('account/register', registerForm);
    this._authTokenManager.setToken(registerResponse.token);
    return await this.getCurrentUserProfileInfo();
  }
}
