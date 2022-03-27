import { Injectable } from '@angular/core';
import { Subject, BehaviorSubject, Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { ApiService } from '../common/api.service';
import { CreateUserDto } from 'src/app/modules/account/models/UserLogin';
import { UserToken } from 'src/app/modules/account/models/user';
import { isNullOrUndefined } from 'util';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
   
public currentUserSubject: BehaviorSubject<UserToken>;
public currentUser: Observable<UserToken>;

constructor(private http: HttpClient,private apiService:ApiService,private router:Router) {
    this.currentUserSubject = new BehaviorSubject<UserToken>(JSON.parse(JSON.stringify(localStorage.getItem('currentUser'))));
    this.currentUser = this.currentUserSubject.asObservable();
}
paramss:HttpParams = new HttpParams();

public get currentUserValue(): UserToken {
    return this.currentUserSubject.value;
}

   ReGenerateEmailVerificationMail(createUserDto:CreateUserDto){  
    return this.apiService.post(`Users/ReGenerateEmailVerificationMail`,createUserDto);
   }
   
   ValidateEmail(email:string){  
    this.paramss = new HttpParams().set('email',email)
    return this.apiService.get(`Users/ValidateEmail`,this.paramss);
   }

   

   ValidateEmailPassword(password: string, email: string) {
  this.paramss = new HttpParams().set('password',password)
  .set('email', email);
    return this.apiService.get(`Users/ValidateEmailPassword`, this.paramss)
        .pipe(map(response => {
            // login successful if there's a jwt token in the response
            console.log(response.data);
            if(!!(response.data)){
            if (!!(response.data.token) && !!(response.data.user)) {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('currentUser', JSON.stringify(response.data));
                this.currentUserSubject.next(response.data);
            }
        }

            return response;
        }));
}

VerifyEmailPasscode(emailPasscode: string, email: string) {
    this.paramss = new HttpParams().set('emailPasscode',emailPasscode)
    .set('email', email);
      return this.apiService.get(`Users/VerifyEmailPasscode`, this.paramss)
          .pipe(map(response => {
              // login successful if there's a jwt token in the response
              console.log(response.data);
              if(!!(response.data)){
              if (!!(response.data.token) && !!(response.data.user)) {
                  // store user details and jwt token in local storage to keep user logged in between page refreshes
                  localStorage.setItem('currentUser', JSON.stringify(response.data));
                  this.currentUserSubject.next(response.data);
              }
          }
  
              return response;
          }));
  }

logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
    this.router.navigate(['/account/login']);
    // window.location.reload();
}
}
