import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/shared/services/auth/auth.service';
import { User, UserToken } from '../account/models/user';

@Component({
  selector: 'app-appointment',
  templateUrl: './appointment.component.html',
  styleUrls: ['./appointment.component.scss']
})
export class AppointmentComponent implements OnInit {
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
