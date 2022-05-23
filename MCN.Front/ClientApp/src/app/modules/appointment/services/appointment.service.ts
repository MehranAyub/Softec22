import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { ApiService } from 'src/app/shared/services/common/api.service';
import * as internal from 'stream';

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

GetSalon(id): Observable<any> {
  this.paramss = new HttpParams().set('id',id)
  return this.apiService.get('Users/GetSalon',this.paramss);
}

Salon(id): Observable<any> {
  this.paramss = new HttpParams().set('id',id)
  return this.apiService.get('Users/Salon',this.paramss);
}
GetProfileImg(id): Observable<any> {
  this.paramss = new HttpParams().set('id',id)
  return this.apiService.get('Users/GetProfileImg',this.paramss);
}
GetSpecialities(): Observable<any> { 
  return this.apiService.get('Appointments/GetSpecialities');
}
GetBarbers(id): Observable<any> {
  this.paramss = new HttpParams().set('id',id)
  return this.apiService.get('Users/GetBarbers',this.paramss);
}

SearchBarbers(id): Observable<any> {
  this.paramss = new HttpParams().set('id',id)
  return this.apiService.get('Users/SearchBarbers',this.paramss);
}

SaveSpecialities(model:SpecialitiesDto): Observable<any> {
  return this.apiService.post('Appointments/SaveSpecialities',model);
}
UpdateUser(model:AppointmentDto): Observable<any> {
  return this.apiService.post('Appointments/UpdateUser',model);
}

RegisterSalon(model:SalonDto): Observable<any> {
  return this.apiService.post('Users/RegisterSalon',model);
}
RegisterBarber(model:BarberDto): Observable<any> {
  return this.apiService.post('Users/CreateUser',model);
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
GetSalonID(id): Observable<any> {
  this.paramss = new HttpParams().set('id',id)
  return this.apiService.get('Users/GetSalonID',this.paramss);
}
RemoveBabrer(id): Observable<any> {
  return this.apiService.post('Users/RemoveBarber',id);
}

GetSalonList(model:SearchDoctorFilterDto):Observable<any>{
  return this.apiService.post('Appointments/GetSalonList',model);
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
export interface SalonDto{
ID:number,
Address:string,
Introduction:string,
Logo:string,
  Name:string;
  About?:string
  RegisterBy?:number;
  OwnerName:string;
  OwnerEmail:string;
}

export interface BarberDto{
  ID:number,
  Logo:string,
    FirstName:string;
    LastName:string;
    Phone:string;
    SalonId:number;
    Description:string;
    LoginType:number;
    Address:string;
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
