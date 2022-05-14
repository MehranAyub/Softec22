import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/shared/services/auth/auth.service';
import { User, UserToken } from '../account/models/user';
import { AppointmentDto } from './services/appointment.service';

@Component({
  selector: 'app-appointment',
  templateUrl: './appointment.component.html',
  styleUrls: ['./appointment.component.scss']
})
export class AppointmentComponent implements OnInit {
  user:UserToken;
  appointmentDto:AppointmentDto={AppointmentId:0,Date:new Date(),DoctorId:0,PatientId:0,SelectTimeSlot:'',firstName:'',lastName:'',email:'',phone:'',userLoginTypeId:0}
  constructor(private auth:AuthService) {
    auth.currentUserSubject.subscribe((res)=>{
      if(res){
        this.user=res;
      }

      let user=JSON.parse(localStorage.getItem('currentUser'));
      if(user){
        this.appointmentDto.doctorId=user.user.id;
        this.appointmentDto.firstName=user.user.firstName;
        this.appointmentDto.lastName=user.user.lastName;
        this.appointmentDto.email=user.user.email;
        this.appointmentDto.phone=user.user.phone;
        this.appointmentDto.userLoginTypeId=user.user.userLoginTypeId;
        
      }

    })
   }

  ngOnInit(): void {
  }

  logout(){
    this.auth.logout();
  }
}
