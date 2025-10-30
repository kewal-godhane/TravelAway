import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { CommonLayoutComponent } from './common-layout/common-layout.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ViewPackagesComponent } from './view-packages/view-packages.component';
import { ViewPackageDetailsComponent } from './view-package-details/view-package-details.component';
import { routing } from './app.routing';
import { UserLayoutComponent } from './user-layout/user-layout.component';
import { TravelAwayService } from './TravelAway-Services/travel-away.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BookPackageComponent } from './book-package/book-package.component';
import { AccomodationComponent } from './accomodation/accomodation.component';
import { GenerateReportComponent } from './generate-report/generate-report.component';
import { BookingHistoryComponent } from './booking-history/booking-history.component';
import { EmployeeLayoutComponent } from './employee-layout/employee-layout.component';
@NgModule({
  declarations: [
    AppComponent,
    CommonLayoutComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    ViewPackagesComponent,
    ViewPackageDetailsComponent,
    UserLayoutComponent,
    BookPackageComponent,
    AccomodationComponent,
    GenerateReportComponent,
    BookingHistoryComponent,
    EmployeeLayoutComponent
  ],
  imports: [
    BrowserModule, routing, HttpClientModule, FormsModule
  ],
  providers: [TravelAwayService],
  bootstrap: [AppComponent]
})
export class AppModule { }
