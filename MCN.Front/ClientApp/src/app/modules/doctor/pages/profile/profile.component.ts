import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppointmentDto, AppointmentService, specialities, SpecialitiesDto } from 'src/app/modules/appointment/services/appointment.service';
import { NotificationTypeEnum, SnackBarService } from 'src/app/shared/snack-bar.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  appointmentDto:AppointmentDto={AppointmentId:0,Date:new Date(),DoctorId:0,description:'',PatientId:0,doctorId:0,SelectTimeSlot:0,firstName:'',lastName:'',email:'',phone:''}

  constructor(private _appointmentService:AppointmentService,
    private _snackbarService:SnackBarService,private router:Router) {

    let user=JSON.parse(localStorage.getItem('currentUser'));
    if(user){
      this.appointmentDto.doctorId=user.user.id;
      this.appointmentDto.firstName=user.user.firstName;
      this.appointmentDto.lastName=user.user.lastName;
      this.appointmentDto.email=user.user.email;
      this.appointmentDto.phone=user.user.phone;
      this.appointmentDto.description=user.user.description;
    }
   }

   specialities:specialities[]=[];
  ngOnInit(): void {
    this._appointmentService.GetSpecialities().subscribe((res)=>{
      if(res.statusCode==200 && res?.data){
        this.specialities=res.data;
      }
    })
  }

  checkSepcialities(){
    console.log(this.specialities);
  }

  onCheckboxChange(e,item) { 
    let found=  this.specialities.find(x=>x.id==item.id);
    if (e.target.checked) {
    found.isChecked=true;
    }else{
      found.isChecked=false;
    }
  }
specialitiesDto:SpecialitiesDto={DoctorSpecialitiesDtos:[]};
  saveSpecialities(){
    let items=this.specialities.filter(x=>x?.isChecked==true);
    items.forEach((x)=>{
      this.specialitiesDto.DoctorSpecialitiesDtos.push({SpecialistId:x.id,DoctorId:this.appointmentDto.doctorId})
    })
    this._appointmentService.SaveSpecialities(this.specialitiesDto).subscribe((res)=>{
      if(res.statusCode==200){
        this._snackbarService.openSnack("Specialities update successfully",NotificationTypeEnum.Success);
        this.router.navigateByUrl('/doctor/appointments');
      }
    })
  }
}
