import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewBarberComponent } from './new-barber.component';

describe('NewBarberComponent', () => {
  let component: NewBarberComponent;
  let fixture: ComponentFixture<NewBarberComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewBarberComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewBarberComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
