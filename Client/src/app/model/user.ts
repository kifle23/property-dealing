export interface UserForRegistration {
  username: string;
  email?: string;
  password: string;
  mobile?: number;
}

export interface UserForLogin {
  username: string;
  password: string;
  token: string;
}
