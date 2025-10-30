import { Component, OnInit } from '@angular/core';
import { IPackageDetails } from '../TravelAway-Interface/PackageDetails';
import { Router, ActivatedRoute } from '@angular/router';
import { TravelAwayService } from '../TravelAway-Services/travel-away.service';

@Component({
  selector: 'app-view-package-details',
  templateUrl: './view-package-details.component.html',
  styleUrls: ['./view-package-details.component.css']
})
export class ViewPackageDetailsComponent implements OnInit {
  packageDetails!: IPackageDetails[];
  packageId: number=0;
  errorMsg!: string;
  packageName!: string;
  constructor(private _service: TravelAwayService,private route: ActivatedRoute, private router:Router ) { }
  ngOnInit() {
    if (!sessionStorage.getItem('EmailId')) {
      this.router.navigate(['/login'])
    }
    this.packageId = this.route.snapshot.params['packageId'];
    this.packageName = this.route.snapshot.params['packageName'];
    console.log(this.packageId);
    this.getPackageDetails();
  }

  getPackageDetails() {
    //To do implement necessary logic
    this._service.getPackageDetails(this.packageId).subscribe(
      responseData => {
        this.packageDetails = responseData;
        console.log(this.packageDetails);
      },
      responseGetDoctorError => {
        this.packageDetails = [];
        this.errorMsg = responseGetDoctorError;
      },
      () => {
        console.log("package details Fetched Successfully");
      }
    )
  }
  bookPackageRedirect(packageDetailsId: number) {
    this.router.navigate(['/bookPackage', packageDetailsId])
  }
}
