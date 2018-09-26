import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/observable';
import { of } from 'rxjs/observable/of';
import { catchError, map, tap } from 'rxjs/operators';
import { CloudData, CloudOptions } from 'angular-tag-cloud-module';

@Injectable()
export class TagService {

  private apiUrl = 'api/tag';  // URL to web api

  constructor(private http: HttpClient) { };

  getTagCloudData(parentTypeId: number): Observable<CloudData[]> {
    const url = `${this.apiUrl}/GetTagCloudData/${parentTypeId}`;
    return this.http.get<CloudData[]>(url)
      .pipe(
        //tap(_ => this.log(`fetched hero id=${id}`)),
      catchError(this.handleError<CloudData[]>(`GetTagCloudData$ parentTypeId=${parentTypeId}`))
      );
  }

  /**
* Handle Http operation that failed.
* Let the app continue.
* @param operation - name of the operation that failed
* @param result - optional value to return as the observable result
*/
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  log(message: string) {
    //this.messageService.add('HeroService: ' + message);
    console.log('HeroService: ' + message);
  }

}
