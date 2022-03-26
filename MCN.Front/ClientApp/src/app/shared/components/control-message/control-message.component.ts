import { Component, Input } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms'; 
import { ValidationService } from '../../services/common/ValidationService';

@Component({
  selector: 'control-messages',
  template: `<span *ngIf="errorMessageProp !== null" class="text-danger small" >{{errorMessage}}</span>`
})
export class ControlMessagesComponent {
  errorMessage: string='';
  @Input() control: FormControl=new FormControl();
  constructor() { }

  get errorMessageProp() {
    for (let propertyName in this.control.errors) {
       
      if (this.control.errors.hasOwnProperty(propertyName) && this.control.touched) {
         var message= ValidationService.getValidatorErrorMessage(propertyName, this.control.errors[propertyName]);
         this.errorMessage=message;
         return message;
        //return ValidationService.getValidatorErrorMessage(propertyName, this.control.errors[propertyName]);
      }
    }
    
    return null;
  }
}