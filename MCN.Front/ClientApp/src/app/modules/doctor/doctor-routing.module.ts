import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from 'src/app/shared/_helpers/auth.guard';
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
      component: ProfileComponent,
      canActivate:[AuthGuard]

    },
    {
      path: 'profile',
      component: ProfileComponent,
      canActivate:[AuthGuard]
    }
    ,
    {
      path: 'register-salon',
      component: RegisterSalonComponent,
      canActivate:[AuthGuard]
    },    
    {
      path: 'new-barber',
      component: NewBarberComponent,
      canActivate:[AuthGuard]
    },  

    {
      path: 'appointments',
      component: AppointmentsComponent,
      canActivate:[AuthGuard]
    },
  ]
}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DoctorRoutingModule { }
