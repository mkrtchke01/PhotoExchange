import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Register } from 'src/app/shared/models/register';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  constructor(private authService: AuthService, private router: Router) {
    localStorage.clear();
   }

  registerModel: Register = new Register;
  token: any;
  tokenString: string;

  ngOnInit(): void {
  }

  register(){
    this.authService.register(this.registerModel);
  }

}
