import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DoctorComponent } from './doctor.component';
import { AppointmentsComponent } from './pages/appointments/appointments.component';
import { ProfileComponent } from './pages/profile/profile.component';

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
