import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppointmentComponent } from './appointment.component';
import { SearchDoctorComponent } from './pages/search-doctor/search-doctor.component';

const routes: Routes = [
  {
    path:'',
    component:AppointmentComponent,
    children: [ 
    {
      path: 'search-doctor',
      component: SearchDoctorComponent
    }
]
}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AppointmentRoutingModule { }
