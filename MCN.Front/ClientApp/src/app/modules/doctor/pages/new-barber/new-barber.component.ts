import { Component, OnInit } from '@angular/core';
import { AppointmentService, BarberDto } from 'src/app/modules/appointment/services/appointment.service';
import { SnackBarService } from 'src/app/shared/snack-bar.service';

@Component({
  selector: 'app-new-barber',
  templateUrl: './new-barber.component.html',
  styleUrls: ['./new-barber.component.scss']
})
export class NewBarberComponent implements OnInit {

  salonDto:BarberDto={ID:0,FirstName:'',SalonId:0,LastName:'',Phone:'',Logo:'',}
   
  constructor(private appointmentService:AppointmentService,private snackbarService:SnackBarService) { }
  Barbers:any=[];
  ngOnInit(): void {
    let user=JSON.parse(localStorage.getItem('currentUser'));
    if(user){
     let doctorId=user.user.id;
     this.appointmentService.GetBarbers(doctorId).subscribe((res)=>{
      if(res.statusCode==200){
        this.Barbers=res.data;
        console.log(res.data);
      }
    })
    }
  
  }
}
