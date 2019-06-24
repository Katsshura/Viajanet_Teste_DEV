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

  public onLogin(form: NgForm){
    let email = form.value['email'];
    let pass = form.value['password'];
    getResponse("user/get", {email: email, pass: pass}, (res) => this.handleResponseFromServer(res));
  }

  private handleResponseFromServer(res){
    if(res != null && res != undefined){
      this.login(res);
    }else{
      this.toastr.error('Email or password invalid!', 'Authentication faild!');
    }
  }

  private login(res){
    this.router.navigateByUrl('/landing');
    this.toastr.success('Successfully logged in!', 'Enjoy!');
    this.storageUserOnLocalBrowser(res);
  }

  private storageUserOnLocalBrowser(res){
    let user = res[0]['id'];
    this.deleteLocalUserStorage();
    localStorage.setItem(user_key, user);
  }

  public getLocalStorageUser(){
    return localStorage.getItem(user_key);
  }

  private deleteLocalUserStorage(){
    localStorage.removeItem(user_key);
  }
}
