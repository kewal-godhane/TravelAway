import { Component, OnInit } from '@angular/core';
import { TravelAwayService } from '../TravelAway-Services/travel-away.service';
import { Route, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { ICustomer } from '../TravelAway-Interface/Customer';
import { ILogin } from '../TravelAway-Interface/Login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  status: boolean = false;
  errorMsg: string = "";
  msg: string = "";
  login!: ILogin;
  customer!: ICustomer;
  constructor(private _service: TravelAwayService, private router: Router) {

  }
  ngOnInit() {
  }
  submitLoginForm(emailId:string, password: string) {
    this.login = {
      UserPassword:password,
      EmailId:emailId
    }
    this._service.validateCredentials(this.login).subscribe(
      responeLogin => {
        this.customer = responeLogin;
        if (this.customer == null) {
          this.status = true;
          this.msg = "Wrong Credentials Entered";
        }
        else {
          this.status = false;
          sessionStorage.setItem('EmailId', this.customer.emailId);
          sessionStorage.setItem('FirstName', this.customer.firstName);
          sessionStorage.setItem('LastName', this.customer.lastName);
          sessionStorage.setItem('RoleId', this.customer.roleId.toString());
          this.router.navigate(['/home']);
        }
      },
      responseError => {
        this.errorMsg = responseError;
        alert('Some Error Occured');
      },
      () => console.log("Login completed succesfully")
    );
  }

}
