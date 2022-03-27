import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/shared/services/auth/auth.service';
import { UserToken } from '../account/models/user';

@Component({
  selector: 'app-doctor',
  templateUrl: './doctor.component.html',
  styleUrls: ['./doctor.component.scss']
})
export class DoctorComponent implements OnInit {
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
