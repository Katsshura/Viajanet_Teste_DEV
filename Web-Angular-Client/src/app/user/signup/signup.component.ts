import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: []
})

export class SignupComponent implements OnInit {

  constructor(private fb: FormBuilder) {   console.log("aaa"); }

  formModel = this.fb.group({
    name: ['', [Validators.required, Validators.minLength(3)]],
    lastName: ['', [Validators.required, Validators.minLength(3)]],
    email: ['', [Validators.email, Validators.required]],
    phoneNumber: ['', Validators.required],
    password: ['', [Validators.required, Validators.minLength(4)]],
    confirmPass: ['', Validators.required],

  },{validator: this.comparePasswords});

  comparePasswords(fb: FormGroup){
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
    
  }

}
