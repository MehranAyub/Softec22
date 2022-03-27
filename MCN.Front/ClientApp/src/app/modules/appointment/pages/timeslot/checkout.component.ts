import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppointmentDto, AppointmentService } from '../../services/appointment.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit {

  appointmentDto:AppointmentDto={AppointmentId:0,Date:new Date(),DoctorId:0,PatientId:0,SelectTimeSlot:0,firstName:'',lastName:'',email:'',phone:''}
  constructor(private activatedRoute:ActivatedRoute,private router:Router,private appointmentService:AppointmentService) {

    let user=JSON.parse(localStorage.getItem('currentUser'));
    if(user){
      this.appointmentDto.PatientId=user.user.id;
      this.appointmentDto.firstName=user.user.firstName;
      this.appointmentDto.lastName=user.user.lastName;
      this.appointmentDto.email=user.user.email;
      this.appointmentDto.phone=user.user.phone;
    }else{
      this.router.navigate(['/account/login']);
    }
    activatedRoute.queryParams.subscribe(params => {
      // this.isFromCashScreen = (params['isFromCashScreen'] == 'true');
      let doctorId = (params['doctorId'] || 0);
      if(doctorId>0){
        this.registerAppointment(doctorId);
        this.getDoctor(doctorId);
      }
    });
   }
   doctor:any={};
   getDoctor(id){
    this.appointmentService.GetDoctor(id).subscribe((res)=>{
      if(res.data){
        this.doctor=res.data;
      }
    })
   }
   registerAppointment(doctorId){
    this.appointmentDto.DoctorId=doctorId;
     this.appointmentService.RegisterAppointment(this.appointmentDto).subscribe((res)=>{
       if(res?.data){
         this.appointmentDto.AppointmentId=(res.data.id || 0);
       }
     })
   }

   registerTimeSlot(){
     this.appointmentService.RegisterTimeSlot(this.appointmentDto).subscribe((res)=>{
       if(res?.data){
         console.log(res);
         this.router.navigate(['/appointment/booking-success'], { queryParams: { name: this.doctor?.firstName+' '+this.doctor?.lastName }});
       }
     })
   }

  timeSlots:any[]=[
  {id:1,time:"08:00 - 08:30"},
  {id:2,time:"08-30 - 09:00"},
  {id:3,time:"09:00 - 09:30"},
  {id:4,time:"09:30 - 10:00"},
  {id:5,time:"10:00 - 10:30"},
  {id:6,time:"10:30 - 11:00"},
  {id:7,time:"11:00 - 11:30"},
  {id:8,time:"11:30 - 12:00"}]
  ngOnInit(): void {
  }

}
