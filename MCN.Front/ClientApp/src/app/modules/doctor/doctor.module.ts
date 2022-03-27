import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DoctorRoutingModule } from './doctor-routing.module';
import { DoctorComponent } from './doctor.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProfileComponent } from './pages/profile/profile.component';
import { AppointmentsComponent } from './pages/appointments/appointments.component';


@NgModule({
  declarations: [ProfileComponent,DoctorComponent,AppointmentsComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    DoctorRoutingModule
  ]
})
export class DoctorModule { }
