import { Component, OnInit } from '@angular/core';
import { AppointmentService } from 'src/app/modules/appointment/services/appointment.service';

@Component({
  selector: 'app-appointments',
  templateUrl: './appointments.component.html',
  styleUrls: ['./appointments.component.scss']
})
export class AppointmentsComponent implements OnInit {

  constructor(private _appointmentsService:AppointmentService) { }
  appointments:any=[];
  ngOnInit(): void {
    let user=JSON.parse(localStorage.getItem('currentUser'));
    if(user){
     let doctorId=user.user.id;
     this._appointmentsService.GetAppointments(doctorId).subscribe((res)=>{
      if(res.statusCode==200){
        this.appointments=res.data;
      }
    })
    }
  
  }

}
