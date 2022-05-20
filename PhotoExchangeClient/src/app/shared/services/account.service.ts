import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Login } from '../models/login';
import { Register } from '../models/register';
import { Token } from '../models/token';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  token: any;
  tokenString: string;

  constructor(private http: HttpClient) { }

  readonly apiUrl = 'https://localhost:7242/api/Account'

  login(login: Login){
    return this.http.post(this.apiUrl + '/Login', login)
  }

  register(reg: Register){
    return this.http.post(this.apiUrl + '/Register', reg).subscribe(data=>{
      this.token = data;
      this.tokenString = this.token.token;
      console.log(this.tokenString);
    })
  }
}
