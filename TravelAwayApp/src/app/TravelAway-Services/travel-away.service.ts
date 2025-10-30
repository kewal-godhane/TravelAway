import { ErrorHandler, Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ICategory } from '../TravelAway-Interface/Category';
import { IPackage } from '../TravelAway-Interface/Package';
import { ICustomer } from '../TravelAway-Interface/Customer';
import { ILogin } from '../TravelAway-Interface/Login';
import { IPackageDetails } from '../TravelAway-Interface/PackageDetails';
import { ICategoryCount } from '../TravelAway-Interface/CategoryCount';
import { IBookingCount } from '../TravelAway-Interface/BookingCount';
import { IBookPackage } from '../TravelAway-Interface/BookPackage';

@Injectable({
  providedIn: 'root'
})
export class TravelAwayService {

  constructor(private http: HttpClient) { }

  validateCredentials(login:ILogin): Observable<ICustomer> {
    let temp = this.http.post<ICustomer>('https://localhost:62782/api/Login/ValidateLoginDetails', login).pipe(catchError(this.errorHandler));
    return temp;
  }

  //for register
  addUserDetails(firstName: string, lastName: string, emailId: string,
    password: string, contactNumber: number, address: string, gender: string, dateOfBirth: Date, roleId: number): Observable<number> {
    var custObj: ICustomer;
    custObj = { emailId: emailId, userPassword: password, firstName: firstName, lastName: lastName, roleId: roleId, gender: gender, dateOfBirth: dateOfBirth, address: address, contactNumber: contactNumber };
    let temp = this.http.post<number>('https://localhost:62782/api/RegisterUser/AddCustomer', custObj).pipe(catchError(this.errorHandler));
    return temp;
  }

  getPackages(): Observable<IPackage[]> {
    let temp = this.http.get<IPackage[]>('https://localhost:62782/api/ViewAllPackages/GetPackages').pipe(catchError(this.errorHandler))
    return temp;
  }

  getCategories(): Observable<ICategory[]> {
    return this.http.get<ICategory[]>('https://localhost:62782/api/ViewAllPackages/GetPackageCategories').pipe(catchError(this.errorHandler));
  }

  getPackageDetails(packageId: number): Observable<IPackageDetails[]>
  {
    let params = '?id=' + packageId;
    let temp = this.http.get<IPackageDetails[]>('https://localhost:62782/api/PackageDetails'+params).pipe(catchError(this.errorHandler));
    return temp;
  }

  getNoOfPackageInCategory(): Observable<ICategoryCount[]> {
    return this.http.get<ICategoryCount[]>('https://localhost:62782/api/Reports/GetPackageCountByCateory').pipe(catchError(this.errorHandler));
  }

  getBookingCountByPackage(): Observable<IBookingCount[]> {
    return this.http.get<IBookingCount[]>('https://localhost:62782/api/Reports/GetBookingCountByPackage').pipe(catchError(this.errorHandler));
  }

  getBookingHistory(emailId: string): Observable<IBookPackage[]> {

    let params = "?emailId=" + emailId;
    var tempVar = this.http.get<IBookPackage[]>('https://localhost:62782/api/BookPackage/GetBookPackages'+ params).pipe(catchError(this.errorHandler));
    return tempVar;
  }

  addBooking(bookingDetails: IBookPackage): Observable<number> {
    var tempVar = this.http.post<number>('https://localhost:62782/api/BookPackage/BookPackage', bookingDetails).pipe(catchError(this.errorHandler));
    return tempVar;
  }

  errorHandler(error: HttpErrorResponse) {
    console.error(error);
    return throwError(error.message || "Server Error");
  }

}









