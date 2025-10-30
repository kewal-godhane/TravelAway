import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-layout',
  templateUrl: './user-layout.component.html',
  styleUrls: ['./user-layout.component.css']
})
export class UserLayoutComponent implements OnInit {
  firstName: string = "";
  lastName: string = "";
  constructor(private router: Router) {
  }
  ngOnInit() {
    this.firstName = sessionStorage.getItem('FirstName') || "";
    this.lastName = sessionStorage.getItem('LastName') || "";
  }

  logOut() {
    alert
    sessionStorage.removeItem('EmailId')
    sessionStorage.removeItem('FirstName')
    sessionStorage.removeItem('LastName')

    this.router.navigate(['/login'])
  }
}
