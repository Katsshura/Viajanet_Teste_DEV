import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup, NgForm, Form } from '@angular/forms';
import {HttpClient} from '@angular/common/http';


@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: []
})

export class SignupComponent implements OnInit {

  constructor(private fb: FormBuilder, private http: HttpClient) { }

  formModel = this.fb.group({
    name: ['', [Validators.required, Validators.minLength(3)]],
    lastName: ['', [Validators.required, Validators.minLength(3)]],
    email: ['', [Validators.email, Validators.required]],
    phoneNumber: ['', Validators.required],
    password: ['', [Validators.required, Validators.minLength(4)]],
    confirmPass: ['', Validators.required],

  },{validator: [this.comparePasswords, this.validateEmail]});

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

  validateEmail(fb: FormGroup){
    let emailController = fb.get('email');
    if(emailController.errors === null || 'emailAlreadyExists' in emailController.errors){
      if(emailController.value === "emerson@emerson.com"){
        emailController.setErrors({emailAlreadyExists: true});
      }else{
        emailController.setErrors(null);
      }
    }
  }

  ngOnInit() {
    
  }

  async onSubmit(fb: NgForm){
    console.log(fb.value);
    this.getEmailFromServer(fb.value['email']);
  }

  async getEmailFromServer(email: string){
    if(email === null){return;}
    this.http.get('http://localhost:60620/api/v1/User/getemail', {
      params: {
        email: email
      },
      observe: 'response'
    })
    .toPromise()
    .then(response => {
      console.log(response.body);
    })
    .catch(console.log);
  }
  
}
