import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserForLogin } from 'src/app/model/user';
import { AlertifyService } from 'src/app/services/alertify.service';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css'],
})
export class UserLoginComponent implements OnInit {
  constructor(
    private authService: AuthService,
    private alertify: AlertifyService,
    private router: Router
  ) {}

  ngOnInit() {}

  onLogin(loginForm: NgForm) {
    this.authService.authUser(loginForm.value).subscribe(
      (response: UserForLogin) => {
        const user = response;
        localStorage.setItem('token', user.token);
        localStorage.setItem('userName', user.username);
        this.alertify.success('Login Successful');
        this.router.navigate(['/']);
      },
      (error) => {
        this.alertify.error('Login Failed');
      }
    );
  }
}
