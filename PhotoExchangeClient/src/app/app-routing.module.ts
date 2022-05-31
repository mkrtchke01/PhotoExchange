import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './account/login/login.component';
import { ProfileComponent } from './account/profile/profile.component';
import { RegistrationComponent } from './account/registration/registration.component';
import { HeaderComponent } from './header/header.component';
import { PostComponent } from './post/post.component';
import { AuthGuard } from './shared/auth.guard';

const routes: Routes = [
  {path: 'login', component: LoginComponent},
  {path:'registration', component: RegistrationComponent},
  
  {path: 'profile', component:ProfileComponent, canActivate:[AuthGuard]},
  {path: '', component: PostComponent, canActivate: [AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
