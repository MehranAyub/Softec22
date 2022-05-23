import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppointmentService, BarberDto } from 'src/app/modules/appointment/services/appointment.service';
import { NotificationTypeEnum, SnackBarService } from 'src/app/shared/snack-bar.service';

@Component({
  selector: 'app-new-barber',
  templateUrl: './new-barber.component.html',
  styleUrls: ['./new-barber.component.scss']
})
export class NewBarberComponent implements OnInit {

  barberDto:BarberDto={ID:0,FirstName:'',SalonId:0,LastName:'',Phone:'',Logo:'',Description:'',LoginType:2,Address:''}


  constructor(private appointmentService:AppointmentService,private snackbarService:SnackBarService,private router :Router) { }
  Barbers:any=[];
 error:string="";
  ngOnInit(): void {
    let user=JSON.parse(localStorage.getItem('currentUser'));
    if(user.user.userLoginTypeId==2){
  
      console.log(user.user.loginType)
     this.barberDto.SalonId=user.user.salonId;
     this.barberDto.Address=user.user.address;
     console.log(this.barberDto.Address);
     if(this.barberDto.SalonId==null){
       this.appointmentService.GetSalonID(user.user.id).subscribe((res)=>{
this.barberDto.SalonId=res;
console.log(this.barberDto.SalonId)
        this.appointmentService.GetBarbers(res).subscribe((res)=>{
          if(res.statusCode==200){
            this.Barbers=res.data;
            console.log(this.Barbers);
          }
        })
       })
     }
    
else{
console.log("else hitted")
  this.appointmentService.GetBarbers(this.barberDto.SalonId).subscribe((res)=>{
    if(res.statusCode==200){
      this.Barbers=res.data;
    }
  })
}

    }

    else{
      this.router.navigateByUrl('/appointment/search-salon');
    }
  
  }

RegisterBarber(){
  if(this.barberDto.FirstName!=''&&this.barberDto.LastName!=''&&this.barberDto.Description!=''&&this.barberDto.Phone!=''&&this.barberDto.SalonId!=0){
    this.appointmentService.RegisterBarber(this.barberDto).subscribe((res)=>{
if(res.statusCode==200){
console.log(res.data);
this.snackbarService.openSnack("New Barber added successfully",NotificationTypeEnum.Success);
      this.ngOnInit();      
}
    })
  }
  else{
this.error="Please fill all fields";
  }

}
RemoveBarber(id){
  this.appointmentService.RemoveBabrer(id).subscribe((res)=>{
   
      this.snackbarService.openSnack('Barber and his all Appointments Deleted Successfully',NotificationTypeEnum.Success);
       this.ngOnInit();
     // this.appointmentDto.DoctorId=this.doctor;
    
  })
}

}
