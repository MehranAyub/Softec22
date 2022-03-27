import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppointmentService } from '../../services/appointment.service';

@Component({
  selector: 'app-search-doctor',
  templateUrl: './search-doctor.component.html',
  styleUrls: ['./search-doctor.component.scss']
})
export class SearchDoctorComponent implements OnInit {

  constructor(private appointmentService:AppointmentService,private router:Router) { }

  ngOnInit(): void {
    this.search();
  }
  doctors:any[]=[];
  search(){
    this.appointmentService.GetDoctors({Keyword:'',PageNumber:1,PageSize:10,SpecialistId:[4,2]}).subscribe((res)=>{
      console.log(res);
      if(res?.data?.length>0){
        this.doctors=res?.data;
      }
    })
  }

  bookAppointment(id){
    this.router.navigate(['/appointment/checkout'], { queryParams: { doctorId: id }});
  }

  viewProfile(id){

  }
}
