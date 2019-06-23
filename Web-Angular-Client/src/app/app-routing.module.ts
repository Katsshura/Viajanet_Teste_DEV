import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './user/user.component';
import { SignupComponent } from './user/signup/signup.component';
import { SigninComponent } from './user/signin/signin.component';

const routes: Routes = [
  {path: '', redirectTo: '/user/signin', pathMatch: 'full'},
  {path: 'user', component: UserComponent, children: [
      {path: 'signup', component: SignupComponent},
      {path: 'signin', component: SigninComponent},
    ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
