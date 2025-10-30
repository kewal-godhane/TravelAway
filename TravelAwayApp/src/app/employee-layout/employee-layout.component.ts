import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-employee-layout',
  templateUrl: './employee-layout.component.html',
  styleUrls: ['./employee-layout.component.css']
})
export class EmployeeLayoutComponent {

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
