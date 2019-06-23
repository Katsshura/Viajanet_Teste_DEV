import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './user/user.component';
import { SignupComponent } from './user/signup/signup.component';
import { SigninComponent } from './user/signin/signin.component';
import { LandingPageComponent } from './landing-page/landing-page.component';

const routes: Routes = [
  {path:'home', redirectTo:'/home/signin', pathMatch: 'full'},
  {path: '', redirectTo: '/home/signin', pathMatch: 'full'},
  {path: 'home', component: UserComponent, children: [
      {path: 'signup', component: SignupComponent},
      {path: 'signin', component: SigninComponent},
    ]},
    {path:'landing', component: LandingPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
