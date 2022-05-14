import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppointmentDto, AppointmentService } from '../../services/appointment.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit {
 
  appointmentDto:AppointmentDto={AppointmentId:0,Date:new Date(),DoctorId:0,PatientId:0,SelectTimeSlot:'',firstName:'',lastName:'',email:'',phone:''}
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
      let slot = (params['slots'] || 0);
      this.Slots=slot;
      this.appointmentDto.Date = (params['date'] || 0);

      let doctorId = (params['doctorId'] || 0);
this.appointmentDto.DoctorId=doctorId;
      doctorId[0]
      if(doctorId>0){
      //  this.registerAppointment(doctorId);
        this.getDoctor(doctorId);
      }
    });
   }
   
   doctor:any={};
   getDoctor(id){
    this.appointmentService.GetDoctor(id).subscribe((res)=>{
      if(res.data){
        this.doctor=res.data;
        this.appointmentDto.doctorId=id;
      }
    })
   }
   registerAppointment(){
    console.log('appoint method called');
    console.log(this.appointmentDto);
     this.appointmentService.RegisterAppointment(this.appointmentDto).subscribe((res)=>{
       if(res?.data){
         this.appointmentDto.AppointmentId=(res.data.id || 0);
         this.router.navigate(['/appointment/booking-success'], { queryParams: { name: this.doctor?.firstName+' '+this.doctor?.lastName }});
       }
     })
   }


 Slots:any[];
  ngOnInit(): void {
  }

}
