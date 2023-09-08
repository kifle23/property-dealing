import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { UserForLogin } from '../model/user';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  baseUrl = environment.baseUrl;
  constructor(private http: HttpClient) {}

  authUser(user: UserForLogin) {
    return this.http.post<any>(this.baseUrl + '/account/login', user);
  }
}
