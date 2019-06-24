import { Component, OnInit } from '@angular/core';
import { ParticlePropertiesService } from '../util/particle-properties.service';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BrowserService } from '../services/browser.service';

@Component({
  selector: 'app-checkout-page',
  templateUrl: './checkout-page.component.html',
  styleUrls: ['./checkout-page.component.css']
})
export class CheckoutPageComponent implements OnInit {
  myParams: object = {};

  constructor(private params: ParticlePropertiesService, private fb: FormBuilder, private router: Router, private browser_service: BrowserService) { }

  formModel = this.fb.group({
    country: ['', Validators.required],
    state: ['', Validators.required],
    city: ['', Validators.required],
    zip: [''],
    address: ['', Validators.required],
    paymentMethod: [''],
    shipping: [''],
    services: ['', Validators.required],
  });

  ngOnInit() {
    this.myParams = this.params.myParams;
    this.browser_service.sendBrowserInformationToApi();
  }

  onClick() {
    let paymentInformation = `${this.formModel.value['country']};${this.formModel.value['state']};${this.formModel.value['address']}`;
    localStorage.setItem("payment_information", paymentInformation);
    this.router.navigateByUrl("/finish");
  }

}
