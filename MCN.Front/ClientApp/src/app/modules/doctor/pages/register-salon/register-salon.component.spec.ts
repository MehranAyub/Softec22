import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterSalonComponent } from './register-salon.component';

describe('RegisterSalonComponent', () => {
  let component: RegisterSalonComponent;
  let fixture: ComponentFixture<RegisterSalonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterSalonComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterSalonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
