import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Login } from '../models/login';
import { Register } from '../models/register';
import { Router } from '@angular/router';



@Injectable({
  providedIn: 'root'
})
export class AuthService {

  token: any;
  tokenString: string;

  constructor(private http: HttpClient, private router: Router) { }

  readonly apiUrl = 'https://localhost:7242/api/Account';

  login(login: Login){
    return this.http.post(this.apiUrl + '/Login', login);
  }

  register(reg: Register){
    return this.http.post(this.apiUrl + '/Register', reg);
  }

  checkIsAuthorithed(){
    return localStorage.getItem('token') != null;
  }

  getToken(){
    return localStorage.getItem('token') || '';
  }
}
