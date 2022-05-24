import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/shared/services/account.service';
import { Login } from 'src/app/shared/models/login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private accountService: AccountService) { }

  loginModel: Login = new Login;

  
  ngOnInit(): void {
  }

  login(){
    this.accountService.login(this.loginModel);
  }

}
