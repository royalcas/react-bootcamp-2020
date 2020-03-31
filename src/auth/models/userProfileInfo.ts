export enum UserGender {
  Other = 0,
  Male = 1,
  Female = 2,
}

export type UserProfileInfo = {
  id: string;
  firstName: string;
  lastName: string;
  gender: UserGender;
  email: string;
  avatarUrl: string;
  birthDate: Date;
};
