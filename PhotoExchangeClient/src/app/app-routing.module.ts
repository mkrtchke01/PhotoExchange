import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/account/login/login.component';
import { ProfileComponent } from './components/account/profile/profile.component';
import { RegistrationComponent } from './components/account/registration/registration.component';
import { CreatePostComponent } from './components/posts/create-post/create-post.component';
import { GetAllPostsComponent } from './components/posts/get-all-posts/get-all-posts.component';
import { AuthGuard } from './shared/guards/auth.guard';

const routes: Routes = [
  {path: 'login', component: LoginComponent},
  {path:'registration', component: RegistrationComponent},
  
  {path: 'profile', component:ProfileComponent, canActivate:[AuthGuard]},
  {path: '', component: GetAllPostsComponent, canActivate: [AuthGuard]},
  {path: 'profile/create-post', component: CreatePostComponent, canActivate: [AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
