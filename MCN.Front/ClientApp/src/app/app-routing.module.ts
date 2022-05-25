import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './shared/_helpers/auth.guard';

const routes: Routes = [
 
      {
        path: '',
        pathMatch: 'full',
        redirectTo: 'account'
      },
      {
        path: 'account',
        loadChildren: () =>
          import('./modules/account/account.module').then(
            (m) => m.AccountModule
          )
      },
     
      {
        path: 'appointment',
        loadChildren: () =>
          import('./modules/appointment/appointment.module').then(
            (m) => m.AppointmentModule
          ),
          
      canActivate:[AuthGuard]
      },
      {
        path: 'barber',
        loadChildren: () =>
          import('./modules/doctor/doctor.module').then(
            (m) => m.DoctorModule
          ),
          
      canActivate:[AuthGuard]
      }
     
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
