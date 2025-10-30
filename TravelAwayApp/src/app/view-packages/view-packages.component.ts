import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TravelAwayService } from '../TravelAway-Services/travel-away.service';
import { IPackage } from '../TravelAway-Interface/Package';
import { ICategory } from '../TravelAway-Interface/Category';

@Component({
  selector: 'app-view-packages',
  templateUrl: './view-packages.component.html',
  styleUrls: ['./view-packages.component.css']
})
export class ViewPackagesComponent implements OnInit {
    packages!: IPackage[];
    categories!: ICategory[];
    filteredPackages!: IPackage[];
    errorMsg!: string;
    showMsg!: boolean;
    imagePath!: string;
    userRole!: string;
  constructor(private packageService: TravelAwayService, private router: Router) {

  }
  ngOnInit() {
    if (!sessionStorage.getItem('EmailId')) {
      this.router.navigate(['/login'])
    }
    this.getPackages();
    this.getCategories();
  }
  getPackages() {
    this.packageService.getPackages().subscribe(
      responseGet => {
        this.showMsg = false;
        this.packages = responseGet;
        this.filteredPackages = responseGet
      },
      resonseError => {
        this.showMsg = true
        this.errorMsg = resonseError
      },
      () => console.log("GetPackage method executed")
    )
  }
  getCategories() {
    this.packageService.getCategories().subscribe(
      responseGet => {
        this.categories = responseGet
        console.log(this.categories)
      },
      responseError => {
        this.errorMsg = responseError
      },
      () => console.log("Get categories executed")
    )
  }
  searchPackageByCategory(categoryId: string) {
    console.log(categoryId)
    this.filteredPackages = this.packages;
    var catid = parseInt(categoryId)
    if (catid > 0) {
      this.filteredPackages = this.filteredPackages.filter(prod => prod.packageCategoryId == catid);
    }
    console.log(this.filteredPackages);
  }
  viewPackageDetails(packageId: number, packageName: string) {
    console.log(packageId);
    this.router.navigate(['viewPackageDetails', packageId, packageName]);
  }
}

