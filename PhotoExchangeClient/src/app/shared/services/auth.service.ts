import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Login } from '../models/login';
import { Register } from '../models/register';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';



@Injectable({
  providedIn: 'root'
})
export class AuthService {

  token: any;
  tokenString: string;

  constructor(private http: HttpClient, private router: Router) { }

  readonly apiUrl = 'https://localhost:7242/api/Account';

  login(login: Login){
    return this.http.post(this.apiUrl + '/Login', login).subscribe(data=>{
      this.token = data;
      this.tokenString = this.token.token;
      localStorage.setItem('token', this.tokenString);
      this.router.navigate(['']);
    });
  }

  register(reg: Register){
    return this.http.post(this.apiUrl + '/Register', reg).subscribe(data=>{
      this.token = data;
      this.tokenString = this.token.token;
      localStorage.setItem('token', this.tokenString);
      this.router.navigate(['']);
    });
  }

  checkIsAuthorithed(){
    return localStorage.getItem('token') != null;
  }

  getToken(){
    return localStorage.getItem('token') || '';
  }
  refreshToken(){
    return localStorage.getItem('token') || '';
  }
  getProfile(): Observable<any>{
    return this.http.get(this.apiUrl + '/Profile');
  }
}
