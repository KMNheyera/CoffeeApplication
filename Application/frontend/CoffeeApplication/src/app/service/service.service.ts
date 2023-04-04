import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, filter } from 'rxjs/operators';
import { ICart } from '../interfaces/cart';
import { IPayment } from '../interfaces/payment';
import { IUser } from '../interfaces/user';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {

  url = "https://localhost:44307/api"
  constructor(
      private http: HttpClient,
  ) { }

  GetPointsSettings(): Observable<any> {
    return this.http.get(`${this.url}/PointsSettings`).pipe(
      catchError(this.handleError)
    );
  }

  GetProducts(): Observable<any> {
    return this.http.get(`${this.url}/Product`).pipe(
      catchError(this.handleError)
    );
  }

   GetUsers(): Observable<any> {
    return this.http.get(`${this.url}/User`).pipe(
      catchError(this.handleError)
    );
  }

  SignIn(email:string): Observable<any> {
    return this.http.get(`${this.url}/User/SignIn/${email}`).pipe(
      catchError(this.handleError)
    );
  }

  GetUser(id: string): Observable<any> {
    return this.http.get(`${this.url}/User/${id}`).pipe(
      catchError(this.handleError)
    );
  }

  AddUser(obj: IUser): Observable<any>{
    return this.http.post(`${this.url}/User`, obj).pipe(
      catchError(this.handleError)
    );
  }

   Payment(obj: IPayment): Observable<any>{
    return this.http.post(`${this.url}/Product/Payment`, obj).pipe(
      catchError(this.handleError)
    );
  }

  handleError(error: HttpErrorResponse) {
    console.log('error.status', error.status)
    return throwError(error);
  }
}
