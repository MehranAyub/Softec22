import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountComponent } from './account.component';
import { EmailVerifyComponent } from './email-verify/email-verify.component';
import { LoginComponent } from './login/login.component';
import { UserRegisterComponent } from './user-register/user-register.component';


const routes: Routes = [ 
  {
    path:'',
    component:AccountComponent,
    children: [ 
    {
      path: 'login',
      component: LoginComponent
    },
    {
      path: '**',
      component: LoginComponent
    },
    {
      path: '',
      component: LoginComponent
    },
    {
      path: 'register',
      component: UserRegisterComponent
    },
    {
      path: 'email-verify',
      component: EmailVerifyComponent
    },
]
}
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountRoutingModule { }
