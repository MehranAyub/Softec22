import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { AppointmentService, SearchDoctorFilterDto, specialities } from '../../services/appointment.service';

@Component({
  selector: 'app-search-doctor',
  templateUrl: './search-doctor.component.html',
  styleUrls: ['./search-doctor.component.scss']
})
export class SearchDoctorComponent implements OnInit {

  constructor(private appointmentService:AppointmentService,private router:Router,private _sanitizer: DomSanitizer) { }

  ngOnInit(): void {
    this.search();
    this.GetSpecialities();
  }
  doctors:any[]=[];
  imagePath:any;
  searchDoctorFilter:SearchDoctorFilterDto={Keyword:'',PageNumber:1,PageSize:10,SpecialistId:[]};
  search(){
    this.appointmentService.GetDoctors(this.searchDoctorFilter).subscribe((res)=>{
      console.log(res);
      if(res?.data?.length>0){
        this.doctors=res?.data;
    
      }else{
        this.doctors=[];
      }
    })
  }

  bookAppointment(id){
    this.router.navigate(['/appointment/selected-day'], { queryParams: { doctorId: id }});
  }

  viewProfile(id){

  }

  specialities:specialities[]=[];
  GetSpecialities(): void {
    this.appointmentService.GetSpecialities().subscribe((res)=>{
      if(res.statusCode==200 && res?.data){
        this.specialities=res.data;
      }
    })
  }

  keyUpEvent(value){
    this.searchDoctorFilter.Keyword=value;
    this.search();
  }
  
  onCheckboxChange(e,item) { 
    let found=  this.specialities.find(x=>x.id==item.id);
    this.searchDoctorFilter.SpecialistId=[];
    if (e.target.checked) {
    found.isChecked=true;
    }else{
      found.isChecked=false;
    }

   let selectedItems= this.specialities?.filter(x=>x?.isChecked==true);
   selectedItems.forEach((y)=>{
     this.searchDoctorFilter.SpecialistId.push(y.id);
   });
   this.search();
  }
}
