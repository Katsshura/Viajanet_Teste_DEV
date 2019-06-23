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

  constructor(private router: Router, private toastr: ToastrService) { }


  async onSignUp(fb: NgForm){

    let data = {"name":"Emerson","lastName":"Alves","email":"xr.emerson@gmail.com","password":"123456","phoneNumber":82999480679};
      postResponse("user", data, (res, status) => this.handleResponseFromServer(res, status));

    // let email = fb.value['email'];;
    // if(await this.isEmailAlreadyRegistred(email) === false){
    //   //Using lambda function to not lose ref for this class
    //   let data = this.generateJsonFromNgForm(fb);
    //   postResponse("user", data, (res, status) => this.handleResponseFromServer(res, status));
    // }else{
    //   this.toastr.error('Email already in use!', 'Sign Up Failed!');
    // }
  }

  async isEmailAlreadyRegistred(email: string){
    if(email === null){return;}
    //Using lambda function to not lose ref for this class
    let res = await getResponse("user/getemail", {email: email});
    console.log(res);
    if(res === undefined || res === null){
      return false;
    }else{
      return true;
    }
  }

  handleResponseFromServer(res, status){
    console.log(res);
    if(status === 'success'){
      this.router.navigateByUrl('/landing');
      this.toastr.success('Successfully logged in!', 'Enjoy!');
    }else{
      this.toastr.error('Internal problems, try again later!', 'Internal Error!');
    }
  }

  generateJsonFromNgForm(fb: NgForm){
    let json = {
      "name":fb.value['name'],
      "lastName":fb.value['lastName'],
      "email":fb.value['email'],
      "password":fb.value['password'],
      "phoneNumber":fb.value['phoneNumber']
    }

    return json;
  }

}
