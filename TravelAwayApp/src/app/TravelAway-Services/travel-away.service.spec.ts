import { TestBed } from '@angular/core/testing';

import { TravelAwayService } from './travel-away.service';

describe('TravelAwayService', () => {
  let service: TravelAwayService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TravelAwayService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
