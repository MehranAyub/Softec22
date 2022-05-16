import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { ApiService } from 'src/app/shared/services/common/api.service';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  private  url="Search/";

 
  paramss:HttpParams = new HttpParams();
  
    constructor(private apiService: ApiService) { }
  

  GetDoctors(model:SearchDoctorFilterDto): Observable<any> {
    // let model:any={Keyword:keyword,PageNumber:1,PageSize:10}
    return this.apiService.post('Appointments/SearchDoctor',model);
}

RegisterAppointment(model:AppointmentDto): Observable<any> {
  return this.apiService.post('Appointments/RegisterAppointment',model);
}

RegisterTimeSlot(model:AppointmentDto): Observable<any> {
  return this.apiService.post('Appointments/RegisterTimeSlot',model);
}
FindSlots(model:AppointmentDto): Observable<any> {
  return this.apiService.post('Appointments/FindSlots',model);
}
GetDoctor(id): Observable<any> {
  this.paramss = new HttpParams().set('id',id)
  return this.apiService.get('Appointments/GetDoctor',this.paramss);
}

GetSpecialities(): Observable<any> { 
  return this.apiService.get('Appointments/GetSpecialities');
}

SaveSpecialities(model:SpecialitiesDto): Observable<any> {
  return this.apiService.post('Appointments/SaveSpecialities',model);
}
UpdateUser(model:AppointmentDto): Observable<any> {
  return this.apiService.post('Appointments/UpdateUser',model);
}
FileUpload (model:FormData): Observable<any> {
  return this.apiService.post('Users/FileUpload',model);
}
GetAppointments(id): Observable<any> {
  this.paramss = new HttpParams().set('id',id)
  return this.apiService.get('Appointments/GetAppointments',this.paramss);
}

GetPatientAppointments(id): Observable<any> {
  this.paramss = new HttpParams().set('id',id)
  return this.apiService.get('Appointments/GetPatientAppointments',this.paramss);
}
CancelAppointment(id): Observable<any> {
  return this.apiService.post('Appointments/CancelAppointment',id);
}
}

export interface SearchDoctorFilterDto{
  Keyword :string
  SpecialistId:number[] 
  PageNumber :number
  PageSize:number
}

export interface AppointmentDto{
   DoctorId  :number
    PatientId :number
    Date :Date
    SelectTimeSlot :string
   AppointmentId :number

   firstName:string;
   lastName:string;
   phone:string;
   email:string;
   description?:string
   doctorId?:number;
   userLoginTypeId?:number
}

export class SpecialitiesDto
{
    DoctorSpecialitiesDtos:any[]

}

export class DoctorSpecialitiesDto{
   DoctorId:number
   SpecialistId:number
}

export interface specialities{
  id:number;
  name:string;
  isChecked:boolean;
}
