import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-booking-success',
  templateUrl: './booking-success.component.html',
  styleUrls: ['./booking-success.component.scss']
})
export class BookingSuccessComponent implements OnInit {
  doctorName:string='';

  constructor(activatedRoute:ActivatedRoute,private router:Router) {
    let user=JSON.parse(localStorage.getItem('currentUser'));
    if(user.user.userLoginTypeId==1){

      activatedRoute.queryParams.subscribe(params => {
        this.doctorName = (params['name'] || ''); 
      });
    }
    else{
      this.router.navigateByUrl('/doctor/appointments');
    }


  
   }

  ngOnInit(): void {

  }

}
