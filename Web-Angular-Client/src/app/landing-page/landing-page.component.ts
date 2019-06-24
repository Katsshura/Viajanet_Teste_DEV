import { Component, OnInit } from '@angular/core';
import { ParticlePropertiesService } from '../util/particle-properties.service';
import { BrowserService } from '../services/browser.service';

//api_services.js function can be located at: src\assets\js\api_services.js
declare const getResponse: any;

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.css']
})
export class LandingPageComponent implements OnInit {
  myParams: object = {};
  products: any;
  description: string;


  constructor(private params: ParticlePropertiesService, private browser_service: BrowserService) { 
    getResponse("product", (res, status) => this.handleResponseFromServer(res, status));
  }

  ngOnInit() {
    this.myParams = this.params.myParams;
    this.browser_service.sendBrowserInformationToApi();
  }

  private handleResponseFromServer(res, status){
    this.products = res;
  }
}
