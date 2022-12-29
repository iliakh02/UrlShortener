import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

import { Url } from '../models/url';

@Injectable({
  providedIn: 'root',
})
export class UrlService {
  apiUri: string = 'https://localhost:7126/api/urls';
  constructor(private http: HttpClient) {}

  getAllUrls(): Observable<Url[]> {
    return this.http
      .get<Url[]>(`${this.apiUri}`)
      .pipe(catchError(this.handleError));
  }

  createNewUrl(url: string): Observable<any> {
    return this.http
      .post(`${this.apiUri}/create`, { fullUrl: url })
      .pipe(catchError(this.handleError));
  }

  deleteAllUrls(): Observable<any> {
    return this.http
      .delete(`${this.apiUri}/deleteAll`)
      .pipe(catchError(this.handleError));
  }

  deleteUrl(id: number): Observable<any> {
    return this.http
      .delete(`${this.apiUri}/delete/${id}`)
      .pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.error('An error occurred:', error.error.message);
      alert(`An error occurred:${error.error.message}`);
    } else {
      console.error(
        `Backend returned code ${error.status}, ` + `body was: ${error.error}`
      );
      alert(`An error occurred:${error.error.message}`);
    }

    return throwError('Something bad happened. Please try again later.');
  }
}
