import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

//api_services.js function can be located at: src\assets\js\api_services.js
declare const postResponse: any;

@Injectable({
  providedIn: 'root'
})
export class StoreService {

  constructor(private router: Router, private toastr: ToastrService) { }

  sendPurchaseToDatabase(purchase:any){
    this.makePostRequest(purchase);
  }

  private makePostRequest(data:any){
    postResponse('purchase', data, (res) => this.handleServerResponse(res));
  }

  private handleServerResponse(res:any){
    console.log(res);
    this.goToLandingPage();
  }

  private goToLandingPage(){
    this.router.navigateByUrl('/landing');
    this.toastr.success('Purchase made successfully!', 'Enjoy your product!');
  }
}
