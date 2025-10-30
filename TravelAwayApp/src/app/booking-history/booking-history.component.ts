import { Component, OnInit } from '@angular/core';
import { IBookPackage } from '../TravelAway-Interface/BookPackage';
import { TravelAwayService } from '../TravelAway-Services/travel-away.service';

@Component({
  selector: 'app-booking-history',
  templateUrl: './booking-history.component.html',
  styleUrls: ['./booking-history.component.css']
})
export class BookingHistoryComponent implements OnInit {
  bookingHistory!: IBookPackage[];
  errorMsg!: string;
  emailId!: string;
  showError!: boolean;
  constructor(private service: TravelAwayService) {

  }
  ngOnInit() {
    this.emailId = sessionStorage.getItem('EmailId')?.toString() || "";
    this.getBookingHistory(this.emailId);
  }

  getBookingHistory(email: string) {
    this.service.getBookingHistory(email).subscribe(
      responseGetBookingDetails => {
        this.bookingHistory = responseGetBookingDetails;
        if (this.bookingHistory == null || this.bookingHistory.length <= 0) {
          this.errorMsg = "No Bookings Found";
          this.showError = true;
        }
        this.showError = false;
      },
      responseGetBookingError => {
        this.bookingHistory = [];
        this.showError = true;
        this.errorMsg = responseGetBookingError;
      },
      () => {
        console.log("GetBookingHistory successfully executed")
      }
    )
  }
}
