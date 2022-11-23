import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/shared/services/auth.service';
import { Login } from 'src/app/shared/models/login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private authService: AuthService) {
    localStorage.clear();
   }

  loginModel: Login = new Login
  token: any
  tokenString: string

  
  ngOnInit(): void {
  }

  login(){
    this.authService.login(this.loginModel)
  }

}