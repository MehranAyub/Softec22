import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppointmentDto, AppointmentService } from '../../services/appointment.service';

@Component({
  selector: 'app-selected-day',
  templateUrl: './selected-day.component.html',
  styleUrls: ['./selected-day.component.scss']
})
export class SelectedDayComponent implements OnInit {
 
  appointmentDto:AppointmentDto={AppointmentId:0,Date:new Date(),DoctorId:0,PatientId:0,SelectTimeSlot:'',firstName:'',lastName:'',email:'',phone:''}
  constructor(private activatedRoute:ActivatedRoute,private router:Router,private appointmentService:AppointmentService) {

    let user=JSON.parse(localStorage.getItem('currentUser'));
    if(user){
    
    }else{
      this.router.navigate(['/account/login']);
    }
    activatedRoute.queryParams.subscribe(params => {
      // this.isFromCashScreen = (params['isFromCashScreen'] == 'true');
      let doctorId = (params['doctorId'] || 0);

      if(doctorId>0){
       // this.registerAppointment(doctorId);
        this.getDoctor(doctorId);
        this.appointmentDto.DoctorId=doctorId;
      }
    });
   }
   doctor:any={};
   getDoctor(id){
    this.appointmentService.GetDoctor(id).subscribe((res)=>{
      if(res.data){
        this.doctor=res.data;
       // this.appointmentDto.DoctorId=this.doctor;
      }
    })
   }
  ngOnInit(): void {
  }
  FindSlots(){
    console.log('Request hitted')
    this.appointmentService.FindSlots(this.appointmentDto).subscribe((res)=>{
      if(res?.data){
        console.log(res.data);
        var alphas;
        alphas = ['null','null','null','null','null','null','null','null'];
             var slot =[];      
        
        
        if (res.data.s1==0)
                    {
                      alphas[0]='8:00 am';
                    }
                    if (res.data.s2==0)
                    {
                      alphas[1]='9:00 am';
                    }
                    if (res.data.s3==0)
                    {
                      alphas[2]='10:00 am';
                    }
                    if (res.data.s4==0)
                    {
                      alphas[3]='11:00 am';
                    }
                    if (res.data.s5==0)
                    {
                      alphas[4]='12:00 pm';
                    }
                    if (res.data.s6==0)
                    {
                      alphas[5]='01:00 pm';
                    }
                    if (res.data.s7==0)
                    {
                      alphas[6]='02:00 pm';
                    }
                    if (res.data.s8==0)
                    {
                      alphas[7]='03:00 pm';
                    } 
                   // console.log(alphas);
var j=0;
                   for (let i = 0; i < 8; i++) {
                    if(alphas[i]!='null'){
                          slot[j]=alphas[i];
                          j++;
                    }
                  }
        this.router.navigate(['/appointment/checkout'], { queryParams: { slots: slot,doctorId:this.appointmentDto.DoctorId,date:this.appointmentDto.Date}});
      }
    })
}
}

