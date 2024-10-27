import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DogfactComponent } from './dogfact.component';

describe('DogfactComponent', () => {
  let component: DogfactComponent;
  let fixture: ComponentFixture<DogfactComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DogfactComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DogfactComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
