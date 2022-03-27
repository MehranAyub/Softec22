import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppointmentRoutingModule } from './appointment-routing.module';
import { AppointmentComponent } from '../appointment/appointment.component';
import { SearchDoctorComponent } from './pages/search-doctor/search-doctor.component';
import { CheckoutComponent } from './pages/timeslot/checkout.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BookingSuccessComponent } from './pages/booking-success/booking-success.component';


@NgModule({
  declarations: [AppointmentComponent, SearchDoctorComponent, CheckoutComponent, BookingSuccessComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    AppointmentRoutingModule
  ]
})
export class AppointmentModule { }