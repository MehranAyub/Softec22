import { Component, OnInit } from '@angular/core';
import { AppointmentService } from '../../services/appointment.service';

@Component({
  selector: 'app-patient-appointments',
  templateUrl: './patient-appointments.component.html',
  styleUrls: ['./patient-appointments.component.scss']
})
export class PatientAppointmentsComponent implements OnInit {

  constructor(private _appointmentsService:AppointmentService) { }
  appointments:any=[];
  ngOnInit(): void {
    let user=JSON.parse(localStorage.getItem('currentUser'));
    if(user){
     let doctorId=user.user.id;
     this._appointmentsService.GetPatientAppointments(doctorId).subscribe((res)=>{
      if(res.statusCode==200){
        this.appointments=res.data;
      }
    })
    }
  }
}
