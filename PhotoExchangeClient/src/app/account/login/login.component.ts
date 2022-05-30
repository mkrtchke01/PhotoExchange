import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/shared/services/auth.service';
import { Login } from 'src/app/shared/models/login';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private authService: AuthService,private router: Router) {
    localStorage.clear();
   }

  loginModel: Login = new Login;
  token: any;
  tokenString: string;

  
  ngOnInit(): void {
  }

  login(){
    this.authService.login(this.loginModel).subscribe(data=>{
      this.token = data;
      this.tokenString = this.token.token;
      localStorage.setItem('token', this.tokenString);
      this.router.navigate(['']);
    });
  }

}
