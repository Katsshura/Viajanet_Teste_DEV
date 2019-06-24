import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, NgForm } from '@angular/forms';
import { LoginService } from 'src/app/services/login.service';
import { BrowserService } from 'src/app/services/browser.service';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: []
})

export class SigninComponent implements OnInit {

  constructor(private fb: FormBuilder,  private service: LoginService, private browser_service: BrowserService) { }

  formModel = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', Validators.required]
  });

  ngOnInit() {
    this.browser_service.sendBrowserInformationToApi();
  }

  async onSubmit(fb: NgForm){
    this.service.onLogin(fb);
  }
}
