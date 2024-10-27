import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { exampleGuard } from './example.guard';

describe('exampleGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => exampleGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
