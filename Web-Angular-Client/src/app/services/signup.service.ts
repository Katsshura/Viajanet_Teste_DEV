import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';

//api_services.js function can be located at: src\assets\js\api_services.js
declare const getResponse: any;
declare const postResponse: any;

@Injectable({
  providedIn: 'root'
})
export class SignupService {

  form:NgForm;

  constructor(private router: Router, private toastr: ToastrService) { }


  public onSignUp(fb: NgForm) {
    this.form = fb;
    let email = fb.value['email'];;
    this.getResponseFromServer({email: email}, (res) => this.verifyAlreadyRegistredEmail(res));
  }

  private getResponseFromServer(data, callback){
    getResponse("user/getemail", data, callback);
  }

  private verifyAlreadyRegistredEmail(res: any) {
    //if null or undefined, means that there isn`t any email registred on the server
    //proceed sign up
    if(res === null || res === undefined){
      let data = this.generateJsonFromNgForm(this.form);
      this.makePostRequest(data);
    }else {
      this.toastr.error('Email already in use!', 'Sign Up Failed!');
    }
  }

  private makePostRequest(data){
    postResponse("user", data, (res) => this.onServerResponse(res));
  }

  private onServerResponse(res) {
    console.log(res);
    this.router.navigateByUrl('/home/signin');
    this.toastr.success('Successfully registered, proceed to login!', 'User Registred!');
  }

  private generateJsonFromNgForm(fb: NgForm) {
    let json = {
      "name": fb.value['name'],
      "lastName": fb.value['lastName'],
      "email": fb.value['email'],
      "password": fb.value['password'],
      "phoneNumber": fb.value['phoneNumber']
    }

    return json;
  }

}
