import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AppointmentDto, AppointmentService, specialities, SpecialitiesDto } from 'src/app/modules/appointment/services/appointment.service';
import { NotificationTypeEnum, SnackBarService } from 'src/app/shared/snack-bar.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
SelectedFile:File=null;

  appointmentDto:AppointmentDto={AppointmentId:0,Date:new Date(),DoctorId:0,description:'',PatientId:0,doctorId:0,SelectTimeSlot:'',firstName:'',lastName:'',email:'',phone:''}
 
  constructor(private http: HttpClient,private _appointmentService:AppointmentService,private _snackbarService:SnackBarService,private router:Router) {
  
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
   image:any=null;
  ngOnInit(): void {
        this._appointmentService.GetProfileImg(this.appointmentDto.doctorId).subscribe((response)=>{
          if(response.statusCode==200 && response?.data){
            this.appointmentDto.description=response.data.data;
        
          }
        })
      }
 

 



      EditProfile(){
        this._appointmentService.UpdateUser(this.appointmentDto).subscribe((response)=>{
          if(response.statusCode==200){
            this._snackbarService.openSnack("Profile updated successfully",NotificationTypeEnum.Success);
            this.ngOnInit();
          }
        })
       
      }


  onFileSelected(event){
    this.SelectedFile=<File>event.target.files[0];
   
  }

  onUpload(){
 
    const form = new FormData();
    form.append('image',this.SelectedFile,this.SelectedFile.name);
  
    this.http.post('http://localhost:62489/api/Users/FileUpload/'+this.appointmentDto.doctorId, form,{responseType: 'text'}).subscribe((res)=>{
      console.log(res);
this.appointmentDto.description=res;
 
          })


  }
}
