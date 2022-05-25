import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppointmentService } from 'src/app/modules/appointment/services/appointment.service';
import { NotificationTypeEnum, SnackBarService } from 'src/app/shared/snack-bar.service';

@Component({
  selector: 'app-appointments',
  templateUrl: './appointments.component.html',
  styleUrls: ['./appointments.component.scss']
})
export class AppointmentsComponent implements OnInit {

  constructor(private appointmentService:AppointmentService,private snackbarService:SnackBarService,private router:Router) { }
  appointments:any=[];
  ngOnInit(): void {
    let user=JSON.parse(localStorage.getItem('currentUser'));
    if(user.user.userLoginTypeId==2){

     let salonId=user.user.salonId;
     this.appointmentService.GetAppointments(salonId).subscribe((res)=>{
      if(res.statusCode==200){
        this.appointments=res.data;
        console.log(this.appointments)
      }
    })
    }
    else{
      this.router.navigateByUrl('/appointment/patient-appointments');
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
