import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup, NgForm, Form } from '@angular/forms';
import { SignupService } from 'src/app/services/signup.service';
import { BrowserService } from 'src/app/services/browser.service';


@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: []
})

export class SignupComponent implements OnInit {

  constructor(private fb: FormBuilder, private service: SignupService, private browser_service: BrowserService) { }

  formModel = this.fb.group({
    name: ['', [Validators.required, Validators.minLength(3)]],
    lastName: ['', [Validators.required, Validators.minLength(3)]],
    email: ['', [Validators.email, Validators.required]],
    phoneNumber: ['', Validators.required],
    password: ['', [Validators.required, Validators.minLength(4)]],
    confirmPass: ['', Validators.required],

  },{validator: this.validateIfPasswordsMatch});

  validateIfPasswordsMatch(fb: FormGroup){
    let confirmPasswordController = fb.get('confirmPass');
    if(confirmPasswordController.errors === null || 'passwordMismatch' in confirmPasswordController.errors){
      if(fb.get('password').value != confirmPasswordController.value){
        confirmPasswordController.setErrors({passwordMismatch: true});
      }else{
        confirmPasswordController.setErrors(null);
      }
    }
  }

  ngOnInit() {
    this.browser_service.sendBrowserInformationToApi();
  }

  async onSubmit(fb: NgForm){
    this.service.onSignUp(fb);
  }
  
}
