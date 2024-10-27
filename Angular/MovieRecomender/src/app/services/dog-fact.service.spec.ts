import { TestBed } from '@angular/core/testing';

import { DogFactService } from './dog-fact.service';

describe('DogFactService', () => {
  let service: DogFactService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DogFactService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
