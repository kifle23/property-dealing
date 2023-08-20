import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  Resolve,
  Router,
  RouterStateSnapshot,
} from '@angular/router';
import { Observable, catchError } from 'rxjs';
import { Property } from 'src/app/model/property';
import { HousingService } from 'src/app/services/housing.service';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class PropertyDetailResolverService implements Resolve<Property> {
  constructor(private router: Router, private housingService: HousingService) {}

  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<Property> | Promise<Property> | Property {
    const id = route.params['id'];
    return this.housingService.getProperty(+id).pipe(
      map((property: Property | undefined) => {
        if (!property) {
          throw new Error('Property not found');
        }
        return property;
      }),
      catchError((error) => {
        this.router.navigate(['/']);
        throw error;
      })
    ) as Observable<Property> | Promise<Property> | Property;
  }
}
