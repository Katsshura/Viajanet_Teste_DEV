import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {ReactiveFormsModule} from '@angular/forms';
import {MatCardModule} from '@angular/material/card';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { ParticlesModule } from 'angular-particle';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { SignupComponent } from './user/signup/signup.component';
import { SigninComponent } from './user/signin/signin.component';
import { LandingPageComponent } from './landing-page/landing-page.component';
import {ParticlePropertiesService} from './util/particle-properties.service';
import { CardFormComponent } from './components/card-form/card-form.component';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    SignupComponent,
    SigninComponent,
    LandingPageComponent,
    CardFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule,
    ParticlesModule,
    MatCardModule
  ],
  providers: [ParticlePropertiesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
