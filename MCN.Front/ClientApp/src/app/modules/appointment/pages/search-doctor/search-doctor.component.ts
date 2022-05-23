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

  constructor(private appointmentService:AppointmentService,private router:Router,private _sanitizer: DomSanitizer) {

    let user=JSON.parse(localStorage.getItem('currentUser'));
    if(user.user.userLoginTypeId!=1){

    
      this.router.navigateByUrl('/doctor/appointments');
    }

   }

  ngOnInit(): void {
    this.search();
    this.GetSpecialities();
  }
  salons:any[]=[];
  imagePath:any;
  searchDoctorFilter:SearchDoctorFilterDto={Keyword:'',PageNumber:1,PageSize:10,SpecialistId:[]};
  search(){
    this.appointmentService.GetSalonList(this.searchDoctorFilter).subscribe((res)=>{
   
      if(res?.data?.length>0){
        this.salons=res?.data;
    
      }else{
        this.salons=[];
      }
    })
  }

  bookAppointment(id){
    this.router.navigate(['/appointment/search-barbers'], { queryParams: { salonId: id }});
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
