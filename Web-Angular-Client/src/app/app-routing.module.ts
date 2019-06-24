import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './user/user.component';
import { SignupComponent } from './user/signup/signup.component';
import { SigninComponent } from './user/signin/signin.component';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { CheckoutPageComponent } from './checkout-page/checkout-page.component';
import { ConfirmPaymentComponent } from './confirm-payment/confirm-payment.component';

const routes: Routes = [
  {path:'home', redirectTo:'/home/signin', pathMatch: 'full'},
  {path: '', redirectTo: '/home/signin', pathMatch: 'full'},
  {path: 'home', component: UserComponent, children: [
      {path: 'signup', component: SignupComponent},
      {path: 'signin', component: SigninComponent},
    ]},
  {path:'landing', component: LandingPageComponent},
  {path:'checkout', component: CheckoutPageComponent},
  {path:'finish', component: ConfirmPaymentComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
