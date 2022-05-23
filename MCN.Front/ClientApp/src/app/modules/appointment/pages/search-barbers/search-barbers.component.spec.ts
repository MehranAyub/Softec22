import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchBarbersComponent } from './search-barbers.component';

describe('SearchBarbersComponent', () => {
  let component: SearchBarbersComponent;
  let fixture: ComponentFixture<SearchBarbersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchBarbersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchBarbersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
