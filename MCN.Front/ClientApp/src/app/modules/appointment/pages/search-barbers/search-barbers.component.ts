import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { AppointmentService, BarberDto } from '../../services/appointment.service';

@Component({
  selector: 'app-search-barbers',
  templateUrl: './search-barbers.component.html',
  styleUrls: ['./search-barbers.component.scss']
})
export class SearchBarbersComponent implements OnInit {
    
  constructor(private activatedRoute:ActivatedRoute,private appointmentService:AppointmentService,private router:Router,private _sanitizer: DomSanitizer) { 
    let user=JSON.parse(localStorage.getItem('currentUser'));
    if(user.user.userLoginTypeId==1){
      activatedRoute.queryParams.subscribe(params => {
        // this.isFromCashScreen = (params['isFromCashScreen'] == 'true');
        let salonId = (params['salonId'] || 0);
  
        if(salonId>0){
         // this.registerAppointment(doctorId);
          this.GetSalon(salonId);
          this.search(salonId);
          this.barberDto.SalonId=salonId;
        }
      });
    }
    else{
      this.router.navigateByUrl('/barber/appointments');
    }


 

  }
  ngOnInit(): void {



  }
  Barbers:any[]=[];
  Salon:any;
  barberDto:BarberDto={ID:0,FirstName:'',LastName:'',Logo:'',LoginType:1,Phone:'',SalonId:0,Description:'',Address:''}




 search(id){
    this.appointmentService.SearchBarbers(id).subscribe((res)=>{
      console.log(res);
      if(res?.data?.length>0){
        this.Barbers=res?.data;
    
      }else{
        this.Barbers=[];
      }
    })
  }
  bookAppointment(id){
    this.router.navigate(['/appointment/selected-day'], { queryParams: { doctorId: id}});
  }

  GetSalon(id){
    this.appointmentService.Salon(id).subscribe((res)=>{  
        this.Salon=res?.data;
        console.log(this.Salon)
    })
  }
}
