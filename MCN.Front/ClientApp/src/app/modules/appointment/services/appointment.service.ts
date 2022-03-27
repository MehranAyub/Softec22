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

GetAppointments(id): Observable<any> {
  this.paramss = new HttpParams().set('id',id)
  return this.apiService.get('Appointments/GetAppointments',this.paramss);
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
    SelectTimeSlot :TimeSlots
   AppointmentId :number

   firstName:string;
   lastName:string;
   phone:string;
   email:string;
   description?:string
   doctorId?:number;
}

export class SpecialitiesDto
{
    DoctorSpecialitiesDtos:any[]

}

export class DoctorSpecialitiesDto{
   DoctorId:number
   SpecialistId:number
}

export enum TimeSlots{

  Slot1=1,
  Slot2=2,
  Slot3=3,
  Slot4=4,
  Slot5=5,
  Slot6=6,
  Slot7=7,
  Slot8=8,
  Slot9=9,
  Slot10=10,
}
export interface specialities{
  id:number;
  name:string;
  isChecked:boolean;
}