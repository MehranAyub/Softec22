import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-booking-success',
  templateUrl: './booking-success.component.html',
  styleUrls: ['./booking-success.component.scss']
})
export class BookingSuccessComponent implements OnInit {
  doctorName:string='';

  constructor(activatedRoute:ActivatedRoute) {
    activatedRoute.queryParams.subscribe(params => {
      // this.isFromCashScreen = (params['isFromCashScreen'] == 'true');
      this.doctorName = (params['name'] || ''); 
    });
   }

  ngOnInit(): void {

  }

}
