import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from 'src/app/shared/services/auth/auth.service';
import { Router, ActivatedRoute } from '@angular/router';
import { EmailPasscodeDto } from '../models/UserLogin';
import { SnackBarService, NotificationTypeEnum } from 'src/app/shared/snack-bar.service';
import { AccountDataService } from '../services/accountDataService';
import { LoginType } from '../models/user';

@Component({
  selector: 'app-email-verify',
  templateUrl: './email-verify.component.html',
  styleUrls: ['./email-verify.component.scss']
})
export class EmailVerifyComponent implements OnInit {


  isEmailVerify:boolean=false
  loginDto:EmailPasscodeDto={email:'',passcode:''};
  isLoading = false; 
  constructor(private _authService:AuthService,
    private router:Router,
    private _snackbarService:SnackBarService,
    private aroute: ActivatedRoute,
    private _dataService:AccountDataService)
    {


    }
    ngOnInit(){
      this.loginDto.email=this._dataService?._emailPasscode?.email;
    }
 
  OnVerifyEmailAddress() {
    this.isLoading=true; 
    this.loginDto.email;
      this._authService.VerifyEmailPasscode(this.loginDto.passcode,this.loginDto.email).subscribe(response=>{
        console.log(response);
        if(response.statusCode==200 && response?.data?.user){
          
          if(response?.data?.user.userLoginTypeId==LoginType.Patient){
            this.router.navigateByUrl('/appointment/search-doctor');
          }else{
            this.router.navigateByUrl('/barber/profile');
          }
          this._snackbarService.openSnack(response.swallText.title,NotificationTypeEnum.Success,'top');         
        }else{
          this._snackbarService.openSnack(response.swallText.html,NotificationTypeEnum.Danger);
        }
        this.isLoading=false;
      });
    // }
  }
 
  
  
  isEmailValidate:boolean=false;
  emailRegExp: RegExp = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
  validateEmail(email: string) {
    this.isEmailValidate=this.emailRegExp.test(email);
  }

}
