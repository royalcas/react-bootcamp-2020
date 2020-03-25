export enum UserGender {
  Male = 'male',
  Female = 'female',
  Other = 'other',
}

export type UserProfileInfo = {
  name: string;
  gender: UserGender;
  email: string;
  avatarUrl: string;
  birthDate: Date;
};
