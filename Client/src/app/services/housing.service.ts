import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs/internal/Observable';
import { Ipropertybase } from '../model/ipropertybase';
import { Property } from '../model/property';

interface PropertyData {
  [key: string]: any;
}

@Injectable({
  providedIn: 'root',
})
export class HousingService {
  constructor(private http: HttpClient) {}

  getAllProperties(SellRent: number): Observable<Ipropertybase[]> {
    return this.http.get<PropertyData>('data/properties.json').pipe(
      map((data) => {
        const propertiesArray: Array<Ipropertybase> = [];
        for (const id in data) {
          if (data.hasOwnProperty(id) && data[id].SellRent === SellRent) {
            propertiesArray.push(data[id]);
          }
        }
        return propertiesArray;
      })
    );
  }

  addProperty(property: Property) {
    localStorage.setItem('newProp', JSON.stringify(property));
  }

  newPropID() {
    const storedPID = localStorage.getItem('PID');
    if (storedPID) {
      const currentPID = storedPID as string;
      const newPID = String((+currentPID ?? 0) + 1);
      localStorage.setItem('PID', newPID);
      return +newPID;
    } else {
      localStorage.setItem('PID', '101');
      return 101;
    }
  }
}
