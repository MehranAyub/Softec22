import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DoctorComponent } from './doctor.component';
import { AppointmentsComponent } from './pages/appointments/appointments.component';
import { NewBarberComponent } from './pages/new-barber/new-barber.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { RegisterSalonComponent } from './pages/register-salon/register-salon.component';

const routes: Routes = [
  {
    path:'',
    component:DoctorComponent,
    children: [ 
    {
      path: '',
      component: ProfileComponent
    },
    {
      path: 'profile',
      component: ProfileComponent
    }
    ,
    {
      path: 'register-salon',
      component: RegisterSalonComponent
    },    
    {
      path: 'new-barber',
      component: NewBarberComponent
    },  

    {
      path: 'appointments',
      component: AppointmentsComponent
    },
  ]
}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DoctorRoutingModule { }
