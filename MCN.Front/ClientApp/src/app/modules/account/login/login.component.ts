import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from 'src/app/shared/services/auth/auth.service';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms';
import { ValidationService } from 'src/app/shared/services/common/ValidationService'; 
import { emailDto, LoginDto, CreateUserDto } from '../models/UserLogin';
import { SnackBarService, NotificationTypeEnum } from 'src/app/shared/snack-bar.service';
import { DialogService } from 'src/app/shared/services/common/dialog.service';
import { UserRegisterComponent } from '../user-register/user-register.component';
import { AccountDataService } from '../services/accountDataService';
import { LoginType } from '../models/user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  isEmailVerify:boolean=false
  isEmailVerifyWithAuthToken:boolean=false;
  loginDto:LoginDto={email:'',password:''};
  createUserDto:CreateUserDto={Address:'',BaseURL:'',Country:'',Email:'',FirstName:'',Gender:'',IpAddress:'',LastName:'',Password:'',Phone:''};

  isLoading = false; 
  constructor(private _authService:AuthService,
    private router:Router,
    private formBuilder: FormBuilder,
    private _snackbarService:SnackBarService,
    private dialogService:DialogService,
    private aroute: ActivatedRoute,private _accountDataService:AccountDataService)
    {

      this.userForm = this.formBuilder.group({

        email: ['', [Validators.required, ValidationService.emailValidator]]

      }); 

    }
    ngOnInit(){
      
    }

    userForm:any;
  OnVerifyEmailAddress() {
  this.isLoading=true;  
  this._accountDataService._emailPasscode.email=this.loginDto.email;
    this.createUserDto.Email=this.loginDto.email;
      this._authService.ValidateEmail(this.loginDto.email).subscribe(response=>{
        console.log(response);
        if(response.statusCode==200){
          //this._snackbarService.openSnack(re.ksponse.swallText.title,NotificationTypeEnum.Success,'top');         
          this.isEmailVerify=true;
        }
        else if(response.statusCode==401){
          this.router.navigateByUrl('/account/email-verify');
          this._snackbarService.openSnack(response?.swallText?.title,NotificationTypeEnum.Danger);
        }
        else{
          this._snackbarService.openSnack(response.swallText.html,NotificationTypeEnum.Danger);
        }
        this.isLoading=false;
      });
    // }
  }

Login(){
  this.isLoading=true;
  this._authService.ValidateEmailPassword(this.loginDto.password,this.loginDto.email).subscribe((response)=>{
  console.log(response);  
  this.isLoading=false;
  if(response.statusCode==200){
    this.isEmailVerify=true;
    this.isEmailVerifyWithAuthToken=true;
    if(response?.data?.user.userLoginTypeId==LoginType.Patient){
      this.router.navigateByUrl('/appointment/search-doctor');
    }else{
      this.router.navigateByUrl('/appointment/search-doctor');
    }
    this._snackbarService.openSnack(response.swallText.html,NotificationTypeEnum.Success);  
  }
  else{
    this._snackbarService.openSnack(response?.swallText?.html,NotificationTypeEnum.Danger);
  }
});
  }

  
  

  closeModal(){

  }

  showErrorAlert(param1:any,param2:any){
    alert(param1);
  }

  isEmailValidate:boolean=false;
  emailRegExp: RegExp = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
  validateEmail(email: string) {
    this.isEmailValidate=this.emailRegExp.test(email);
  }
}
