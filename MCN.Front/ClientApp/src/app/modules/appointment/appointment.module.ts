import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppointmentRoutingModule } from './appointment-routing.module';
import { AppointmentComponent } from '../appointment/appointment.component';
import { SearchDoctorComponent } from './pages/search-doctor/search-doctor.component';


@NgModule({
  declarations: [AppointmentComponent, SearchDoctorComponent],
  imports: [
    CommonModule,
    AppointmentRoutingModule
  ]
})
export class AppointmentModule { }
