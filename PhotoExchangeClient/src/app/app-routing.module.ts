import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './account/login/login.component';
import { RegistrationComponent } from './account/registration/registration.component';
import { HeaderComponent } from './header/header.component';
import { PostComponent } from './post/post.component';

const routes: Routes = [

  {path: 'login', component: LoginComponent},
  {path:'registration', component: RegistrationComponent},
  {path: 'posts', component: PostComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
