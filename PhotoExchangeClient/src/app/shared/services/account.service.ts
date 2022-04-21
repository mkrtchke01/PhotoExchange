import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Login } from '../models/login';
import { Register } from '../models/register';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private http: HttpClient) { }

  readonly apiUrl = 'https://localhost:7242/api/Account'

  login(login: Login){
    return this.http.post(this.apiUrl + 'Login', login)
  }

  register(reg: Register){
    return this.http.post(this.apiUrl + 'Register', reg)
  }
}
