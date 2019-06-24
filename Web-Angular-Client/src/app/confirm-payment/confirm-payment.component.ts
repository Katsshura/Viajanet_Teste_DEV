import { Component, OnInit } from '@angular/core';
import { ParticlePropertiesService } from '../util/particle-properties.service';
import { BrowserService } from '../services/browser.service';
import { StoreService } from '../services/store.service';


@Component({
  selector: 'app-confirm-payment',
  templateUrl: './confirm-payment.component.html',
  styleUrls: ['./confirm-payment.component.css']
})
export class ConfirmPaymentComponent implements OnInit {

  productInformation: any;
  paymentInformation: any;
  myParams: object = {};

  constructor(private params: ParticlePropertiesService, private browser_service: BrowserService, private service: StoreService) {
    this.productInformation = {
      title: localStorage.getItem("product_title"),
      id: localStorage.getItem("product_id")
    };

    let payment = localStorage.getItem("payment_information").split(';');
    
    this.paymentInformation = {
      country: payment[0],
      state: payment[1],
      address: payment[2],
    }
  }

  ngOnInit() {
    this.myParams = this.params.myParams;
    this.browser_service.sendBrowserInformationToApi();
  }

  onClick(){
    let userId = localStorage.getItem("user");
    let purchase = {
      userId: userId,
      productId: this.productInformation.id
    }
    this.service.sendPurchaseToDatabase(purchase);
  }
}
