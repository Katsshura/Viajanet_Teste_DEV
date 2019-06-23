import { Injectable } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
//api_services.js function can be located at: src\assets\js\api_services.js
declare const getResponse: any;
//Key for user local storage
const user_key = "user";

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private router: Router, private toastr: ToastrService) { }

  onLogin(form: NgForm){
    let email = form.value['email'];
    let pass = form.value['password'];
    
    //Using lambda function to not lose ref for this class
    getResponse("user/get", {email: email, pass: pass}, (res, status) => this.handleResponseFromServer(res, status));
  }

  handleResponseFromServer(res, status){
    if(status === 'success'){
      this.router.navigateByUrl('/landing');
      this.toastr.success('Successfully logged in!', 'Enjoy!');
      this.storageUserOnLocalBrowser(res);
    }else{
      this.toastr.error('Email or password invalid!', 'Authentication faild!');
    }
  }

  storageUserOnLocalBrowser(res){
    let user = res[0]['id'];
    this.deleteLocalUserStorage();
    localStorage.setItem(user_key, user);
  }

  getLocalStorageUser(){
    return localStorage.getItem(user_key);
  }

  deleteLocalUserStorage(){
    localStorage.removeItem(user_key);
  }
}
