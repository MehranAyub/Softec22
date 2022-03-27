import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/shared/services/auth/auth.service';
import { User, UserToken } from './models/user';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss']
})
export class AccountComponent implements OnInit {

  user:UserToken;
  constructor(private auth:AuthService) {
    auth.currentUserSubject.subscribe((res)=>{
      if(res){
        this.user=res;
      }
    })
   }

  ngOnInit(): void {
  }

  logout(){
    this.auth.logout();
  }
}
