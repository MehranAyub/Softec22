import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SalonDto, AppointmentService, specialities, SpecialitiesDto } from 'src/app/modules/appointment/services/appointment.service';
import { NotificationTypeEnum, SnackBarService } from 'src/app/shared/snack-bar.service';

@Component({
  selector: 'app-register-salon',
  templateUrl: './register-salon.component.html',
  styleUrls: ['./register-salon.component.scss']
})
export class RegisterSalonComponent implements OnInit {
  SelectedFile:File=null;
  
    salonDto:SalonDto={ID:0,Name:'',RegisterBy:0,Address:'',Introduction:'',About:'',Logo:'',OwnerEmail:'',OwnerName:''}
   
    constructor(private http: HttpClient,private _appointmentService:AppointmentService,private _snackbarService:SnackBarService,private router:Router) {
  
      let user=JSON.parse(localStorage.getItem('currentUser'));
  
      if(user.user.userLoginTypeId==2){
        this.salonDto.RegisterBy=user.user.id;
        this.salonDto.OwnerEmail=user.user.email;
        this.salonDto.OwnerName=user.user.firstName+" "+user.user.lastName;
        this.salonDto.Address=user.user.address;
      }
      else{
        
      this.router.navigateByUrl('/appointment/search-salon');
      }

     }
     
     specialities:specialities[]=[];
     image:any=null;
    ngOnInit(): void {
      this._appointmentService.GetSpecialities().subscribe((res)=>{
        if(res.statusCode==200 && res?.data){
          this.specialities=res.data;
          this._appointmentService.GetSalon(this.salonDto.RegisterBy).subscribe((response)=>{

            if(response.statusCode==200 && response?.data){
              this.salonDto.About=response.data.about;
              this.salonDto.Introduction=response.data.introduction;
              this.salonDto.Name=response.data.name;
              this.salonDto.Logo=response.data.salonLogo;
              
            }
          })
          
        }
      })
    }
  
    checkSepcialities(){
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
        this.specialitiesDto.DoctorSpecialitiesDtos.push({SpecialistId:x.id,DoctorId:this.salonDto.RegisterBy})
      })

      this._appointmentService.RegisterSalon(this.salonDto).subscribe((response)=>{
        if(response.statusCode==200){
      this._appointmentService.SaveSpecialities(this.specialitiesDto).subscribe((res)=>{
        if(res.statusCode==200){
  
          
              this._snackbarService.openSnack("Salon Rigistered Successfully",NotificationTypeEnum.Success);
              this.router.navigateByUrl('/barber/appointments');
            }
          })
         
        }
      })
    }
  
    onFileSelected(event){
      this.SelectedFile=<File>event.target.files[0];
     
    }
  
    onUpload(){
   
      const form = new FormData();
      form.append('image',this.SelectedFile,this.SelectedFile.name);
    
      this.http.post('http://localhost:62489/api/Users/SalonLogo/'+this.salonDto.RegisterBy, form,{responseType: 'text'}).subscribe((res)=>{
      if(res!="null")
      {
        this.salonDto.Logo=res;
     
         
      }
     else{
      this._snackbarService.openSnack("Please Register Salon first, then upload Logo",NotificationTypeEnum.Danger);
             
     }
            })
 
  
    }
  }
  