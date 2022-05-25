import { Component, OnInit } from '@angular/core';
import { AppointmentService } from '../../services/appointment.service';
import { SnackBarService, NotificationTypeEnum } from 'src/app/shared/snack-bar.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-patient-appointments',
  templateUrl: './patient-appointments.component.html',
  styleUrls: ['./patient-appointments.component.scss']
})
export class PatientAppointmentsComponent implements OnInit {

  constructor(private appointmentService:AppointmentService,private snackbarService:SnackBarService,private router:Router) { }
  errors:string;
  appointments:any=[];
  ngOnInit(): void {
    let user=JSON.parse(localStorage.getItem('currentUser'));
    if(user.user.userLoginTypeId==1){
     let patientid=user.user.id;
     this.appointmentService.GetPatientAppointments(patientid).subscribe((res)=>{
      if(res.data.length!=0){
        this.appointments=res.data;
      }
      else{
this.errors="You have not any registered appointment at any salon"
      }
    })
    }
    else{
      
      this.router.navigateByUrl('/barber/appointments');
    }
  }

  CancelAppointment(id){
    this.appointmentService.CancelAppointment(id).subscribe((res)=>{
      if(res.data){
        this.snackbarService.openSnack(res.swallText.title,NotificationTypeEnum.Success);
         this.ngOnInit();
       // this.appointmentDto.DoctorId=this.doctor;
      }
    })
  }
}
