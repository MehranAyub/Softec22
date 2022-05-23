import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from 'src/app/shared/_helpers/auth.guard';
import { AppointmentComponent } from './appointment.component';
import { BookingSuccessComponent } from './pages/booking-success/booking-success.component';
import { PatientAppointmentsComponent } from './pages/patient-appointments/patient-appointments.component';
import { SearchBarbersComponent } from './pages/search-barbers/search-barbers.component';
import { SearchDoctorComponent } from './pages/search-doctor/search-doctor.component';
import { SelectedDayComponent } from './pages/selected-day/selected-day.component';
import { CheckoutComponent } from './pages/timeslot/checkout.component';

const routes: Routes = [
  {
    path:'',
    component:AppointmentComponent,
    children: [ 
    {
      path: 'search-salon',
      component: SearchDoctorComponent,
      canActivate:[AuthGuard]
    },
    {
      path: '',
      component: SearchDoctorComponent,
      canActivate:[AuthGuard]
    },
    {
      path: 'checkout',
      component: CheckoutComponent,
      canActivate:[AuthGuard]
    },
    {
      path: 'search-barbers',
      component: SearchBarbersComponent,
      canActivate:[AuthGuard]
    },
    {
      path: 'booking-success',
      component: BookingSuccessComponent,      
      canActivate:[AuthGuard]
    },
    {
      path: 'selected-day',
      component: SelectedDayComponent,      
      canActivate:[AuthGuard]
    },
    {
      path: 'patient-appointments',
      component: PatientAppointmentsComponent,      
      canActivate:[AuthGuard]
    }
]
}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AppointmentRoutingModule { }
