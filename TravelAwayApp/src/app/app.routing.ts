import { Routes, RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ViewPackagesComponent } from './view-packages/view-packages.component';
import { ViewPackageDetailsComponent } from './view-package-details/view-package-details.component';
import { AccomodationComponent } from './accomodation/accomodation.component';
import { BookPackageComponent } from './book-package/book-package.component';
import { BookingHistoryComponent } from './booking-history/booking-history.component';
import { GenerateReportComponent } from './generate-report/generate-report.component';


const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'viewPackages', component: ViewPackagesComponent },
  { path: 'viewPackageDetails/:packageId/:packageName', component: ViewPackageDetailsComponent },
  { path: 'accomodation', component: AccomodationComponent },
  { path: 'bookPackage/:packageDetailsId', component: BookPackageComponent },
  { path: 'bookingHistory', component: BookingHistoryComponent },
  { path: 'generateReport', component: GenerateReportComponent },
  { path: '**', component: LoginComponent } //wild card path
];

export const routing: ModuleWithProviders<RouterModule> = RouterModule.forRoot(routes);
// forRoot method accepts routes array and creates an object of type ModuleWithProviders 
