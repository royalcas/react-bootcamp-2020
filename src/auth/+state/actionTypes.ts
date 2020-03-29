export enum LoginActions {
  AttemptLogin = '[Auth Login] Attempt Login',
  SetInitSessionInfo = '[Auth Login] init Session Info',
  SetUserProfile = '[Auth Login] Set Current User Profile',
  SetError = '[Auth Login] Set Error Response',
  Logout = '[Auth Login] Logout',
}

export enum RegisterActions {
  AttemptRegister = '[Auth Register] Attempt Register',
  SetError = '[Auth Register] Set Error Response',
}
