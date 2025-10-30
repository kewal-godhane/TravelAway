import { Component, OnInit } from '@angular/core';
import { IPackage } from '../TravelAway-Interface/Package';
import { ICustomer } from '../TravelAway-Interface/Customer';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { TravelAwayService } from '../TravelAway-Services/travel-away.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  msg!: string;
  showDiv!: boolean;
  errorMsg!: string;
  status!: number;
  password: string = "";
  confirmPassword: string = "";
  todayDate: string = new Date(new Date().setDate(new Date().getDate() - 1)).toISOString().split('T')[0];
  constructor(private TravelAwayService: TravelAwayService, private router: Router) {
  }

  ngOnInit() {
    console.log(this.password);
    console.log(this.confirmPassword);

  }

  SubmitForm(form: NgForm) {
    var email = form.value.emailId;
    this.TravelAwayService.addUserDetails(form.value.firstName, form.value.lastName, form.value.emailId,
      form.value.password, parseInt(form.value.contactNumber), form.value.address, form.value.gender,new Date(form.value.dateOfBirth), 1).subscribe(
        responseRegisterStatus => {
          this.status = responseRegisterStatus;
          this.showDiv = true;
          if (this.status == 1) {
            this.msg = "Registered Successfully";
            sessionStorage.setItem('EmailId', form.value.emailId);
            sessionStorage.setItem('FirstName', form.value.firstName);
            sessionStorage.setItem('LastName', form.value.lastName);
            this.router.navigate(['/home']);
          } else {
            this.msg = "Not able to register";
          }
        },
        responseRegisterError => {
          this.errorMsg = responseRegisterError;
          console.log(responseRegisterError)
          alert("Some Error Occured");
        },
        () => console.log("SubmitLoginForm method executed successfully")
      );
  }
}
