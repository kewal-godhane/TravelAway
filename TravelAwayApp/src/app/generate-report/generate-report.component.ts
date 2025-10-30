import { Component, OnInit } from '@angular/core';
import { TravelAwayService } from '../TravelAway-Services/travel-away.service';
import { ICategoryCount } from '../TravelAway-Interface/CategoryCount';
import { IBookingCount } from '../TravelAway-Interface/BookingCount';
import { Router } from '@angular/router';

@Component({
  selector: 'app-generate-report',
  templateUrl: './generate-report.component.html',
  styleUrls: ['./generate-report.component.css']
})
export class GenerateReportComponent implements OnInit {
  selectedReport: string = '';

  bookingsData: IBookingCount[] = [];
  packagesData: ICategoryCount[] = [];
  constructor(private _services: TravelAwayService, private router: Router) {

  }

  ngOnInit() {
    if (!sessionStorage.getItem('EmailId')) {
      this.router.navigate(['/login'])
    }
    this.getNoOfPackageInCategory();
    this.getBookingCountByPackage();
  }

  getNoOfPackageInCategory() {
    this._services.getNoOfPackageInCategory().subscribe(
      response => {
        this.packagesData = response
      },
      errorResponse => {
        this.packagesData = []
      },
      () => {
        console.log("getNoOfPackageInCategory completed successfully")
      }
    )
  }

  getBookingCountByPackage() {
    this._services.getBookingCountByPackage().subscribe(
      response => {
        this.bookingsData = response
      },
      errorResponse => {
        this.bookingsData = []
      },
      () => {
        console.log("getBookingCountByPackage completed successfully")
      }
    )
  }
}
