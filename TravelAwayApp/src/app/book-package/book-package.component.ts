import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { TravelAwayService } from '../TravelAway-Services/travel-away.service';
import { NgForm } from '@angular/forms';
import { IBookPackage } from '../TravelAway-Interface/BookPackage';

@Component({
  selector: 'app-book-package',
  templateUrl: './book-package.component.html',
  styleUrls: ['./book-package.component.css']
})
export class BookPackageComponent implements OnInit {
  bookingDetails!: IBookPackage;
  msg!: string;
  showDiv!: boolean;
  errorMsg!: string;
  status!: string;
  packageId!: number;
  emailId!: string;
  bookingId!: number;
  todayDate: string = new Date().toISOString().split('T')[0];

  constructor(private route: ActivatedRoute, private router: Router, private service: TravelAwayService ) {
  }
  ngOnInit() {
    if (!sessionStorage.getItem('EmailId')) {
      this.router.navigate(['/login'])
    }
    this.emailId = sessionStorage.getItem('EmailId')?.toString() || "";
    this.status = "Booked";
    this.packageId = this.route.snapshot.params['packageDetailsId'];
  }
  SubmitForm(form: NgForm) {
    this.bookingDetails = {
      emailId: this.emailId,
      status: this.status,
      packageId: this.packageId,
      contactNumber: parseInt(form.value.contactNumber),
      address: form.value.address,
      dateOfTravel: new Date(form.value.dateofTravel),
      numberOfAdults: form.value.NoOfAdults,
      numberOfChildren: form.value.NoOfChildren,
      bookingId: 0
    }
    this.service.addBooking(this.bookingDetails).subscribe(
      responseAddBooking => {
        this.bookingId = responseAddBooking;
        if (this.bookingId < 0) {
          console.log("Some Error Occured");
        }
        else {
          sessionStorage.setItem('bookingId', this.bookingId.toString());
          if (confirm("Booking Done Successfully. Do you want to continue to book accomodation?")) {
            this.router.navigate(['/accomodation']);
          }
          else {
            this.router.navigate(['/bookingHistory']);
          }
        }
      },
      responseAddBookingError => {
        this.errorMsg = responseAddBookingError;
      },
      () => {
        console.log("Booking Package method executed successfully");
      }
    )
  }
}
