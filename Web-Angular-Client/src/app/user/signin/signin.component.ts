import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, NgForm } from '@angular/forms';
import {HttpClient, HttpResponse} from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: []
})

export class SigninComponent implements OnInit {

  constructor(private fb: FormBuilder, private http: HttpClient, private router: Router, private toastr: ToastrService) { }

  formModel = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', Validators.required]
  });

  ngOnInit() {
  }

  async onSubmit(fb: NgForm){
    console.log(fb.value);
    this.getUserFromServer(fb.value['email'], fb.value['password']);
  }

  getUserFromServer(email: string, password: string){
    this.http.get('http://localhost:60620/api/v1/User/get', {
      params: {
        email: email,
        pass: password
      },
      observe: 'response'
    })
    .toPromise()
    .then(response => this.handleServerResponse(response))
    .catch(c => this.showErrorToastr());
  }

  handleServerResponse(response: HttpResponse<Object>){
    if(response.status == 200){
      this.router.navigateByUrl('/landing');
      this.toastr.success('Successfully logged in!', 'Enjoy!');
    }else{
      this.showErrorToastr();
    }
  }

  showErrorToastr(){
    this.toastr.error('Email or password invalid!', 'Authentication faild!');
  }

}
