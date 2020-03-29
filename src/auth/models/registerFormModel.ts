import { UserGender } from './userProfileInfo';

export type RegisterFormModel = {
  firstName: string;
  lastName: string;
  gender: UserGender;
  email: string;
  avatarUrl: string;
  birthDate: Date;
  password: string;
};
