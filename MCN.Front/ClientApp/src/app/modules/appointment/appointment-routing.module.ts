import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from 'src/app/shared/_helpers/auth.guard';
import { AppointmentComponent } from './appointment.component';
import { BookingSuccessComponent } from './pages/booking-success/booking-success.component';
import { SearchDoctorComponent } from './pages/search-doctor/search-doctor.component';
import { CheckoutComponent } from './pages/timeslot/checkout.component';

const routes: Routes = [
  {
    path:'',
    component:AppointmentComponent,
    children: [ 
    {
      path: 'search-doctor',
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
      path: 'booking-success',
      component: BookingSuccessComponent,      
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
