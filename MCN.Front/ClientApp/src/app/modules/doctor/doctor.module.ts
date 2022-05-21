import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DoctorRoutingModule } from './doctor-routing.module';
import { DoctorComponent } from './doctor.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProfileComponent } from './pages/profile/profile.component';
import { AppointmentsComponent } from './pages/appointments/appointments.component';
import { RegisterSalonComponent } from './pages/register-salon/register-salon.component';
import { NewBarberComponent } from './pages/new-barber/new-barber.component';


@NgModule({
  declarations: [ProfileComponent,DoctorComponent,AppointmentsComponent, RegisterSalonComponent, NewBarberComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    DoctorRoutingModule
  ]
})
export class DoctorModule { }
