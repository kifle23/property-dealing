/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { HousingService } from './housing.service';

describe('Service: Housing', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [HousingService]
    });
  });

  it('should ...', inject([HousingService], (service: HousingService) => {
    expect(service).toBeTruthy();
  }));
});
