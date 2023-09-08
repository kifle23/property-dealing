import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../services/alertify.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css'],
})
export class NavBarComponent implements OnInit {
  loggedinUser: string | null = '';
  constructor(private alertify: AlertifyService) {}

  ngOnInit() {}

  loggedIn() {
    this.loggedinUser = localStorage.getItem('userName');
    return this.loggedinUser;
  }

  loggedOut() {
    localStorage.removeItem('token');
    localStorage.removeItem('userName');
    this.alertify.success('Logged Out');
  }
}
