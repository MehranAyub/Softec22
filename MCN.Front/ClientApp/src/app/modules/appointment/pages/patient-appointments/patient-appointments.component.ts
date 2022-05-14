import { Component, OnInit } from '@angular/core';
import { AppointmentService } from '../../services/appointment.service';
import { SnackBarService, NotificationTypeEnum } from 'src/app/shared/snack-bar.service';
@Component({
  selector: 'app-patient-appointments',
  templateUrl: './patient-appointments.component.html',
  styleUrls: ['./patient-appointments.component.scss']
})
export class PatientAppointmentsComponent implements OnInit {

  constructor(private appointmentService:AppointmentService,private snackbarService:SnackBarService) { }
  appointments:any=[];
  ngOnInit(): void {
    let user=JSON.parse(localStorage.getItem('currentUser'));
    if(user){
     let patientid=user.user.id;
     this.appointmentService.GetPatientAppointments(patientid).subscribe((res)=>{
      if(res.statusCode==200){
        this.appointments=res.data;
        console.log(this.appointments);
      }
    })
    }
    
  }

  CancelAppointment(id){
    console.log("Canecl Appointmennt");
    this.appointmentService.CancelAppointment(id).subscribe((res)=>{
      if(res.data){
        this.snackbarService.openSnack(res.swallText.title,NotificationTypeEnum.Success);
         
       // this.appointmentDto.DoctorId=this.doctor;
      }
    })
  }
}
