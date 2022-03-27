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
}

export interface SearchDoctorFilterDto{
  Keyword :string
  SpecialistId:number[] 
  PageNumber :number
  PageSize:number
}