import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { IProperty } from '../property/IProperty';
import { Observable } from 'rxjs/internal/Observable';

interface PropertyData {
  [key: string]: any;
}

@Injectable({
  providedIn: 'root'
})
export class HousingService {

  constructor(private http: HttpClient) { }

  getAllProperties(): Observable<IProperty[]> {
    return this.http.get<PropertyData>('data/properties.json').pipe(
        map(data => {
          const propertiesArray: Array<IProperty> = [];
          for (const id in data) {
            if (data.hasOwnProperty(id)) {
              propertiesArray.push(data[id]);
            }
          }
          return propertiesArray;
        })  
    );
  }
}