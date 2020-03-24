export enum UserGender {
  Male = 'male',
  Female = 'female',
  Undefined = 'undefined',
}

export type UserProfileInfo = {
  name: string;
  gender: UserGender;
  email: string;
  avatarUrl: string;
  birthDate: Date;
};
